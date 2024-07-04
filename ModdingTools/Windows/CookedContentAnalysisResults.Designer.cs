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
            this.packagesTitle = new System.Windows.Forms.Label();
            this.modePanel = new System.Windows.Forms.Panel();
            this.refreshButton = new CUFramework.Controls.CUButton();
            this.modeCombo = new System.Windows.Forms.ComboBox();
            this.modeHelpButton = new CUFramework.Controls.CUButton();
            this.modeLabel = new System.Windows.Forms.Label();
            this.contentTitle = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.packagesBorder = new ModdingTools.GUI.BorderPanel();
            this.contentPanel = new ModdingTools.GUI.BorderPanel();
            this.contentTree = new System.Windows.Forms.TreeView();
            this.packagesPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cookedAssetsSplit)).BeginInit();
            this.cookedAssetsSplit.Panel1.SuspendLayout();
            this.cookedAssetsSplit.Panel2.SuspendLayout();
            this.cookedAssetsSplit.SuspendLayout();
            this.modePanel.SuspendLayout();
            this.packagesBorder.SuspendLayout();
            this.contentPanel.SuspendLayout();
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
            this.cookedAssetsSplit.Panel1.Controls.Add(this.packagesTitle);
            this.cookedAssetsSplit.Panel1.Controls.Add(this.modePanel);
            this.cookedAssetsSplit.Panel1MinSize = 140;
            // 
            // cookedAssetsSplit.Panel2
            // 
            this.cookedAssetsSplit.Panel2.Controls.Add(this.contentPanel);
            this.cookedAssetsSplit.Panel2.Controls.Add(this.contentTitle);
            this.cookedAssetsSplit.Size = new System.Drawing.Size(496, 414);
            this.cookedAssetsSplit.SplitterDistance = 200;
            this.cookedAssetsSplit.TabIndex = 0;
            // 
            // packagesTitle
            // 
            this.packagesTitle.AutoSize = true;
            this.packagesTitle.BackColor = System.Drawing.Color.Transparent;
            this.packagesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.packagesTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.packagesTitle.Location = new System.Drawing.Point(0, 0);
            this.packagesTitle.Name = "packagesTitle";
            this.packagesTitle.Size = new System.Drawing.Size(64, 13);
            this.packagesTitle.TabIndex = 30;
            this.packagesTitle.Text = "PACKAGES";
            // 
            // modePanel
            // 
            this.modePanel.Controls.Add(this.refreshButton);
            this.modePanel.Controls.Add(this.modeCombo);
            this.modePanel.Controls.Add(this.modeHelpButton);
            this.modePanel.Controls.Add(this.modeLabel);
            this.modePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modePanel.Location = new System.Drawing.Point(0, 344);
            this.modePanel.Name = "modePanel";
            this.modePanel.Padding = new System.Windows.Forms.Padding(4);
            this.modePanel.Size = new System.Drawing.Size(200, 70);
            this.modePanel.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Image = global::ModdingTools.Properties.Resources.refresh;
            this.refreshButton.Location = new System.Drawing.Point(4, 28);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.NoFocus = false;
            this.refreshButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.refreshButton.Size = new System.Drawing.Size(192, 38);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = " REFRESH ";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshButton.UseVisualStyleBackColor = false;
            // 
            // modeCombo
            // 
            this.modeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modeCombo.FormattingEnabled = true;
            this.modeCombo.Items.AddRange(new object[] {
            "ANY",
            "SHARED"});
            this.modeCombo.Location = new System.Drawing.Point(103, 4);
            this.modeCombo.Name = "modeCombo";
            this.modeCombo.Size = new System.Drawing.Size(70, 21);
            this.modeCombo.TabIndex = 0;
            this.modeCombo.Text = "ANY";
            // 
            // modeHelpButton
            // 
            this.modeHelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modeHelpButton.BackColor = System.Drawing.Color.Transparent;
            this.modeHelpButton.BackgroundImage = global::ModdingTools.Properties.Resources.msg_question;
            this.modeHelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.modeHelpButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.modeHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeHelpButton.ForeColor = System.Drawing.Color.White;
            this.modeHelpButton.Location = new System.Drawing.Point(174, 4);
            this.modeHelpButton.Name = "modeHelpButton";
            this.modeHelpButton.NoFocus = false;
            this.modeHelpButton.Size = new System.Drawing.Size(21, 21);
            this.modeHelpButton.TabIndex = 2;
            this.modeHelpButton.UseVisualStyleBackColor = false;
            this.modeHelpButton.Click += new System.EventHandler(this.modeHelpButton_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(5, 4);
            this.modeLabel.MinimumSize = new System.Drawing.Size(0, 21);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(37, 21);
            this.modeLabel.TabIndex = 1;
            this.modeLabel.Text = "Mode:";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contentTitle
            // 
            this.contentTitle.AutoSize = true;
            this.contentTitle.BackColor = System.Drawing.Color.Transparent;
            this.contentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.contentTitle.Location = new System.Drawing.Point(0, 0);
            this.contentTitle.Name = "contentTitle";
            this.contentTitle.Size = new System.Drawing.Size(91, 13);
            this.contentTitle.TabIndex = 31;
            this.contentTitle.Text = "CONTENT TREE";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "cook.png");
            this.imageList.Images.SetKeyName(1, "compile.png");
            // 
            // packagesBorder
            // 
            this.packagesBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.packagesBorder.BorderThickness = 2;
            this.packagesBorder.Controls.Add(this.packagesPanel);
            this.packagesBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packagesBorder.ForeColor = System.Drawing.Color.White;
            this.packagesBorder.Location = new System.Drawing.Point(0, 13);
            this.packagesBorder.Name = "packagesBorder";
            this.packagesBorder.Padding = new System.Windows.Forms.Padding(5);
            this.packagesBorder.Size = new System.Drawing.Size(200, 331);
            this.packagesBorder.TabIndex = 29;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.contentPanel.BorderThickness = 2;
            this.contentPanel.Controls.Add(this.contentTree);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.ForeColor = System.Drawing.Color.White;
            this.contentPanel.Location = new System.Drawing.Point(0, 13);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.contentPanel.Size = new System.Drawing.Size(292, 401);
            this.contentPanel.TabIndex = 32;
            // 
            // contentTree
            // 
            this.contentTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.contentTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTree.LineColor = System.Drawing.Color.White;
            this.contentTree.Location = new System.Drawing.Point(5, 5);
            this.contentTree.Name = "contentTree";
            this.contentTree.Size = new System.Drawing.Size(282, 391);
            this.contentTree.TabIndex = 0;
            // 
            // packagesPanel
            // 
            this.packagesPanel.AutoScroll = true;
            this.packagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packagesPanel.Location = new System.Drawing.Point(5, 5);
            this.packagesPanel.Name = "packagesPanel";
            this.packagesPanel.Size = new System.Drawing.Size(190, 321);
            this.packagesPanel.TabIndex = 0;
            // 
            // CookedContentAnalysisResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.cookedAssetsSplit);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CookedContentAnalysisResults";
            this.Text = "COOK ANALYSIS : RESULTS";
            this.Load += new System.EventHandler(this.CookedContentAnalysisResults_Load);
            this.Controls.SetChildIndex(this.cookedAssetsSplit, 0);
            this.cookedAssetsSplit.Panel1.ResumeLayout(false);
            this.cookedAssetsSplit.Panel1.PerformLayout();
            this.cookedAssetsSplit.Panel2.ResumeLayout(false);
            this.cookedAssetsSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cookedAssetsSplit)).EndInit();
            this.cookedAssetsSplit.ResumeLayout(false);
            this.modePanel.ResumeLayout(false);
            this.modePanel.PerformLayout();
            this.packagesBorder.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SplitContainer cookedAssetsSplit;
        private System.Windows.Forms.Panel modePanel;
        private System.Windows.Forms.ComboBox modeCombo;
        private System.Windows.Forms.Label modeLabel;
        private CUFramework.Controls.CUButton modeHelpButton;
        private GUI.BorderPanel packagesBorder;
        private System.Windows.Forms.Label packagesTitle;
        private GUI.BorderPanel contentPanel;
        private System.Windows.Forms.Label contentTitle;
        private System.Windows.Forms.TreeView contentTree;
        private CUFramework.Controls.CUButton refreshButton;
        private System.Windows.Forms.Panel packagesPanel;
    }
}