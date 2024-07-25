namespace ModdingTools.Windows
{
    partial class CookedContentAnalysisResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CookedContentAnalysisResults));
            this.cookedAssetsSplit = new System.Windows.Forms.SplitContainer();
            this.packagesBorder = new ModdingTools.GUI.BorderPanel();
            this.packagesPanel = new System.Windows.Forms.Panel();
            this.selectAllPackagesCheckbox = new System.Windows.Forms.CheckBox();
            this.packagesTitle = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.refreshButton = new CUFramework.Controls.CUButton();
            this.sortCombo = new System.Windows.Forms.ComboBox();
            this.sortLabel = new System.Windows.Forms.Label();
            this.ALRedundanciesCheckbox = new System.Windows.Forms.CheckBox();
            this.sharedCheckbox = new System.Windows.Forms.CheckBox();
            this.contentPanel = new ModdingTools.GUI.BorderPanel();
            this.contentTree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contentTopBar = new System.Windows.Forms.Panel();
            this.contentSize = new System.Windows.Forms.Label();
            this.contentTitle = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statsBorder = new ModdingTools.GUI.BorderPanel();
            this.statsText = new System.Windows.Forms.Label();
            this.statsTitle = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cookedAssetsSplit)).BeginInit();
            this.cookedAssetsSplit.Panel1.SuspendLayout();
            this.cookedAssetsSplit.Panel2.SuspendLayout();
            this.cookedAssetsSplit.SuspendLayout();
            this.packagesBorder.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.contentTopBar.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.statsBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // cookedAssetsSplit
            // 
            this.cookedAssetsSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cookedAssetsSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cookedAssetsSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.cookedAssetsSplit.Location = new System.Drawing.Point(2, 34);
            this.cookedAssetsSplit.Name = "cookedAssetsSplit";
            // 
            // cookedAssetsSplit.Panel1
            // 
            this.cookedAssetsSplit.Panel1.Controls.Add(this.packagesBorder);
            this.cookedAssetsSplit.Panel1.Controls.Add(this.selectAllPackagesCheckbox);
            this.cookedAssetsSplit.Panel1.Controls.Add(this.packagesTitle);
            this.cookedAssetsSplit.Panel1.Controls.Add(this.filterPanel);
            this.cookedAssetsSplit.Panel1MinSize = 200;
            // 
            // cookedAssetsSplit.Panel2
            // 
            this.cookedAssetsSplit.Panel2.Controls.Add(this.contentPanel);
            this.cookedAssetsSplit.Panel2.Controls.Add(this.contentTopBar);
            this.cookedAssetsSplit.Panel2.Controls.Add(this.statsPanel);
            this.cookedAssetsSplit.Panel2MinSize = 160;
            this.cookedAssetsSplit.Size = new System.Drawing.Size(746, 434);
            this.cookedAssetsSplit.SplitterDistance = 230;
            this.cookedAssetsSplit.TabIndex = 0;
            // 
            // packagesBorder
            // 
            this.packagesBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.packagesBorder.BorderThickness = 2;
            this.packagesBorder.Controls.Add(this.packagesPanel);
            this.packagesBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packagesBorder.ForeColor = System.Drawing.Color.White;
            this.packagesBorder.Location = new System.Drawing.Point(0, 22);
            this.packagesBorder.Name = "packagesBorder";
            this.packagesBorder.Padding = new System.Windows.Forms.Padding(5);
            this.packagesBorder.Size = new System.Drawing.Size(230, 292);
            this.packagesBorder.TabIndex = 29;
            // 
            // packagesPanel
            // 
            this.packagesPanel.AutoScroll = true;
            this.packagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packagesPanel.Location = new System.Drawing.Point(5, 5);
            this.packagesPanel.Name = "packagesPanel";
            this.packagesPanel.Size = new System.Drawing.Size(220, 282);
            this.packagesPanel.TabIndex = 0;
            // 
            // selectAllPackagesCheckbox
            // 
            this.selectAllPackagesCheckbox.Location = new System.Drawing.Point(72, 2);
            this.selectAllPackagesCheckbox.Name = "selectAllPackagesCheckbox";
            this.selectAllPackagesCheckbox.Size = new System.Drawing.Size(104, 18);
            this.selectAllPackagesCheckbox.TabIndex = 31;
            this.selectAllPackagesCheckbox.Text = "SELECT ALL";
            this.selectAllPackagesCheckbox.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.selectAllPackagesCheckbox.UseVisualStyleBackColor = true;
            this.selectAllPackagesCheckbox.CheckedChanged += new System.EventHandler(this.selectAllPackagesCheckbox_CheckedChanged);
            // 
            // packagesTitle
            // 
            this.packagesTitle.BackColor = System.Drawing.Color.Transparent;
            this.packagesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.packagesTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.packagesTitle.Location = new System.Drawing.Point(0, 0);
            this.packagesTitle.Name = "packagesTitle";
            this.packagesTitle.Size = new System.Drawing.Size(230, 22);
            this.packagesTitle.TabIndex = 30;
            this.packagesTitle.Text = "PACKAGES";
            this.packagesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.refreshButton);
            this.filterPanel.Controls.Add(this.sortCombo);
            this.filterPanel.Controls.Add(this.sortLabel);
            this.filterPanel.Controls.Add(this.ALRedundanciesCheckbox);
            this.filterPanel.Controls.Add(this.sharedCheckbox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterPanel.Location = new System.Drawing.Point(0, 314);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(4);
            this.filterPanel.Size = new System.Drawing.Size(230, 120);
            this.filterPanel.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = global::ModdingTools.Properties.Resources.refresh;
            this.refreshButton.Location = new System.Drawing.Point(4, 78);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.NoFocus = false;
            this.refreshButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.refreshButton.Size = new System.Drawing.Size(222, 38);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = " REFRESH ";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // sortCombo
            // 
            this.sortCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sortCombo.FormattingEnabled = true;
            this.sortCombo.Items.AddRange(new object[] {
            "TREE",
            "SIZE"});
            this.sortCombo.Location = new System.Drawing.Point(153, 53);
            this.sortCombo.Name = "sortCombo";
            this.sortCombo.Size = new System.Drawing.Size(70, 21);
            this.sortCombo.TabIndex = 0;
            this.sortCombo.Text = "TREE";
            this.toolTip.SetToolTip(this.sortCombo, resources.GetString("sortCombo.ToolTip"));
            // 
            // sortLabel
            // 
            this.sortLabel.AutoSize = true;
            this.sortLabel.Location = new System.Drawing.Point(7, 53);
            this.sortLabel.Margin = new System.Windows.Forms.Padding(3);
            this.sortLabel.MinimumSize = new System.Drawing.Size(0, 21);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(52, 21);
            this.sortLabel.TabIndex = 1;
            this.sortLabel.Text = "Sort type:";
            this.sortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ALRedundanciesCheckbox
            // 
            this.ALRedundanciesCheckbox.AutoSize = true;
            this.ALRedundanciesCheckbox.Location = new System.Drawing.Point(7, 30);
            this.ALRedundanciesCheckbox.Name = "ALRedundanciesCheckbox";
            this.ALRedundanciesCheckbox.Size = new System.Drawing.Size(186, 17);
            this.ALRedundanciesCheckbox.TabIndex = 5;
            this.ALRedundanciesCheckbox.Text = "Only AlwaysLoaded redundancies";
            this.toolTip.SetToolTip(this.ALRedundanciesCheckbox, resources.GetString("ALRedundanciesCheckbox.ToolTip"));
            this.ALRedundanciesCheckbox.UseVisualStyleBackColor = true;
            // 
            // sharedCheckbox
            // 
            this.sharedCheckbox.AutoSize = true;
            this.sharedCheckbox.Location = new System.Drawing.Point(7, 7);
            this.sharedCheckbox.Name = "sharedCheckbox";
            this.sharedCheckbox.Size = new System.Drawing.Size(66, 17);
            this.sharedCheckbox.TabIndex = 4;
            this.sharedCheckbox.Text = "Shared?";
            this.toolTip.SetToolTip(this.sharedCheckbox, "If enabled, the content panel will only show assets that are present in ALL selec" +
        "ted maps.\r\nIf disabled, the content panel will show any assets that are present " +
        "in the selected maps.");
            this.sharedCheckbox.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.contentPanel.BorderThickness = 2;
            this.contentPanel.Controls.Add(this.contentTree);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.ForeColor = System.Drawing.Color.White;
            this.contentPanel.Location = new System.Drawing.Point(0, 22);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.contentPanel.Size = new System.Drawing.Size(512, 358);
            this.contentPanel.TabIndex = 32;
            // 
            // contentTree
            // 
            this.contentTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.contentTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTree.ForeColor = System.Drawing.Color.White;
            this.contentTree.ImageIndex = 0;
            this.contentTree.ImageList = this.imageList;
            this.contentTree.LineColor = System.Drawing.Color.White;
            this.contentTree.Location = new System.Drawing.Point(5, 5);
            this.contentTree.Name = "contentTree";
            this.contentTree.SelectedImageIndex = 0;
            this.contentTree.Size = new System.Drawing.Size(502, 348);
            this.contentTree.TabIndex = 0;
            this.contentTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.contentTree_BeforeExpand);
            this.contentTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.contentTree_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "tree_package");
            this.imageList.Images.SetKeyName(1, "tree_grouping");
            this.imageList.Images.SetKeyName(2, "tree_asset");
            // 
            // contentTopBar
            // 
            this.contentTopBar.Controls.Add(this.contentSize);
            this.contentTopBar.Controls.Add(this.contentTitle);
            this.contentTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentTopBar.Location = new System.Drawing.Point(0, 0);
            this.contentTopBar.Name = "contentTopBar";
            this.contentTopBar.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.contentTopBar.Size = new System.Drawing.Size(512, 22);
            this.contentTopBar.TabIndex = 34;
            // 
            // contentSize
            // 
            this.contentSize.AutoEllipsis = true;
            this.contentSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentSize.Location = new System.Drawing.Point(100, 0);
            this.contentSize.Name = "contentSize";
            this.contentSize.Size = new System.Drawing.Size(407, 22);
            this.contentSize.TabIndex = 33;
            this.contentSize.Text = "Size in tree: 0 B";
            this.contentSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.contentSize, resources.GetString("contentSize.ToolTip"));
            // 
            // contentTitle
            // 
            this.contentTitle.BackColor = System.Drawing.Color.Transparent;
            this.contentTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.contentTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.contentTitle.Location = new System.Drawing.Point(0, 0);
            this.contentTitle.Name = "contentTitle";
            this.contentTitle.Size = new System.Drawing.Size(100, 22);
            this.contentTitle.TabIndex = 31;
            this.contentTitle.Text = "CONTENT TREE";
            this.contentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.statsBorder);
            this.statsPanel.Controls.Add(this.statsTitle);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsPanel.Location = new System.Drawing.Point(0, 380);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Padding = new System.Windows.Forms.Padding(3);
            this.statsPanel.Size = new System.Drawing.Size(512, 54);
            this.statsPanel.TabIndex = 1;
            // 
            // statsBorder
            // 
            this.statsBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statsBorder.BorderThickness = 2;
            this.statsBorder.Controls.Add(this.statsText);
            this.statsBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsBorder.ForeColor = System.Drawing.Color.White;
            this.statsBorder.Location = new System.Drawing.Point(3, 23);
            this.statsBorder.Name = "statsBorder";
            this.statsBorder.Padding = new System.Windows.Forms.Padding(5);
            this.statsBorder.Size = new System.Drawing.Size(506, 28);
            this.statsBorder.TabIndex = 32;
            // 
            // statsText
            // 
            this.statsText.AutoEllipsis = true;
            this.statsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsText.Location = new System.Drawing.Point(5, 5);
            this.statsText.Name = "statsText";
            this.statsText.Size = new System.Drawing.Size(496, 18);
            this.statsText.TabIndex = 0;
            this.statsText.Text = "Stats :)";
            // 
            // statsTitle
            // 
            this.statsTitle.BackColor = System.Drawing.Color.Transparent;
            this.statsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.statsTitle.Location = new System.Drawing.Point(3, 3);
            this.statsTitle.Name = "statsTitle";
            this.statsTitle.Size = new System.Drawing.Size(506, 20);
            this.statsTitle.TabIndex = 31;
            this.statsTitle.Text = "STATS";
            this.statsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 15000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // CookedContentAnalysisResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 470);
            this.Controls.Add(this.cookedAssetsSplit);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "CookedContentAnalysisResults";
            this.Text = "COOK ANALYSIS RESULTS";
            this.Load += new System.EventHandler(this.CookedContentAnalysisResults_Load);
            this.Controls.SetChildIndex(this.cookedAssetsSplit, 0);
            this.cookedAssetsSplit.Panel1.ResumeLayout(false);
            this.cookedAssetsSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cookedAssetsSplit)).EndInit();
            this.cookedAssetsSplit.ResumeLayout(false);
            this.packagesBorder.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentTopBar.ResumeLayout(false);
            this.statsPanel.ResumeLayout(false);
            this.statsBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SplitContainer cookedAssetsSplit;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.ComboBox sortCombo;
        private System.Windows.Forms.Label sortLabel;
        private GUI.BorderPanel packagesBorder;
        private System.Windows.Forms.Label packagesTitle;
        private GUI.BorderPanel contentPanel;
        private System.Windows.Forms.Label contentTitle;
        private System.Windows.Forms.TreeView contentTree;
        private CUFramework.Controls.CUButton refreshButton;
        private System.Windows.Forms.Panel packagesPanel;
        private System.Windows.Forms.CheckBox selectAllPackagesCheckbox;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label statsTitle;
        private System.Windows.Forms.ToolTip toolTip;
        private GUI.BorderPanel statsBorder;
        private System.Windows.Forms.Label statsText;
        private System.Windows.Forms.Label contentSize;
        private System.Windows.Forms.Panel contentTopBar;
        private System.Windows.Forms.CheckBox sharedCheckbox;
        private System.Windows.Forms.CheckBox ALRedundanciesCheckbox;
    }
}