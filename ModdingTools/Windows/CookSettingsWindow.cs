using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using CUFramework.Dialogs;
using CUFramework.Windows;
using ModdingTools.Engine;
using ModdingTools.Modding;
using ModdingTools.Settings;

namespace ModdingTools.Windows
{
    public partial class CookSettingsWindow : CUWindow
    {
        public ModObject Mod { get; protected set; }

        public bool NotUserInflicted;

        public CookSettingsWindow(ModObject mod)
        {
            InitializeComponent();

            Mod = mod;

            if (!DesignMode)
            {
                LoadSettings();

                UpdateDependenciesToALWorkaround();
                UpdateDisabledBackground();
                UpdateMoveMethodState();
            }
        }

        public void LoadSettings()
        {
            CookSettings cookSettings = Mod.CookSettings;

            NotUserInflicted = true;

            check_EnableCustomCooking.Checked = cookSettings.EnableCustomCooking;

            check_Env_CookInIsolation.Checked = cookSettings.Env_CookInIsolation;

            combo_Script_LoadScope.SelectedIndex = (int)cookSettings.Script_LoadScope;
            check_Script_ALWorkaround.Checked = cookSettings.Script_AlwaysLoadedWorkaround;
            check_Script_ExcludeBaseALAssets.Checked = cookSettings.Script_ExcludeBaseAlwaysLoadedAssets;

            check_Maps_ExcludeBaseALAssets.Checked = cookSettings.Script_ExcludeBaseAlwaysLoadedAssets;
            textBox_Maps_AudioLanguages.Text = cookSettings.Maps_AudioLanguages;
            check_Maps_DeleteLocINT.Checked = cookSettings.Maps_DeleteLocInt;
            combo_Maps_MoveMethod.SelectedIndex = (int)cookSettings.Maps_MoveMethod;

            NotUserInflicted = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CookSettings cookSettings = Mod.CookSettings;

            cookSettings.EnableCustomCooking = check_EnableCustomCooking.Checked;

            cookSettings.Env_CookInIsolation = check_Env_CookInIsolation.Checked;

            cookSettings.Script_LoadScope = (CookSettings.ScriptLoadScope)combo_Script_LoadScope.SelectedIndex;
            cookSettings.Script_AlwaysLoadedWorkaround = check_Script_ALWorkaround.Checked;
            cookSettings.Script_ExcludeBaseAlwaysLoadedAssets = check_Script_ExcludeBaseALAssets.Checked;

            cookSettings.Script_ExcludeBaseAlwaysLoadedAssets = check_Maps_ExcludeBaseALAssets.Checked;
            cookSettings.Maps_AudioLanguages = textBox_Maps_AudioLanguages.Text;
            cookSettings.Maps_DeleteLocInt = check_Maps_DeleteLocINT.Checked;
            cookSettings.Maps_MoveMethod = (CookSettings.MoveMethod)combo_Maps_MoveMethod.SelectedIndex;

            try
            {
                cookSettings.Save();
            }
            catch (Exception ex)
            {
                CUMessageBox.Show("Could not permanently save cook settings due to error:\n\n" + ex.ToString(), "Permanent save failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_Maps_AudioLanguages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.StartInDefaultBrowser("https://docs.unrealengine.com/udk/Three/LocalizationReference.html#Audio");
        }

        private void check_EnableCustomCooking_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            UpdateDisabledBackground();
        }

        private void check_Script_ALWorkaround_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            UpdateDependenciesToALWorkaround();
            UpdateMoveMethodState();
        }

        private void combo_Script_LoadScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            UpdateMoveMethodState();
        }

        private void check_Maps_ExcludeBaseALAssets_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            UpdateMoveMethodState();
        }

        public void UpdateDependenciesToALWorkaround()
        {
            var color = check_Script_ALWorkaround.Checked ? Color.White : Color.Gray;
            // Kind of a hack, but this looks better than using "Enabled" which uses a hardcoded color.
            // Maybe this could be a class?
            check_Script_ExcludeBaseALAssets.ForeColor = color;
            label_Script_LoadScope.ForeColor = color;
            combo_Script_LoadScope.BackColor = color;
        }

        public void UpdateDisabledBackground()
        {
            Image newBg = check_EnableCustomCooking.Checked ? null : Properties.Resources.disabled_background;
            foreach (TabPage tab in tabControl.TabPages)
            {
                tab.BackgroundImage = newBg;
            }
        }

        public void UpdateMoveMethodState()
        {
            bool mapsRequireMoving = check_Script_ALWorkaround.Checked && combo_Script_LoadScope.SelectedIndex != 0 && check_Maps_ExcludeBaseALAssets.Checked;
            var color = mapsRequireMoving ? Color.White : Color.Gray;
            label_Maps_MoveMethod.ForeColor = color;
            combo_Maps_MoveMethod.BackColor = color;
        }
    }
}
