using ModdingTools.Modding;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UELib;

namespace ModdingTools.Engine
{
    public class CookedContentAnalysis
    {
        public class CookedAsset
        {
            public string AssetType { get; protected set; }
            public string AssetRefPath { get; protected set; }
            public long SizeInBytes { get; protected set; }

            static public bool IsCookedAsset(UExportTableItem exp)
            {
                // Only count forced export objects, i.e. those that were cooked from somewhere else.
                if ((exp.ExportFlags & (uint)UELib.Flags.ExportFlags.ForcedExport) == 0) return false;

                // Don't count the root packages, or, if it somehow happens, import-parented objects.
                if (exp.OuterIndex <= 0) return false;

                // Don't count sub-objects like material nodes.
                if (exp.OuterIndex <= 0 || (((UExportTableItem)exp.Outer).Class?.ObjectName.ToString().ToUpperInvariant() ?? "") != "PACKAGE") return false;

                // Don't count groupings, AKA categories, AKA sub-packages.
                if ((exp.Class?.ObjectName.ToString().ToUpperInvariant() ?? "") == "PACKAGE") return false;

                return true;
            }

            public CookedAsset(UExportTableItem exp)
            {
                AssetType = exp.Class?.ObjectName ?? "Class";
                AssetRefPath = exp.GetReferencePath();
                SizeInBytes = exp.SerialSize;
            }
        };

        public class AnalysisPackage
        {
            public string PackagePath { get; protected set; }

            public Exception Error { get; protected set; }

            public List<CookedAsset> ReferencedAssets { get; protected set; }

            public AnalysisPackage(string packagePath, string friendlyPath, Dictionary<string, CookedAsset> AllCookedAssetsInMod, Action<string> setStatusAct)
            {
                PackagePath = packagePath;
                UnrealPackage loadedPackage = null;
                string uncompressedPath = null;

                try
                {
                    loadedPackage = UnrealLoader.LoadPackage(packagePath);

                    // This should return true 99.999% of the time, but checking just in case.
                    if (DecompressFacade.IsPackageCompressed(loadedPackage))
                    {
                        setStatusAct($"Decompressing and analysing package: {friendlyPath}");

                        uncompressedPath = DecompressFacade.DecompressPackage(packagePath, DecompressFacade.GetDecompressCacheDir());

                        loadedPackage.Dispose();
                        loadedPackage = UnrealLoader.LoadPackage(uncompressedPath);
                    }
                    else
                    {
                        setStatusAct($"Analysing decompressed package: {friendlyPath}");
                    }

                    // Time to go through the package's exports and see which assets are present.
                    // Don't need to InitializePackage here, since we don't need the constructed objects (for now).
                    CookedAsset asset;
                    string path;
                    ReferencedAssets = new List<CookedAsset>();
                    foreach (var exp in loadedPackage.Exports)
                    {
                        if (!CookedAsset.IsCookedAsset(exp)) continue;

                        path = exp.GetPath().ToUpperInvariant();
                        if (!AllCookedAssetsInMod.TryGetValue(path, out asset))
                        {
                            asset = new CookedAsset(exp);
                            AllCookedAssetsInMod.Add(path, asset);
                        }
                        ReferencedAssets.Add(asset);
                    }
                    ReferencedAssets.TrimExcess();

                    loadedPackage.Dispose();
                }
                catch (Exception e)
                {
                    Error = e;

                    if (loadedPackage != null)
                    {
                        loadedPackage.Dispose();
                    }
                }

                if (uncompressedPath != null)
                {
                    // Delete the decompressed file ASAP, not at the end of the analysis! Having all decompressed packages
                    // in storage all at once can easily add up to an unreasonable size for larger mods.
                    try
                    {
                        File.Delete(uncompressedPath);
                    }
                    catch { }
                }
            }

            public bool IsValid()
            {
                return Error == null;
            }
        };

        public ModObject Mod { get; protected set; }

        public Dictionary<string, CookedAsset> Assets { get; protected set; } = new Dictionary<string, CookedAsset>();
        public List<AnalysisPackage> Packages { get; protected set; } = null;

        public CookedContentAnalysis(ModObject mod)
        {
            Mod = mod;
        }

        public void RunAnalysis(Action<string> setStatusAct, Action<int> setProgressAct)
        {
            DecompressFacade.EnsureDecompressCache();

            var path = Mod.GetCookedDir();
            if (Directory.Exists(path))
            {
                List<string> allCookedPackageFiles = new List<string>();

                allCookedPackageFiles.AddRange(GetFilesByType(path, "*.u"));
                allCookedPackageFiles.AddRange(GetFilesByType(path, "*.upk"));
                allCookedPackageFiles.AddRange(GetFilesByType(path, "*.umap"));

                Packages = new List<AnalysisPackage>(allCookedPackageFiles.Count);

                int packagesAnalysed = 0;
                foreach (var packagePath in allCookedPackageFiles)
                {
                    Packages.Add(new AnalysisPackage(packagePath, GetRelativePath(packagePath, Mod.RootPath), Assets, setStatusAct));

                    packagesAnalysed++;
                    setProgressAct((int)(100f * packagesAnalysed / allCookedPackageFiles.Count));
                }
            }

            setStatusAct("Done!");

            // We got what we wanted from the decompressed packages. Just in case there's some leftovers, trash them.
            DecompressFacade.ClearDecompressCache();

            setStatusAct("");
        }

        static public string[] GetFilesByType(string path, string type)
        {
            // The engine seems to be able to read subfolders in CookedPC, so do this recursively.
            return Directory.GetFiles(path, type, SearchOption.AllDirectories);
        }

        // Kinda ugly, but works well enough under normal circumstances.
        static public string GetRelativePath(string subPath, string basePath)
        {
            if (subPath.Substring(0, basePath.Length) == basePath)
                return subPath.Substring(basePath.Length);
            return subPath;
        }
    }
}
