namespace ModdingTools.Windows
{
    partial class CookSettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CookSettingsWindow));
            this.check_EnableCustomCooking = new System.Windows.Forms.CheckBox();
            this.cookSettingsPanel = new ModdingTools.GUI.BorderPanel();
            this.tabControl = new CUFramework.Controls.Tabs.CUBorderlessTabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.generalSettings_Maps = new System.Windows.Forms.Panel();
            this.check_Maps_DeleteLocINT = new System.Windows.Forms.CheckBox();
            this.textBox_Maps_AudioLanguages = new CUFramework.Controls.CUTextBox();
            this.label_Maps_AudioLanguages = new System.Windows.Forms.LinkLabel();
            this.check_Maps_ExcludeBaseALAssets = new System.Windows.Forms.CheckBox();
            this.settingsTitle_Maps = new System.Windows.Forms.Label();
            this.generalSettings_Script = new System.Windows.Forms.Panel();
            this.combo_Script_LoadScope = new System.Windows.Forms.ComboBox();
            this.label_Script_LoadScope = new System.Windows.Forms.Label();
            this.check_Script_ExcludeBaseALAssets = new System.Windows.Forms.CheckBox();
            this.nestLevel2 = new System.Windows.Forms.Panel();
            this.nestLine4 = new System.Windows.Forms.Panel();
            this.nestLine3 = new System.Windows.Forms.Panel();
            this.nestLevel1 = new System.Windows.Forms.Panel();
            this.nestLine2 = new System.Windows.Forms.Panel();
            this.nestLine1 = new System.Windows.Forms.Panel();
            this.check_Script_ALWorkaround = new System.Windows.Forms.CheckBox();
            this.settingsTitle_Script = new System.Windows.Forms.Label();
            this.generalSettings_Env = new System.Windows.Forms.Panel();
            this.check_Env_CookInIsolation = new System.Windows.Forms.CheckBox();
            this.settingsTitle_Env = new System.Windows.Forms.Label();
            this.tabCookGroups = new System.Windows.Forms.TabPage();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabController = new CUFramework.Controls.Tabs.CUTabController();
            this.cookSettingsTitleBorder = new System.Windows.Forms.Panel();
            this.cookSettingsTitleContent = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSave = new CUFramework.Controls.CUButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new CUFramework.Controls.CUButton();
            this.label_Maps_MoveMethod = new System.Windows.Forms.Label();
            this.combo_Maps_MoveMethod = new System.Windows.Forms.ComboBox();
            this.cookSettingsPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.generalSettings_Maps.SuspendLayout();
            this.generalSettings_Script.SuspendLayout();
            this.nestLevel2.SuspendLayout();
            this.nestLevel1.SuspendLayout();
            this.generalSettings_Env.SuspendLayout();
            this.cookSettingsTitleBorder.SuspendLayout();
            this.cookSettingsTitleContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // check_EnableCustomCooking
            // 
            this.check_EnableCustomCooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.check_EnableCustomCooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_EnableCustomCooking.Location = new System.Drawing.Point(6, 0);
            this.check_EnableCustomCooking.Name = "check_EnableCustomCooking";
            this.check_EnableCustomCooking.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.check_EnableCustomCooking.Size = new System.Drawing.Size(210, 28);
            this.check_EnableCustomCooking.TabIndex = 30;
            this.check_EnableCustomCooking.Text = "ENABLE CUSTOM COOKING";
            this.toolTip.SetToolTip(this.check_EnableCustomCooking, "Enables custom cook functionality. This is required for any of the options below." +
        "\r\nIf disabled, the mod will be cooked normally, with no extra fixes.");
            this.check_EnableCustomCooking.UseVisualStyleBackColor = false;
            this.check_EnableCustomCooking.CheckedChanged += new System.EventHandler(this.check_EnableCustomCooking_CheckedChanged);
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
            this.cookSettingsPanel.Size = new System.Drawing.Size(442, 329);
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
            this.tabControl.Size = new System.Drawing.Size(338, 325);
            this.tabControl.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabGeneral.Controls.Add(this.generalSettings_Maps);
            this.tabGeneral.Controls.Add(this.generalSettings_Script);
            this.tabGeneral.Controls.Add(this.generalSettings_Env);
            this.tabGeneral.ImageIndex = 0;
            this.tabGeneral.Location = new System.Drawing.Point(0, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(4);
            this.tabGeneral.Size = new System.Drawing.Size(338, 325);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "GENERAL";
            // 
            // generalSettings_Maps
            // 
            this.generalSettings_Maps.BackColor = System.Drawing.Color.Transparent;
            this.generalSettings_Maps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generalSettings_Maps.Controls.Add(this.combo_Maps_MoveMethod);
            this.generalSettings_Maps.Controls.Add(this.label_Maps_MoveMethod);
            this.generalSettings_Maps.Controls.Add(this.check_Maps_DeleteLocINT);
            this.generalSettings_Maps.Controls.Add(this.textBox_Maps_AudioLanguages);
            this.generalSettings_Maps.Controls.Add(this.label_Maps_AudioLanguages);
            this.generalSettings_Maps.Controls.Add(this.check_Maps_ExcludeBaseALAssets);
            this.generalSettings_Maps.Controls.Add(this.settingsTitle_Maps);
            this.generalSettings_Maps.Location = new System.Drawing.Point(7, 171);
            this.generalSettings_Maps.Name = "generalSettings_Maps";
            this.generalSettings_Maps.Padding = new System.Windows.Forms.Padding(4);
            this.generalSettings_Maps.Size = new System.Drawing.Size(324, 147);
            this.generalSettings_Maps.TabIndex = 33;
            // 
            // check_Maps_DeleteLocINT
            // 
            this.check_Maps_DeleteLocINT.AutoSize = true;
            this.check_Maps_DeleteLocINT.Location = new System.Drawing.Point(7, 94);
            this.check_Maps_DeleteLocINT.Name = "check_Maps_DeleteLocINT";
            this.check_Maps_DeleteLocINT.Size = new System.Drawing.Size(230, 17);
            this.check_Maps_DeleteLocINT.TabIndex = 41;
            this.check_Maps_DeleteLocINT.Text = "Delete auto-generated LOC_INT packages";
            this.toolTip.SetToolTip(this.check_Maps_DeleteLocINT, resources.GetString("check_Maps_DeleteLocINT.ToolTip"));
            this.check_Maps_DeleteLocINT.UseVisualStyleBackColor = true;
            // 
            // textBox_Maps_AudioLanguages
            // 
            this.textBox_Maps_AudioLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.textBox_Maps_AudioLanguages.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox_Maps_AudioLanguages.ForeColor = System.Drawing.Color.White;
            this.textBox_Maps_AudioLanguages.Location = new System.Drawing.Point(7, 68);
            this.textBox_Maps_AudioLanguages.Name = "textBox_Maps_AudioLanguages";
            this.textBox_Maps_AudioLanguages.Size = new System.Drawing.Size(306, 20);
            this.textBox_Maps_AudioLanguages.TabIndex = 40;
            this.toolTip.SetToolTip(this.textBox_Maps_AudioLanguages, "Languages in which to cook the mod\'s audio, separated by \'+\' characters.\r\nFor exa" +
        "mple: INT+FRA+ITA\r\nIf blank, the mod won\'t use localization cooking.");
            // 
            // label_Maps_AudioLanguages
            // 
            this.label_Maps_AudioLanguages.AutoSize = true;
            this.label_Maps_AudioLanguages.LinkArea = new System.Windows.Forms.LinkArea(30, 17);
            this.label_Maps_AudioLanguages.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.label_Maps_AudioLanguages.Location = new System.Drawing.Point(7, 49);
            this.label_Maps_AudioLanguages.Margin = new System.Windows.Forms.Padding(3);
            this.label_Maps_AudioLanguages.Name = "label_Maps_AudioLanguages";
            this.label_Maps_AudioLanguages.Size = new System.Drawing.Size(257, 17);
            this.label_Maps_AudioLanguages.TabIndex = 34;
            this.label_Maps_AudioLanguages.TabStop = true;
            this.label_Maps_AudioLanguages.Text = "Audio localization languages (see documentation):";
            this.label_Maps_AudioLanguages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_Maps_AudioLanguages.UseCompatibleTextRendering = true;
            this.label_Maps_AudioLanguages.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label_Maps_AudioLanguages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.label_Maps_AudioLanguages_LinkClicked);
            // 
            // check_Maps_ExcludeBaseALAssets
            // 
            this.check_Maps_ExcludeBaseALAssets.AutoSize = true;
            this.check_Maps_ExcludeBaseALAssets.Location = new System.Drawing.Point(7, 26);
            this.check_Maps_ExcludeBaseALAssets.Name = "check_Maps_ExcludeBaseALAssets";
            this.check_Maps_ExcludeBaseALAssets.Size = new System.Drawing.Size(224, 17);
            this.check_Maps_ExcludeBaseALAssets.TabIndex = 0;
            this.check_Maps_ExcludeBaseALAssets.Text = "Exclude base-game AlwaysLoaded assets";
            this.toolTip.SetToolTip(this.check_Maps_ExcludeBaseALAssets, resources.GetString("check_Maps_ExcludeBaseALAssets.ToolTip"));
            this.check_Maps_ExcludeBaseALAssets.UseVisualStyleBackColor = true;
            this.check_Maps_ExcludeBaseALAssets.CheckedChanged += new System.EventHandler(this.check_Maps_ExcludeBaseALAssets_CheckedChanged);
            // 
            // settingsTitle_Maps
            // 
            this.settingsTitle_Maps.AutoSize = true;
            this.settingsTitle_Maps.BackColor = System.Drawing.Color.Transparent;
            this.settingsTitle_Maps.ForeColor = System.Drawing.Color.DarkGray;
            this.settingsTitle_Maps.Location = new System.Drawing.Point(7, 7);
            this.settingsTitle_Maps.Margin = new System.Windows.Forms.Padding(3);
            this.settingsTitle_Maps.Name = "settingsTitle_Maps";
            this.settingsTitle_Maps.Size = new System.Drawing.Size(37, 13);
            this.settingsTitle_Maps.TabIndex = 29;
            this.settingsTitle_Maps.Text = "MAPS";
            // 
            // generalSettings_Script
            // 
            this.generalSettings_Script.BackColor = System.Drawing.Color.Transparent;
            this.generalSettings_Script.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generalSettings_Script.Controls.Add(this.combo_Script_LoadScope);
            this.generalSettings_Script.Controls.Add(this.label_Script_LoadScope);
            this.generalSettings_Script.Controls.Add(this.check_Script_ExcludeBaseALAssets);
            this.generalSettings_Script.Controls.Add(this.nestLevel2);
            this.generalSettings_Script.Controls.Add(this.nestLevel1);
            this.generalSettings_Script.Controls.Add(this.check_Script_ALWorkaround);
            this.generalSettings_Script.Controls.Add(this.settingsTitle_Script);
            this.generalSettings_Script.Location = new System.Drawing.Point(7, 63);
            this.generalSettings_Script.Name = "generalSettings_Script";
            this.generalSettings_Script.Padding = new System.Windows.Forms.Padding(4);
            this.generalSettings_Script.Size = new System.Drawing.Size(324, 102);
            this.generalSettings_Script.TabIndex = 31;
            // 
            // combo_Script_LoadScope
            // 
            this.combo_Script_LoadScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Script_LoadScope.FormattingEnabled = true;
            this.combo_Script_LoadScope.Items.AddRange(new object[] {
            "AlwaysLoadad",
            "Non-AlwaysLoaded",
            "Auto"});
            this.combo_Script_LoadScope.Location = new System.Drawing.Point(145, 72);
            this.combo_Script_LoadScope.Name = "combo_Script_LoadScope";
            this.combo_Script_LoadScope.Size = new System.Drawing.Size(170, 21);
            this.combo_Script_LoadScope.TabIndex = 38;
            this.combo_Script_LoadScope.Text = "AlwaysLoaded";
            this.toolTip.SetToolTip(this.combo_Script_LoadScope, resources.GetString("combo_Script_LoadScope.ToolTip"));
            this.combo_Script_LoadScope.SelectedIndexChanged += new System.EventHandler(this.combo_Script_LoadScope_SelectedIndexChanged);
            // 
            // label_Script_LoadScope
            // 
            this.label_Script_LoadScope.Location = new System.Drawing.Point(26, 72);
            this.label_Script_LoadScope.Margin = new System.Windows.Forms.Padding(3);
            this.label_Script_LoadScope.Name = "label_Script_LoadScope";
            this.label_Script_LoadScope.Size = new System.Drawing.Size(110, 21);
            this.label_Script_LoadScope.TabIndex = 37;
            this.label_Script_LoadScope.Text = "Load scope:";
            this.label_Script_LoadScope.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label_Script_LoadScope, resources.GetString("label_Script_LoadScope.ToolTip"));
            // 
            // check_Script_ExcludeBaseALAssets
            // 
            this.check_Script_ExcludeBaseALAssets.AutoSize = true;
            this.check_Script_ExcludeBaseALAssets.Location = new System.Drawing.Point(26, 49);
            this.check_Script_ExcludeBaseALAssets.Name = "check_Script_ExcludeBaseALAssets";
            this.check_Script_ExcludeBaseALAssets.Size = new System.Drawing.Size(224, 17);
            this.check_Script_ExcludeBaseALAssets.TabIndex = 33;
            this.check_Script_ExcludeBaseALAssets.Text = "Exclude base-game AlwaysLoaded assets";
            this.toolTip.SetToolTip(this.check_Script_ExcludeBaseALAssets, resources.GetString("check_Script_ExcludeBaseALAssets.ToolTip"));
            this.check_Script_ExcludeBaseALAssets.UseVisualStyleBackColor = false;
            // 
            // nestLevel2
            // 
            this.nestLevel2.BackColor = System.Drawing.Color.Transparent;
            this.nestLevel2.Controls.Add(this.nestLine4);
            this.nestLevel2.Controls.Add(this.nestLine3);
            this.nestLevel2.Location = new System.Drawing.Point(12, 57);
            this.nestLevel2.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.nestLevel2.Name = "nestLevel2";
            this.nestLevel2.Size = new System.Drawing.Size(11, 27);
            this.nestLevel2.TabIndex = 37;
            // 
            // nestLine4
            // 
            this.nestLine4.BackColor = System.Drawing.Color.Gray;
            this.nestLine4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nestLine4.Location = new System.Drawing.Point(1, 26);
            this.nestLine4.Margin = new System.Windows.Forms.Padding(0);
            this.nestLine4.Name = "nestLine4";
            this.nestLine4.Size = new System.Drawing.Size(10, 1);
            this.nestLine4.TabIndex = 35;
            // 
            // nestLine3
            // 
            this.nestLine3.BackColor = System.Drawing.Color.Gray;
            this.nestLine3.Dock = System.Windows.Forms.DockStyle.Left;
            this.nestLine3.Location = new System.Drawing.Point(0, 0);
            this.nestLine3.Margin = new System.Windows.Forms.Padding(0);
            this.nestLine3.Name = "nestLine3";
            this.nestLine3.Size = new System.Drawing.Size(1, 27);
            this.nestLine3.TabIndex = 34;
            // 
            // nestLevel1
            // 
            this.nestLevel1.BackColor = System.Drawing.Color.Transparent;
            this.nestLevel1.Controls.Add(this.nestLine2);
            this.nestLevel1.Controls.Add(this.nestLine1);
            this.nestLevel1.Location = new System.Drawing.Point(12, 46);
            this.nestLevel1.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.nestLevel1.Name = "nestLevel1";
            this.nestLevel1.Size = new System.Drawing.Size(11, 11);
            this.nestLevel1.TabIndex = 36;
            // 
            // nestLine2
            // 
            this.nestLine2.BackColor = System.Drawing.Color.Gray;
            this.nestLine2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nestLine2.Location = new System.Drawing.Point(1, 10);
            this.nestLine2.Margin = new System.Windows.Forms.Padding(0);
            this.nestLine2.Name = "nestLine2";
            this.nestLine2.Size = new System.Drawing.Size(10, 1);
            this.nestLine2.TabIndex = 35;
            // 
            // nestLine1
            // 
            this.nestLine1.BackColor = System.Drawing.Color.Gray;
            this.nestLine1.Dock = System.Windows.Forms.DockStyle.Left;
            this.nestLine1.Location = new System.Drawing.Point(0, 0);
            this.nestLine1.Margin = new System.Windows.Forms.Padding(0);
            this.nestLine1.Name = "nestLine1";
            this.nestLine1.Size = new System.Drawing.Size(1, 11);
            this.nestLine1.TabIndex = 34;
            // 
            // check_Script_ALWorkaround
            // 
            this.check_Script_ALWorkaround.AutoSize = true;
            this.check_Script_ALWorkaround.Location = new System.Drawing.Point(7, 26);
            this.check_Script_ALWorkaround.Name = "check_Script_ALWorkaround";
            this.check_Script_ALWorkaround.Size = new System.Drawing.Size(154, 17);
            this.check_Script_ALWorkaround.TabIndex = 0;
            this.check_Script_ALWorkaround.Text = "AlwaysLoaded workaround";
            this.toolTip.SetToolTip(this.check_Script_ALWorkaround, resources.GetString("check_Script_ALWorkaround.ToolTip"));
            this.check_Script_ALWorkaround.UseVisualStyleBackColor = true;
            this.check_Script_ALWorkaround.CheckedChanged += new System.EventHandler(this.check_Script_ALWorkaround_CheckedChanged);
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
            // generalSettings_Env
            // 
            this.generalSettings_Env.BackColor = System.Drawing.Color.Transparent;
            this.generalSettings_Env.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generalSettings_Env.Controls.Add(this.check_Env_CookInIsolation);
            this.generalSettings_Env.Controls.Add(this.settingsTitle_Env);
            this.generalSettings_Env.Location = new System.Drawing.Point(7, 7);
            this.generalSettings_Env.Name = "generalSettings_Env";
            this.generalSettings_Env.Padding = new System.Windows.Forms.Padding(4);
            this.generalSettings_Env.Size = new System.Drawing.Size(324, 50);
            this.generalSettings_Env.TabIndex = 32;
            // 
            // check_Env_CookInIsolation
            // 
            this.check_Env_CookInIsolation.AutoSize = true;
            this.check_Env_CookInIsolation.Location = new System.Drawing.Point(7, 26);
            this.check_Env_CookInIsolation.Name = "check_Env_CookInIsolation";
            this.check_Env_CookInIsolation.Size = new System.Drawing.Size(105, 17);
            this.check_Env_CookInIsolation.TabIndex = 0;
            this.check_Env_CookInIsolation.Text = "Cook in islolation";
            this.toolTip.SetToolTip(this.check_Env_CookInIsolation, "If enabled, temporarily disables all other local mods while cooking this mod. Cou" +
        "ld\r\nbe used to speed up the cooking process, as well as to avoid AlwaysLoaded is" +
        "sues\r\ncaused by other mods.");
            this.check_Env_CookInIsolation.UseVisualStyleBackColor = true;
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
            // tabCookGroups
            // 
            this.tabCookGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabCookGroups.ImageIndex = 1;
            this.tabCookGroups.Location = new System.Drawing.Point(0, 0);
            this.tabCookGroups.Name = "tabCookGroups";
            this.tabCookGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabCookGroups.Size = new System.Drawing.Size(338, 296);
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
            this.tabController.Size = new System.Drawing.Size(100, 325);
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
            this.cookSettingsTitleContent.Controls.Add(this.check_EnableCustomCooking);
            this.cookSettingsTitleContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cookSettingsTitleContent.Location = new System.Drawing.Point(2, 2);
            this.cookSettingsTitleContent.Name = "cookSettingsTitleContent";
            this.cookSettingsTitleContent.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.cookSettingsTitleContent.Size = new System.Drawing.Size(216, 28);
            this.cookSettingsTitleContent.TabIndex = 33;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 30000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.NoFocus = false;
            this.buttonSave.Size = new System.Drawing.Size(217, 26);
            this.buttonSave.TabIndex = 33;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 396);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 32);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(226, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NoFocus = false;
            this.buttonCancel.Size = new System.Drawing.Size(217, 26);
            this.buttonCancel.TabIndex = 34;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label_Maps_MoveMethod
            // 
            this.label_Maps_MoveMethod.Location = new System.Drawing.Point(7, 117);
            this.label_Maps_MoveMethod.Margin = new System.Windows.Forms.Padding(3);
            this.label_Maps_MoveMethod.Name = "label_Maps_MoveMethod";
            this.label_Maps_MoveMethod.Size = new System.Drawing.Size(130, 21);
            this.label_Maps_MoveMethod.TabIndex = 42;
            this.label_Maps_MoveMethod.Text = "Move method:";
            this.label_Maps_MoveMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.label_Maps_MoveMethod, "Some combinations of settings may require temporarily moving your maps to a\r\nsepa" +
        "rate location, while cooking. This setting controls how these files are \'moved\'." +
        "");
            // 
            // combo_Maps_MoveMethod
            // 
            this.combo_Maps_MoveMethod.FormattingEnabled = true;
            this.combo_Maps_MoveMethod.Items.AddRange(new object[] {
            "COPY (safer)",
            "MOVE (faster)"});
            this.combo_Maps_MoveMethod.Location = new System.Drawing.Point(145, 117);
            this.combo_Maps_MoveMethod.Name = "combo_Maps_MoveMethod";
            this.combo_Maps_MoveMethod.Size = new System.Drawing.Size(170, 21);
            this.combo_Maps_MoveMethod.TabIndex = 43;
            this.combo_Maps_MoveMethod.Text = "COPY (safer)";
            this.toolTip.SetToolTip(this.combo_Maps_MoveMethod, resources.GetString("combo_Maps_MoveMethod.ToolTip"));
            // 
            // CookSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 430);
            this.ControlBoxVisible = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cookSettingsPanel);
            this.Controls.Add(this.cookSettingsTitleBorder);
            this.IsCloseButtonEnabled = false;
            this.IsMaximizeButtonEnabled = false;
            this.IsMinimizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CookSettingsWindow";
            this.Text = "CUSTOM COOK SETTINGS";
            this.Controls.SetChildIndex(this.cookSettingsTitleBorder, 0);
            this.Controls.SetChildIndex(this.cookSettingsPanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.cookSettingsPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.generalSettings_Maps.ResumeLayout(false);
            this.generalSettings_Maps.PerformLayout();
            this.generalSettings_Script.ResumeLayout(false);
            this.generalSettings_Script.PerformLayout();
            this.nestLevel2.ResumeLayout(false);
            this.nestLevel1.ResumeLayout(false);
            this.generalSettings_Env.ResumeLayout(false);
            this.generalSettings_Env.PerformLayout();
            this.cookSettingsTitleBorder.ResumeLayout(false);
            this.cookSettingsTitleContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox check_EnableCustomCooking;
        private GUI.BorderPanel cookSettingsPanel;
        private System.Windows.Forms.Panel cookSettingsTitleBorder;
        private System.Windows.Forms.Panel cookSettingsTitleContent;
        private CUFramework.Controls.Tabs.CUTabController tabController;
        private CUFramework.Controls.Tabs.CUBorderlessTabControl tabControl;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabCookGroups;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.CheckBox check_Script_ALWorkaround;
        private System.Windows.Forms.Label settingsTitle_Script;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel generalSettings_Script;
        private System.Windows.Forms.Panel generalSettings_Env;
        private System.Windows.Forms.CheckBox check_Env_CookInIsolation;
        private System.Windows.Forms.Label settingsTitle_Env;
        private System.Windows.Forms.CheckBox check_Script_ExcludeBaseALAssets;
        private System.Windows.Forms.Panel nestLevel1;
        private System.Windows.Forms.Panel nestLine2;
        private System.Windows.Forms.Panel nestLine1;
        private System.Windows.Forms.Label label_Script_LoadScope;
        private System.Windows.Forms.ComboBox combo_Script_LoadScope;
        private System.Windows.Forms.Panel generalSettings_Maps;
        private System.Windows.Forms.CheckBox check_Maps_ExcludeBaseALAssets;
        private System.Windows.Forms.Label settingsTitle_Maps;
        private CUFramework.Controls.CUTextBox textBox_Maps_AudioLanguages;
        private System.Windows.Forms.LinkLabel label_Maps_AudioLanguages;
        private System.Windows.Forms.CheckBox check_Maps_DeleteLocINT;
        private CUFramework.Controls.CUButton buttonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CUFramework.Controls.CUButton buttonCancel;
        private System.Windows.Forms.Panel nestLevel2;
        private System.Windows.Forms.Panel nestLine4;
        private System.Windows.Forms.Panel nestLine3;
        private System.Windows.Forms.Label label_Maps_MoveMethod;
        private System.Windows.Forms.ComboBox combo_Maps_MoveMethod;
    }
}