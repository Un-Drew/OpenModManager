using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CUFramework.Dialogs;
using CUFramework.Windows;
using ModdingTools.Engine;

namespace ModdingTools.Windows
{
    public partial class CookedContentAnalysisResults : CUWindow
    {
        public class CookedObjectTreeNode : TreeNode
        {
            public CookedContentAnalysis.CookedObject Object { get; protected set; }

            public CookedObjectTreeNode Outer { get; protected set; }
            public List<CookedObjectTreeNode> Children { get; protected set; }

            public long CachedSortSize = 0;

            // How many times is this asset referenced in the current tree? 0 for packages/groups.
            public int MatchCount = 0;
            // Should this object be part of the current tree? Only true for packages/groups if at least one child is a match.
            public bool IsMatch = false;
            // Is this object attached to the current tree? May be false for matches if the parent is collapsed, as an optimization.
            public bool IsAttached = false;

            public CookedObjectTreeNode(CookedContentAnalysis.CookedObject cookedObject)
            {
                Object = cookedObject;
                Children = new List<CookedObjectTreeNode>(Object.Children.Count);

                if (Object.bIsAsset)
                    ImageKey = "tree_asset";
                else if (Object.Outer != null)
                    ImageKey = "tree_grouping";
                else
                    ImageKey = "tree_package";
                SelectedImageKey = ImageKey;
            }

            public void RefreshText(bool useFullRefPath)
            {
                if (useFullRefPath)
                    Text = Object.ObjectRefPath;
                else
                    Text = Object.ObjectName;
            }

            public void SetOuter(CookedObjectTreeNode newOuter)
            {
                Outer = newOuter;
            }

            public long GetSize(bool withDupes = false)
            {
                // Packages and groupings should not be counted.
                if (!Object.bIsContent) return 0;
                if (withDupes)
                    return Object.SizeInBytes * MatchCount;
                else
                    return Object.SizeInBytes;
            }

            public long GetFullSizeOfMatches(bool withDupes = false)
            {
                return GetSize(withDupes) +
                (
                    // An asset's size SHOULD also include the size of its sub-objects. However, since
                    // sub-objects are never shown in the tree, their MatchCount is always 0, ironically
                    // resulting in a smaller size when calculating the size w/ dupes. So, when tallying
                    // the dupe-size of an asset, multiply the children size with the parent's match count!
                    (Object.bIsAsset && withDupes) ? (MatchCount * GetFullSizeOfMatchesInTree(Children, false))
                    // Otherwise just recurse normally.
                    : GetFullSizeOfMatchesInTree(Children, withDupes)
                );
            }

            static public long GetFullSizeOfMatchesInTree(List<CookedObjectTreeNode> tree, bool withDupes = false)
            {
                long size = 0;
                foreach (var node in tree)
                {
                    // Skip non-matches, unless this is a sub-object. Those should always be taken into account so that we
                    // always measure the full size of an asset - that includes its children.
                    // May not matter too much for, say, Materials, but there's assets like Font that have nested textures.
                    if (!node.IsMatch && (!node.Object.bIsContent || node.Object.bIsAsset))
                        continue;
                    size += node.GetFullSizeOfMatches(withDupes);
                }
                return size;
            }
        }

        public CookedContentAnalysis Analysis { get; protected set; }

        public List<CheckBox> PackageCheckboxes { get; protected set; }
        public bool CheckState_NotUserInflicted;

        public List<CookedContentAnalysis.AnalysisPackage> SelectedPackages { get; protected set; }

        public enum AssetSortType
        {
            Tree, Size
        };
        public AssetSortType CurrentSortType { get; protected set; }
        public bool CurrentSearchUsesShared { get; protected set; }

        public List<CookedObjectTreeNode> FullContentTree { get; protected set; }
        public List<CookedObjectTreeNode> SizeSortedNodes { get; protected set; } = new List<CookedObjectTreeNode>();
        public List<CookedObjectTreeNode> AttachedNodes { get; protected set; } = new List<CookedObjectTreeNode>();

        public bool NamesNeedRefresh { get; protected set; } = true;

