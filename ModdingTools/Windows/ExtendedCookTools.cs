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
        static CookedContentAnalysis BuildingAnalysis = null;

        public ModObject Mod { get; protected set; }

        public ExtendedCookTools(ModObject mod)
        {
            InitializeComponent();

            Mod = mod;
        }

        private void cuButtonContentAnalysis_Click(object sender, EventArgs e)
        {
            if (BuildingAnalysis != null) return;

            string decompressorPath = DecompressFacade.GetDecompressorPath();
            if (!File.Exists(decompressorPath))
            {
                var result = CUMessageBox.Show(
                    "This tool requires Glidor's Unreal Package Decompressor."
                    + " Once downloaded, place decompress.exe into the mod manager's root folder.\n\n"
                    + "Would you like to go to the download page?",
                    "Missing decompress.exe!", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    Utils.StartInDefaultBrowser("https://www.gildor.org/downloads");
                }
                return;
            }

            BuildingAnalysis = new CookedContentAnalysis(Mod);

            // TODO: Maybe it'd be better if this was temporarily hidden instead?
            // Although 4 forms opended at once could get cluttered. Idk.
            Close();

            Task.Factory.StartNew(() =>
            {
                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    ModProperties.TemporaryHideAllPropertiesWindows();
                }));

                MainWindow.Instance.SetCard(MainWindow.CardControllerTabs.Worker);

                BuildingAnalysis.RunAnalysis(MainWindow.Instance.GuiWorker.SetStatus, (p) => MainWindow.Instance.GuiWorker.SetProgress(p));

                MainWindow.Instance.SetCard(MainWindow.CardControllerTabs.Mods);

                MainWindow.Instance.Invoke(new MethodInvoker(() => {
                    ModProperties.RestoreTemporaryHiddenPropertiesWindows();

                    var form = new CookedContentAnalysisResults(BuildingAnalysis);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Show();

                    BuildingAnalysis = null;
                }));
            });
        }

        private void cuButtonContentAnalysis_WatDisDo_Click(object sender, EventArgs e)
        {
            CUMessageBox.Show(
                "This tool:"
                + "\n    - Shows which assets have been included into this mod's cooked packages."
                + "\n    - Shows which assets are shared by (duplicated in) multiple map packages."
                + "\n    - Shows tips on how to optimize storage usage.",
                "Info"
            );
        }
    }
}
