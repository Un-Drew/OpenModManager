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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtendedCookTools));
            this.checkboxCustomCooking = new System.Windows.Forms.CheckBox();
            this.cookSettingsPanel = new ModdingTools.GUI.BorderPanel();
            this.tabControl = new CUFramework.Controls.Tabs.CUBorderlessTabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.generalSettings_Env = new System.Windows.Forms.Panel();
            this.checkBox_Env_CookInIsolation = new System.Windows.Forms.CheckBox();
            this.settingsTitle_Env = new System.Windows.Forms.Label();
            this.generalSettings_Script = new System.Windows.Forms.Panel();
            this.radio_Script_Type_Default = new System.Windows.Forms.RadioButton();
            this.group_Script_Type = new CUFramework.Controls.CUGroupBox();
            this.checkBox_Script_CookNonAL = new System.Windows.Forms.CheckBox();
            this.checkBox_Script_EmbedNonAL = new System.Windows.Forms.CheckBox();
            this.settingsTitle_Script = new System.Windows.Forms.Label();
            this.tabCookGroups = new System.Windows.Forms.TabPage();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabController = new CUFramework.Controls.Tabs.CUTabController();
            this.cookSettingsTitleBorder = new System.Windows.Forms.Panel();
            this.cookSettingsTitleContent = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.radio_Script_Type_Embed = new System.Windows.Forms.RadioButton();
            this.check_Script_ExcludeBaseALAssets = new System.Windows.Forms.CheckBox();
            this.radio_Script_Type_NonAL = new System.Windows.Forms.RadioButton();
            this.cookSettingsPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.generalSettings_Env.SuspendLayout();
            this.generalSettings_Script.SuspendLayout();
            this.group_Script_Type.SuspendLayout();
            this.cookSettingsTitleBorder.SuspendLayout();
            this.cookSettingsTitleContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkboxCustomCooking
            // 
            this.checkboxCustomCooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkboxCustomCooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxCustomCooking.Location = new System.Drawing.Point(6, 0);
            this.checkboxCustomCooking.Name = "checkboxCustomCooking";
            this.checkboxCustomCooking.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.checkboxCustomCooking.Size = new System.Drawing.Size(210, 28);
            this.checkboxCustomCooking.TabIndex = 30;
            this.checkboxCustomCooking.Text = "ENABLE CUSTOM COOKING";
            this.checkboxCustomCooking.UseVisualStyleBackColor = false;
            // 
            // cookSettingsPanel
            // 
            this.cookSettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cookSettingsPanel.BorderThickness = 1;
            this.cookSettingsPanel.Controls.Add(this.tabControl);
            this.cookSettingsPanel.Controls.Add(this.tabController);
            this.cookSettingsPanel.ForeColor = System.Drawing.Color.White;
            this.cookSettingsPanel.Location = new System.Drawing.Point(4, 64);
            this.cookSettingsPanel.Name = "cookSettingsPanel";
            this.cookSettingsPanel.Padding = new System.Windows.Forms.Padding(2);
            this.cookSettingsPanel.Size = new System.Drawing.Size(532, 300);
            this.cookSettingsPanel.TabIndex = 31;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGeneral);
            this.tabControl.Controls.Add(this.tabCookGroups);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ImageList = this.tabImageList;
            this.tabControl.Location = new System.Drawing.Point(102, 2);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(428, 296);
            this.tabControl.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabGeneral.Controls.Add(this.generalSettings_Env);
            this.tabGeneral.Controls.Add(this.generalSettings_Script);
            this.tabGeneral.ImageIndex = 0;
            this.tabGeneral.Location = new System.Drawing.Point(0, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(5);
            this.tabGeneral.Size = new System.Drawing.Size(428, 296);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "GENERAL";
            // 
            // generalSettings_Env
            // 
            this.generalSettings_Env.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generalSettings_Env.Controls.Add(this.checkBox_Env_CookInIsolation);
            this.generalSettings_Env.Controls.Add(this.settingsTitle_Env);
            this.generalSettings_Env.Location = new System.Drawing.Point(8, 241);
            this.generalSettings_Env.Name = "generalSettings_Env";
            this.generalSettings_Env.Padding = new System.Windows.Forms.Padding(4);
            this.generalSettings_Env.Size = new System.Drawing.Size(412, 50);
            this.generalSettings_Env.TabIndex = 32;
            // 
            // checkBox_Env_CookInIsolation
            // 
            this.checkBox_Env_CookInIsolation.AutoSize = true;
            this.checkBox_Env_CookInIsolation.Location = new System.Drawing.Point(7, 26);
            this.checkBox_Env_CookInIsolation.Name = "checkBox_Env_CookInIsolation";
            this.checkBox_Env_CookInIsolation.Size = new System.Drawing.Size(105, 17);
            this.checkBox_Env_CookInIsolation.TabIndex = 0;
            this.checkBox_Env_CookInIsolation.Text = "Cook in islolation";
            this.toolTip.SetToolTip(this.checkBox_Env_CookInIsolation, resources.GetString("checkBox_Env_CookInIsolation.ToolTip"));
            this.checkBox_Env_CookInIsolation.UseVisualStyleBackColor = true;
            // 
            // settingsTitle_Env
            // 
            this.settingsTitle_Env.AutoSize = true;
            this.settingsTitle_Env.BackColor = System.Drawing.Color.Transparent;
            this.settingsTitle_Env.ForeColor = System.Drawing.Color.DarkGray;
            this.settingsTitle_Env.Location = new System.Drawing.Point(7, 7);
            this.settingsTitle_Env.Margin = new System.Windows.Forms.Padding(3);
            this.settingsTitle_Env.Name = "settingsTitle_Env";
            this.settingsTitle_Env.Size = new System.Drawing.Size(87, 13);
            this.settingsTitle_Env.TabIndex = 29;
            this.settingsTitle_Env.Text = "ENVIRONMENT";
            // 
            // generalSettings_Script
            // 
            this.generalSettings_Script.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generalSettings_Script.Controls.Add(this.group_Script_Type);
            this.generalSettings_Script.Controls.Add(this.checkBox_Script_CookNonAL);
            this.generalSettings_Script.Controls.Add(this.checkBox_Script_EmbedNonAL);
            this.generalSettings_Script.Controls.Add(this.settingsTitle_Script);
            this.generalSettings_Script.Location = new System.Drawing.Point(8, 8);
            this.generalSettings_Script.Name = "generalSettings_Script";
            this.generalSettings_Script.Padding = new System.Windows.Forms.Padding(4);
            this.generalSettings_Script.Size = new System.Drawing.Size(412, 227);
            this.generalSettings_Script.TabIndex = 31;
            // 
            // radio_Script_Type_Default
            // 
            this.radio_Script_Type_Default.AutoSize = true;
            this.radio_Script_Type_Default.Location = new System.Drawing.Point(8, 29);
            this.radio_Script_Type_Default.Name = "radio_Script_Type_Default";
            this.radio_Script_Type_Default.Size = new System.Drawing.Size(192, 17);
            this.radio_Script_Type_Default.TabIndex = 31;
            this.radio_Script_Type_Default.TabStop = true;
            this.radio_Script_Type_Default.Text = "Normal - No fancy fixes are applied.";
            this.radio_Script_Type_Default.UseVisualStyleBackColor = true;
            // 
            // group_Script_Type
            // 
            this.group_Script_Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.group_Script_Type.BorderSize = 3;
            this.group_Script_Type.Controls.Add(this.radio_Script_Type_NonAL);
            this.group_Script_Type.Controls.Add(this.check_Script_ExcludeBaseALAssets);
            this.group_Script_Type.Controls.Add(this.radio_Script_Type_Embed);
            this.group_Script_Type.Controls.Add(this.radio_Script_Type_Default);
            this.group_Script_Type.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.group_Script_Type.HeaderFontColor = System.Drawing.Color.White;
            this.group_Script_Type.HeaderHeight = 20;
            this.group_Script_Type.HeaderText = "COOKING TYPE";
            this.group_Script_Type.Location = new System.Drawing.Point(7, 72);
            this.group_Script_Type.Name = "group_Script_Type";
            this.group_Script_Type.Padding = new System.Windows.Forms.Padding(5, 26, 5, 5);
            this.group_Script_Type.Size = new System.Drawing.Size(396, 146);
            this.group_Script_Type.TabIndex = 32;
            // 
            // checkBox_Script_CookNonAL
            // 
            this.checkBox_Script_CookNonAL.AutoSize = true;
            this.checkBox_Script_CookNonAL.Location = new System.Drawing.Point(7, 49);
            this.checkBox_Script_CookNonAL.Name = "checkBox_Script_CookNonAL";
            this.checkBox_Script_CookNonAL.Size = new System.Drawing.Size(160, 17);
            this.checkBox_Script_CookNonAL.TabIndex = 30;
            this.checkBox_Script_CookNonAL.Text = "Cook as Non-AlwaysLoaded";
            this.toolTip.SetToolTip(this.checkBox_Script_CookNonAL, resources.GetString("checkBox_Script_CookNonAL.ToolTip"));
            this.checkBox_Script_CookNonAL.UseVisualStyleBackColor = true;
            // 
            // checkBox_Script_EmbedNonAL
            // 
            this.checkBox_Script_EmbedNonAL.AutoSize = true;
            this.checkBox_Script_EmbedNonAL.Location = new System.Drawing.Point(7, 26);
            this.checkBox_Script_EmbedNonAL.Name = "checkBox_Script_EmbedNonAL";
            this.checkBox_Script_EmbedNonAL.Size = new System.Drawing.Size(246, 17);
            this.checkBox_Script_EmbedNonAL.TabIndex = 0;
            this.checkBox_Script_EmbedNonAL.Text = "Embed referenced Non-AlwaysLoaded classes";
            this.toolTip.SetToolTip(this.checkBox_Script_EmbedNonAL, resources.GetString("checkBox_Script_EmbedNonAL.ToolTip"));
            this.checkBox_Script_EmbedNonAL.UseVisualStyleBackColor = true;
            // 
            // settingsTitle_Script
            // 
            this.settingsTitle_Script.AutoSize = true;
            this.settingsTitle_Script.BackColor = System.Drawing.Color.Transparent;
            this.settingsTitle_Script.ForeColor = System.Drawing.Color.DarkGray;
            this.settingsTitle_Script.Location = new System.Drawing.Point(7, 7);
            this.settingsTitle_Script.Margin = new System.Windows.Forms.Padding(3);
            this.settingsTitle_Script.Name = "settingsTitle_Script";
            this.settingsTitle_Script.Size = new System.Drawing.Size(99, 13);
            this.settingsTitle_Script.TabIndex = 29;
            this.settingsTitle_Script.Text = "SCRIPT PACKAGE";
            // 
            // tabCookGroups
            // 
            this.tabCookGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabCookGroups.ImageIndex = 1;
            this.tabCookGroups.Location = new System.Drawing.Point(0, 0);
            this.tabCookGroups.Name = "tabCookGroups";
            this.tabCookGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabCookGroups.Size = new System.Drawing.Size(388, 296);
            this.tabCookGroups.TabIndex = 1;
            this.tabCookGroups.Text = "COOK GROUPS";
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "cooksettings_general.png");
            this.tabImageList.Images.SetKeyName(1, "cooksettings_groups.png");
            // 
            // tabController
            // 
            this.tabController.DisabledColor = System.Drawing.Color.DarkGray;
            this.tabController.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabController.InactiveColor = System.Drawing.Color.Transparent;
            this.tabController.Location = new System.Drawing.Point(2, 2);
            this.tabController.Name = "tabController";
            this.tabController.ParentTabControl = this.tabControl;
            this.tabController.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.tabController.Size = new System.Drawing.Size(100, 296);
            this.tabController.TabIndex = 0;
            this.tabController.Text = "cuTabController1";
            // 
            // cookSettingsTitleBorder
            // 
            this.cookSettingsTitleBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.cookSettingsTitleBorder.Controls.Add(this.cookSettingsTitleContent);
            this.cookSettingsTitleBorder.Location = new System.Drawing.Point(16, 36);
            this.cookSettingsTitleBorder.Name = "cookSettingsTitleBorder";
            this.cookSettingsTitleBorder.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.cookSettingsTitleBorder.Size = new System.Drawing.Size(220, 30);
            this.cookSettingsTitleBorder.TabIndex = 32;
            // 
            // cookSettingsTitleContent
            // 
            this.cookSettingsTitleContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cookSettingsTitleContent.Controls.Add(this.checkboxCustomCooking);
            this.cookSettingsTitleContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cookSettingsTitleContent.Location = new System.Drawing.Point(2, 2);
            this.cookSettingsTitleContent.Name = "cookSettingsTitleContent";
            this.cookSettingsTitleContent.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.cookSettingsTitleContent.Size = new System.Drawing.Size(216, 28);
            this.cookSettingsTitleContent.TabIndex = 33;
            // 
            // radio_Script_Type_Embed
            // 
            this.radio_Script_Type_Embed.AutoSize = true;
            this.radio_Script_Type_Embed.Location = new System.Drawing.Point(8, 52);
            this.radio_Script_Type_Embed.Name = "radio_Script_Type_Embed";
            this.radio_Script_Type_Embed.Size = new System.Drawing.Size(346, 17);
            this.radio_Script_Type_Embed.TabIndex = 32;
            this.radio_Script_Type_Embed.TabStop = true;
            this.radio_Script_Type_Embed.Text = "Embed - Any referenced Non-AlwaysLoaded classes are embedded.";
            this.radio_Script_Type_Embed.UseVisualStyleBackColor = true;
            // 
            // check_Script_ExcludeBaseALAssets
            // 
            this.check_Script_ExcludeBaseALAssets.AutoSize = true;
            this.check_Script_ExcludeBaseALAssets.Location = new System.Drawing.Point(29, 75);
            this.check_Script_ExcludeBaseALAssets.Margin = new System.Windows.Forms.Padding(24, 3, 3, 3);
            this.check_Script_ExcludeBaseALAssets.Name = "check_Script_ExcludeBaseALAssets";
            this.check_Script_ExcludeBaseALAssets.Size = new System.Drawing.Size(224, 17);
            this.check_Script_ExcludeBaseALAssets.TabIndex = 33;
            this.check_Script_ExcludeBaseALAssets.Text = "Exclude base-game AlwaysLoaded assets";
            this.check_Script_ExcludeBaseALAssets.UseVisualStyleBackColor = true;
            // 
            // radio_Script_Type_NonAL
            // 
            this.radio_Script_Type_NonAL.AutoSize = true;
            this.radio_Script_Type_NonAL.Location = new System.Drawing.Point(8, 98);
            this.radio_Script_Type_NonAL.Name = "radio_Script_Type_NonAL";
            this.radio_Script_Type_NonAL.Size = new System.Drawing.Size(317, 17);
            this.radio_Script_Type_NonAL.TabIndex = 34;
            this.radio_Script_Type_NonAL.TabStop = true;
            this.radio_Script_Type_NonAL.Text = "Content - Custom classes, by default, won\'t be AlwaysLoaded.";
            this.radio_Script_Type_NonAL.UseVisualStyleBackColor = true;
            // 
            // ExtendedCookTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 400);
            this.Controls.Add(this.cookSettingsPanel);
            this.Controls.Add(this.cookSettingsTitleBorder);
            this.IsMaximizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ExtendedCookTools";
            this.Text = "EXTENDED COOK TOOLS";
            this.Controls.SetChildIndex(this.cookSettingsTitleBorder, 0);
            this.Controls.SetChildIndex(this.cookSettingsPanel, 0);
            this.cookSettingsPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.generalSettings_Env.ResumeLayout(false);
            this.generalSettings_Env.PerformLayout();
            this.generalSettings_Script.ResumeLayout(false);
            this.generalSettings_Script.PerformLayout();
            this.group_Script_Type.ResumeLayout(false);
            this.group_Script_Type.PerformLayout();
            this.cookSettingsTitleBorder.ResumeLayout(false);
            this.cookSettingsTitleContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxCustomCooking;
        private GUI.BorderPanel cookSettingsPanel;
        private System.Windows.Forms.Panel cookSettingsTitleBorder;
        private System.Windows.Forms.Panel cookSettingsTitleContent;
        private CUFramework.Controls.Tabs.CUTabController tabController;
        private CUFramework.Controls.Tabs.CUBorderlessTabControl tabControl;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabCookGroups;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.CheckBox checkBox_Script_EmbedNonAL;
        private System.Windows.Forms.Label settingsTitle_Script;
        private System.Windows.Forms.CheckBox checkBox_Script_CookNonAL;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel generalSettings_Script;
        private System.Windows.Forms.Panel generalSettings_Env;
        private System.Windows.Forms.CheckBox checkBox_Env_CookInIsolation;
        private System.Windows.Forms.Label settingsTitle_Env;
        private System.Windows.Forms.RadioButton radio_Script_Type_Default;
        private CUFramework.Controls.CUGroupBox group_Script_Type;
        private System.Windows.Forms.RadioButton radio_Script_Type_Embed;
        private System.Windows.Forms.CheckBox check_Script_ExcludeBaseALAssets;
        private System.Windows.Forms.RadioButton radio_Script_Type_NonAL;
    }
}