        public CookedContentAnalysisResults(CookedContentAnalysis analysis)
        {
            InitializeComponent();

            Analysis = analysis;
        }

        private void CookedContentAnalysisResults_Load(object sender, EventArgs e)
        {
            CreatePackageCheckboxes();

            FullContentTree = new List<CookedObjectTreeNode>(Analysis.AssetTree.Count);
            CreateTreeNodesRecursive(Analysis.AssetTree, FullContentTree, outer: null);

            SelectedPackages = new List<CookedContentAnalysis.AnalysisPackage>(Analysis.PackageFiles);
            CurrentSearchUsesShared = false;
            CurrentSortType = AssetSortType.Tree;
            RefreshTree();
        }

        public void CreatePackageCheckboxes()
        {
            CheckBox checkBox;
            int pos = 0;

            packagesPanel.SuspendLayout();

            PackageCheckboxes = new List<CheckBox>(Analysis.PackageFiles.Count);
            foreach (var package in Analysis.PackageFiles)
            {
                checkBox = new CheckBox() { Checked = true, AutoSize = true, Text = Path.GetFileName(package.PackagePath), Location = new System.Drawing.Point(0, pos) };
                checkBox.CheckedChanged += PackageCheckBox_CheckedChanged;
                packagesPanel.Controls.Add(checkBox);
                PackageCheckboxes.Add(checkBox);
                pos += 20;
            }

            packagesPanel.ResumeLayout();

            selectAllPackagesCheckbox.Checked = true;
        }

        public void CreateTreeNodesRecursive(List<CookedContentAnalysis.CookedObject> from, List<CookedObjectTreeNode> to, CookedObjectTreeNode outer = null)
        {
            CookedObjectTreeNode node;
            foreach (var obj in from)
            {
                node = new CookedObjectTreeNode(obj);
                node.SetOuter(outer);
                CreateTreeNodesRecursive(obj.Children, node.Children, node);
                to.Add(node);
            }
        }

        private void modeHelpButton_Click(object sender, EventArgs e)
        {
            CUMessageBox.Show(
                "This option controls how assets are shown in the Content Tree:"
                + "\n    - ANY = An asset is shown if it's found in at least one of the selected packages."
                + "\n    - SHARED = An asset is shown only if it's present in all selected packages.",
                "Info"
            );
        }

