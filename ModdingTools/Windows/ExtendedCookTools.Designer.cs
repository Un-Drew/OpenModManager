namespace ModdingTools.Windows
{
    partial class ExtendedCookTools
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
            this.cuButtonContentAnalysis = new CUFramework.Controls.CUButton();
            this.cuButtonContentAnalysis_WatDisDo = new CUFramework.Controls.CUButton();
            this.borderPanelContentAnalysis = new ModdingTools.GUI.BorderPanel();
            this.labelContentAnalysis = new System.Windows.Forms.Label();
            this.borderPanelContentAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuButtonContentAnalysis
            // 
            this.cuButtonContentAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cuButtonContentAnalysis.Dock = System.Windows.Forms.DockStyle.Right;
            this.cuButtonContentAnalysis.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.cuButtonContentAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButtonContentAnalysis.ForeColor = System.Drawing.Color.White;
            this.cuButtonContentAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cuButtonContentAnalysis.Location = new System.Drawing.Point(183, 5);
            this.cuButtonContentAnalysis.Name = "cuButtonContentAnalysis";
            this.cuButtonContentAnalysis.NoFocus = false;
            this.cuButtonContentAnalysis.Size = new System.Drawing.Size(100, 50);
            this.cuButtonContentAnalysis.TabIndex = 21;
            this.cuButtonContentAnalysis.Text = "RUN ANALYSIS";
            this.cuButtonContentAnalysis.UseVisualStyleBackColor = false;
            this.cuButtonContentAnalysis.Click += new System.EventHandler(this.cuButtonContentAnalysis_Click);
            // 
            // cuButtonContentAnalysis_WatDisDo
            // 
            this.cuButtonContentAnalysis_WatDisDo.BackColor = System.Drawing.Color.Purple;
            this.cuButtonContentAnalysis_WatDisDo.BackgroundImage = global::ModdingTools.Properties.Resources.msg_question;
            this.cuButtonContentAnalysis_WatDisDo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cuButtonContentAnalysis_WatDisDo.Dock = System.Windows.Forms.DockStyle.Right;
            this.cuButtonContentAnalysis_WatDisDo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.cuButtonContentAnalysis_WatDisDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButtonContentAnalysis_WatDisDo.ForeColor = System.Drawing.Color.White;
            this.cuButtonContentAnalysis_WatDisDo.Location = new System.Drawing.Point(283, 5);
            this.cuButtonContentAnalysis_WatDisDo.Name = "cuButtonContentAnalysis_WatDisDo";
            this.cuButtonContentAnalysis_WatDisDo.NoFocus = false;
            this.cuButtonContentAnalysis_WatDisDo.Size = new System.Drawing.Size(30, 50);
            this.cuButtonContentAnalysis_WatDisDo.TabIndex = 22;
            this.cuButtonContentAnalysis_WatDisDo.UseVisualStyleBackColor = false;
            this.cuButtonContentAnalysis_WatDisDo.Click += new System.EventHandler(this.cuButtonContentAnalysis_WatDisDo_Click);
            // 
            // borderPanelContentAnalysis
            // 
            this.borderPanelContentAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.borderPanelContentAnalysis.BorderThickness = 2;
            this.borderPanelContentAnalysis.Controls.Add(this.cuButtonContentAnalysis);
            this.borderPanelContentAnalysis.Controls.Add(this.cuButtonContentAnalysis_WatDisDo);
            this.borderPanelContentAnalysis.Controls.Add(this.labelContentAnalysis);
            this.borderPanelContentAnalysis.ForeColor = System.Drawing.Color.White;
            this.borderPanelContentAnalysis.Location = new System.Drawing.Point(16, 46);
            this.borderPanelContentAnalysis.Name = "borderPanelContentAnalysis";
            this.borderPanelContentAnalysis.Padding = new System.Windows.Forms.Padding(5);
            this.borderPanelContentAnalysis.Size = new System.Drawing.Size(318, 60);
            this.borderPanelContentAnalysis.TabIndex = 29;
            // 
            // labelContentAnalysis
            // 
            this.labelContentAnalysis.BackColor = System.Drawing.Color.Transparent;
            this.labelContentAnalysis.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelContentAnalysis.ForeColor = System.Drawing.Color.DarkGray;
            this.labelContentAnalysis.Location = new System.Drawing.Point(5, 5);
            this.labelContentAnalysis.Name = "labelContentAnalysis";
            this.labelContentAnalysis.Size = new System.Drawing.Size(170, 50);
            this.labelContentAnalysis.TabIndex = 30;
            this.labelContentAnalysis.Text = "COOKED CONTENT ANALYSIS:";
            this.labelContentAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtendedCookTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 400);
            this.Controls.Add(this.borderPanelContentAnalysis);
            this.IsMaximizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ExtendedCookTools";
            this.Text = "EXTENDED COOK TOOLS";
            this.Controls.SetChildIndex(this.borderPanelContentAnalysis, 0);
            this.borderPanelContentAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CUFramework.Controls.CUButton cuButtonContentAnalysis;
        private CUFramework.Controls.CUButton cuButtonContentAnalysis_WatDisDo;
        private GUI.BorderPanel borderPanelContentAnalysis;
        private System.Windows.Forms.Label labelContentAnalysis;
    }
}