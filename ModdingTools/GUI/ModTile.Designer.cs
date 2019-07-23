﻿namespace ModdingTools.GUI
{
    partial class ModTile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cookModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cookModToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mafiaTownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 104);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, -1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "<PLACEHOLDER>";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cookModToolStripMenuItem,
            this.testModToolStripMenuItem,
            this.toolStripSeparator1,
            this.openDirectoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 98);
            // 
            // cookModToolStripMenuItem
            // 
            this.cookModToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileScriptsToolStripMenuItem,
            this.cookModToolStripMenuItem1});
            this.cookModToolStripMenuItem.Name = "cookModToolStripMenuItem";
            this.cookModToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cookModToolStripMenuItem.Text = "Build";
            // 
            // compileScriptsToolStripMenuItem
            // 
            this.compileScriptsToolStripMenuItem.Name = "compileScriptsToolStripMenuItem";
            this.compileScriptsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.compileScriptsToolStripMenuItem.Text = "Compile scripts";
            this.compileScriptsToolStripMenuItem.Click += new System.EventHandler(this.compileScriptsToolStripMenuItem_Click);
            // 
            // cookModToolStripMenuItem1
            // 
            this.cookModToolStripMenuItem1.Name = "cookModToolStripMenuItem1";
            this.cookModToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.cookModToolStripMenuItem1.Text = "Cook mod";
            this.cookModToolStripMenuItem1.Click += new System.EventHandler(this.cookModToolStripMenuItem1_Click);
            // 
            // testModToolStripMenuItem
            // 
            this.testModToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleScreenToolStripMenuItem,
            this.spaceshipToolStripMenuItem,
            this.mafiaTownToolStripMenuItem});
            this.testModToolStripMenuItem.Name = "testModToolStripMenuItem";
            this.testModToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testModToolStripMenuItem.Text = "Test mod";
            // 
            // titleScreenToolStripMenuItem
            // 
            this.titleScreenToolStripMenuItem.Name = "titleScreenToolStripMenuItem";
            this.titleScreenToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.titleScreenToolStripMenuItem.Text = "Title screen";
            this.titleScreenToolStripMenuItem.Click += new System.EventHandler(this.titleScreenToolStripMenuItem_Click);
            // 
            // spaceshipToolStripMenuItem
            // 
            this.spaceshipToolStripMenuItem.Name = "spaceshipToolStripMenuItem";
            this.spaceshipToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.spaceshipToolStripMenuItem.Text = "Spaceship";
            // 
            // mafiaTownToolStripMenuItem
            // 
            this.mafiaTownToolStripMenuItem.Name = "mafiaTownToolStripMenuItem";
            this.mafiaTownToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.mafiaTownToolStripMenuItem.Text = "Mafia town";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open directory";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // ModTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "ModTile";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cookModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cookModToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceshipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mafiaTownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
    }
}
