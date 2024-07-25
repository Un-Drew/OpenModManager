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

        public CookSettings TempCookSettings;

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
            CookSettings modCookSettings = Mod.CookSettings;

            // Give it a reference to the mod as well, so we can later attempt saving it on its own BEFORE applying it globally.
            TempCookSettings = new CookSettings(modCookSettings.Mod);
            TempCookSettings.CopySettingsFrom(modCookSettings);

            NotUserInflicted = true;

            check_EnableCustomCooking.Checked = TempCookSettings.EnableCustomCooking;

            check_Common_CookInIsolation.Checked = TempCookSettings.Common_CookInIsolation;
            check_Common_ExcludeBaseALAssets.Checked = TempCookSettings.Common_ExcludeBaseAlwaysLoadedAssets;

            combo_Script_LoadScope.SelectedIndex = (int)TempCookSettings.Script_LoadScope;
            check_Script_ALWorkaround.Checked = TempCookSettings.Script_AlwaysLoadedWorkaround;

            textBox_Maps_AudioLanguages.Text = TempCookSettings.Maps_AudioLanguages;
            check_Maps_DeleteLocINT.Checked = TempCookSettings.Maps_DeleteLocInt;
            combo_Maps_MoveMethod.SelectedIndex = (int)TempCookSettings.Maps_MoveMethod;

            NotUserInflicted = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                TempCookSettings.Save();
            }
            catch (Exception ex)
            {
                CUMessageBox.Show("Could not save cook settings due to error:\n\n" + ex.ToString(), "Save failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mod.CookSettings.CopySettingsFrom(TempCookSettings);

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
            TempCookSettings.EnableCustomCooking = check_EnableCustomCooking.Checked;
            UpdateDisabledBackground();
        }

        private void check_Common_CookInIsolation_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            TempCookSettings.Common_CookInIsolation = check_Common_CookInIsolation.Checked;
        }

        private void check_Common_ExcludeBaseALAssets_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            TempCookSettings.Common_ExcludeBaseAlwaysLoadedAssets = check_Common_ExcludeBaseALAssets.Checked;
        }

        private void check_Script_ALWorkaround_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            TempCookSettings.Script_AlwaysLoadedWorkaround = check_Script_ALWorkaround.Checked;
            UpdateDependenciesToALWorkaround();
            UpdateMoveMethodState();
        }

        private void combo_Script_LoadScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            TempCookSettings.Script_LoadScope = (CookSettings.ScriptLoadScope)combo_Script_LoadScope.SelectedIndex;
            UpdateMoveMethodState();
        }

        private void textBox_Maps_AudioLanguages_Leave(object sender, EventArgs e)
        {
            ConfirmedAudioLanguages();
        }

        private void textBox_Maps_AudioLanguages_KeyUp(object sender, KeyEventArgs e)
        {
            ConfirmedAudioLanguages();
        }

        public void ConfirmedAudioLanguages()
        {
            TempCookSettings.Maps_AudioLanguages = textBox_Maps_AudioLanguages.Text;
        }

        private void check_Maps_DeleteLocINT_CheckedChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            TempCookSettings.Maps_DeleteLocInt = check_Maps_DeleteLocINT.Checked;
        }

        private void combo_Maps_MoveMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotUserInflicted) return;
            TempCookSettings.Maps_MoveMethod = (CookSettings.MoveMethod)combo_Maps_MoveMethod.SelectedIndex;
        }

        public void UpdateDependenciesToALWorkaround()
        {
            var color = check_Script_ALWorkaround.Checked ? Color.White : Color.Gray;
            // Kind of a hack, but this looks better than using "Enabled" which uses a hardcoded color.
            // Maybe this could be a class?
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
            // Always false, for now. But will probably be necessary when Cook Groups are implemented.
            // ToDo: Since the general settings don't affect this anymore, it might be better to move this to the cook groups tab.
            bool mapsRequireMoving = false;
            var color = mapsRequireMoving ? Color.White : Color.Gray;
            label_Maps_MoveMethod.ForeColor = color;
            combo_Maps_MoveMethod.BackColor = color;
        }
    }
}