        private void PackageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckState_NotUserInflicted) return;
            CheckState_NotUserInflicted = true;
            bool foundChecked = false, foundUnchecked = false;
            foreach (var chk in PackageCheckboxes)
            {
                if (chk.Checked) foundChecked = true;
                else foundUnchecked = true;
                if (!foundChecked || !foundUnchecked)
                    continue;
                selectAllPackagesCheckbox.CheckState = CheckState.Indeterminate;
                CheckState_NotUserInflicted = false;
                return;
            }
            selectAllPackagesCheckbox.CheckState = foundChecked ? CheckState.Checked : CheckState.Unchecked;
            CheckState_NotUserInflicted = false;
        }

        private void selectAllPackagesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckState_NotUserInflicted) return;
            CheckState_NotUserInflicted = true;
            foreach (var chk in PackageCheckboxes)
            {
                chk.Checked = selectAllPackagesCheckbox.Checked;
            }
            CheckState_NotUserInflicted = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                // First do this, as it's the first thing that can potentially fail.
                AssetSortType oldSortType = CurrentSortType;
                CurrentSortType = (AssetSortType)sortCombo.SelectedIndex;
                if (oldSortType != CurrentSortType)
                {
                    NamesNeedRefresh = true;
                }

                CurrentSearchUsesShared = sharedCheckbox.Checked;

                SelectedPackages.Clear();
                for (int i = 0; i < PackageCheckboxes.Count; i++)
                {
                    if (PackageCheckboxes[i].Checked && Analysis.PackageFiles[i].IsValid())
                        SelectedPackages.Add(Analysis.PackageFiles[i]);
                }

                RefreshTree();
            }
            catch (Exception ex)
            {
                CUMessageBox.Show(ex.ToString(), "Uh-oh...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contentTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (CurrentSortType != AssetSortType.Tree)
                return;
            if (!(e.Node is CookedObjectTreeNode))
                return;
            var node = (CookedObjectTreeNode)e.Node;
            foreach (var child in node.Children)
            {
                AttachRecursive(node.Nodes, child, !node.IsExpanded);
            }
        }

        public void RefreshTree()
        {
            contentTree.SelectedNode = null;
            UpdateStats();

            // TODO: Slower than attaching, not sure why. Does it really take that long to clear handles?
            contentTree.Nodes.Clear();

            // Clear the nodes in the opposite order, thus clearing the children before their parents. Doing this
            // to avoid an unnecessary recursion that the Clear function does, even when handles are removed.
            for (int i = AttachedNodes.Count - 1; i >= 0; i--)
            {
                AttachedNodes[i].Nodes.Clear();
                AttachedNodes[i].IsAttached = false;
            }
            AttachedNodes.Clear();

            if (NamesNeedRefresh)
            {
                NamesNeedRefresh = false;
                RefreshNodeTextsRecursive(FullContentTree);
            }

            DetermineMatchesRecursive(FullContentTree, GetCurrentMatchCondition());

            SizeSortedNodes.Clear();
            if (CurrentSortType == AssetSortType.Size)
            {
                AddMatchesToSizeSortListRecursive(FullContentTree);
                SizeSortedNodes.Sort((x, y) => (int)(y.CachedSortSize - x.CachedSortSize));

                contentTree.BeginUpdate();
                foreach (var node in SizeSortedNodes)
                {
                    contentTree.Nodes.Add(node);
                    node.IsAttached = true;
                }
                contentTree.EndUpdate();

                AttachedNodes.AddRange(SizeSortedNodes);
            }
            else if (CurrentSortType == AssetSortType.Tree)
            {
                // BeginUpdate might not work that well here if one of the attaches triggers a BeginUpdate/EndUpdate internally...
                // Unless this works like a stack behind the scenes? Can't really know because the decompiler is having a stroke.
                contentTree.BeginUpdate();
                foreach (var node in FullContentTree)
                {
                    AttachRecursive(contentTree.Nodes, node, !node.IsExpanded);
                }
                contentTree.EndUpdate();
            }
            // Right now, children are first in the list. To maintain this order, we'd need to insert any newly attached nodes
            // when expanding, which is kinda inefficient given how much stuff is usually nested in these things. Reverse the
            // order instead, so we can just use "Add" later.
            AttachedNodes.Reverse();

            contentSize.Text =(
                "Shown assets: " + HumanReadableFileSize(CookedObjectTreeNode.GetFullSizeOfMatchesInTree(FullContentTree, withDupes: true))
                + " (without dupes: " + HumanReadableFileSize(CookedObjectTreeNode.GetFullSizeOfMatchesInTree(FullContentTree, withDupes: false)) + ")"
            );
        }

        public void RefreshNodeTextsRecursive(List<CookedObjectTreeNode> tree)
        {
            foreach (var node in tree)
            {
                node.RefreshText(CurrentSortType == AssetSortType.Size);
                RefreshNodeTextsRecursive(node.Children);
            }
        }

        public Func<CookedObjectTreeNode, int> GetCurrentMatchCondition()
        {
            if (CurrentSearchUsesShared)
            {
                return (obj) =>
                {
                    foreach (var selPkg in SelectedPackages)
                    {
                        if (!obj.Object.ReferencedBy.Contains(selPkg))
                            return 0;
                    }
                    return SelectedPackages.Count;
                };
            }
            else
            {
                return (obj) =>
                {
                    int count = 0;
                    foreach (var refPkg in obj.Object.ReferencedBy)
                    {
                        if (SelectedPackages.Contains(refPkg))
                            count++;
                    }
                    return count;
                };
            }
        }

        public bool DetermineMatchesRecursive(List<CookedObjectTreeNode> nodes, Func<CookedObjectTreeNode, int> matchCondition)
        {
            bool anyMatches = false;
            foreach (var node in nodes)
            {
                // Matches must be assets, otherwise we could end up with a visible package/grouping with no children, which would be confusing.
                if (node.Object.bIsAsset)
                    node.MatchCount = matchCondition(node);
                else
                    node.MatchCount = 0;
                // If a child is visible, the parent should be as well!
                node.IsMatch = DetermineMatchesRecursive(node.Children, matchCondition) || (node.MatchCount > 0);
                if (node.IsMatch) anyMatches = true;
            }
            return anyMatches;
        }

        public void AddMatchesToSizeSortListRecursive(List<CookedObjectTreeNode> tree)
        {
            foreach (var node in tree)
            {
                if (!node.IsMatch) continue;
                if (node.Object.bIsAsset)
                {
                    SizeSortedNodes.Add(node);
                    node.CachedSortSize = node.GetSize(withDupes: true);
                }
                AddMatchesToSizeSortListRecursive(node.Children);
            }
        }

        public void AttachRecursive(TreeNodeCollection attachTo, CookedObjectTreeNode node, bool isCollapsed)
        {
            bool attachedAny = false;
            foreach (var child in node.Children)
            {
                if (!child.IsAttached)
                    AttachRecursive(node.Nodes, child, isCollapsed || !child.IsExpanded);
                if (child.IsAttached)
                    attachedAny = true;
                if (isCollapsed && attachedAny)
                {
                    // Only one is enough for collapsed nodes to show the + icon.
                    break;
                }
            }
            if (!node.IsAttached && node.IsMatch)
            {
                node.IsAttached = true;
                AttachedNodes.Add(node);
                attachTo.Add(node);
            }
        }

        private void contentTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateStats();
        }

        public void UpdateStats()
        {
            if (contentTree.SelectedNode == null || !(contentTree.SelectedNode is CookedObjectTreeNode))
            {
                packagesPanel.SuspendLayout();
                foreach (var chk in PackageCheckboxes)
                {
                    chk.ForeColor = Color.White;
                }
                packagesPanel.ResumeLayout();

                statsText.Text = "";

                return;
            }

            var selected = (CookedObjectTreeNode)contentTree.SelectedNode;

            string s;
            if (selected.Object.bIsAsset)
            {
                s = (
                    $"Class: {selected.Object.ObjectType}, Raw size: {HumanReadableFileSize(selected.GetFullSizeOfMatches(withDupes: true))}"
                    + " (without dupes: " + HumanReadableFileSize(selected.GetFullSizeOfMatches(withDupes: false)) + ")"
                );
                packagesPanel.SuspendLayout();
                int refCount = 0;
                for (int i = 0; i < PackageCheckboxes.Count; i++)
                {
                    if (selected.Object.ReferencedBy.Contains(Analysis.PackageFiles[i]))
                    {
                        refCount++;
                        PackageCheckboxes[i].ForeColor = Color.Lime;
                    }
                    else
                    {
                        PackageCheckboxes[i].ForeColor = Color.White;
                    }
                }
                packagesPanel.ResumeLayout();

                s += $", Cooked into {refCount}/{PackageCheckboxes.Count} packages.";
            }
            else
            {
                packagesPanel.SuspendLayout();
                foreach (var chk in PackageCheckboxes)
                {
                    chk.ForeColor = Color.White;
                }
                packagesPanel.ResumeLayout();

                s = (
                    "Size of shown childen: " + HumanReadableFileSize(selected.GetFullSizeOfMatches(withDupes: true))
                    + " (without dupes: " + HumanReadableFileSize(selected.GetFullSizeOfMatches(withDupes: false)) + ")."
                );
            }

            statsText.Text = s;
        }

        // Adapted from this stack overflow answer: https://stackoverflow.com/a/281679
        static public string HumanReadableFileSize(long sizeInBytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = sizeInBytes;
            int order = 0;
            while (len >= 1024d && order < sizes.Length - 1)
            {
                order++;
                len /= 1024d;
            }

            return len.ToString(len >= 100f ? "F0" : len >= 10f ? "F1" : "F2") + " " + sizes[order];
        }
    }
}
