using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUFramework.Dialogs;
using CUFramework.Windows;
using ModdingTools.Engine;

namespace ModdingTools.Windows
{
    public partial class CookedContentAnalysisResults : CUWindow
    {
        public CookedContentAnalysis Analysis { get; protected set; }

        public List<CheckBox> PackageCheckboxes { get; protected set; }

        public CookedContentAnalysisResults(CookedContentAnalysis analysis)
        {
            InitializeComponent();

            Analysis = analysis;
        }

        private void CookedContentAnalysisResults_Load(object sender, EventArgs e)
        {
            CreatePackageCheckboxes();
        }

        public void CreatePackageCheckboxes()
        {
            CheckBox checkBox;
            int pos = 0;

            packagesPanel.SuspendLayout();

            PackageCheckboxes = new List<CheckBox>(Analysis.Packages.Count);
            foreach (var package in Analysis.Packages)
            {
                checkBox = new CheckBox() { Checked = true, AutoSize = true, Text = Path.GetFileName(package.PackagePath), Location = new Point(0, pos) };
                packagesPanel.Controls.Add(checkBox);
                PackageCheckboxes.Add(checkBox);
                pos += 20;
            }

            packagesPanel.ResumeLayout();
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
    }
}
