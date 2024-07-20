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

namespace ModdingTools.Windows
{
    public partial class ExtendedCookTools : CUWindow
    {
        public ModObject Mod { get; protected set; }

        public ExtendedCookTools(ModObject mod)
        {
            InitializeComponent();

            Mod = mod;


        }

        private void label_Maps_AudioLanguages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.StartInDefaultBrowser("https://docs.unrealengine.com/udk/Three/LocalizationReference.html#Audio");
        }
    }
}
