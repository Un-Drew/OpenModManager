using ModdingTools.Modding;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using UELib;

namespace ModdingTools.Engine
{
    public class CookedContentAnalysis
    {
        public class CookedObject
        {
            public CookedObject Outer { get; protected set; }
            public List<CookedObject> Children { get; protected set; } = new List<CookedObject>();

            public List<AnalysisPackage> ReferencedBy { get; protected set; } = new List<AnalysisPackage>();
            
            public string ObjectName { get; protected set; }
            public string ObjectType { get; protected set; }
            public string ObjectRefPath { get; protected set; }
            public long SizeInBytes { get; protected set; }

            /// <summary>
            /// True = A cooked asset/class, or a sub-object of a cooked asset. False = Package/grouping.
            /// </summary>
            public bool bIsContent { get; protected set; }
            /// <summary>
            /// If true, this cooked content is directly nested in a package or grouping. Implies bIsContent.
            /// </summary>
            public bool bIsAsset { get; protected set; }

            static public bool IsCookedContent(UExportTableItem exp)
            {
                // Only count forced export objects, i.e. those that were cooked from somewhere else.
                if ((exp.ExportFlags & (uint)UELib.Flags.ExportFlags.ForcedExport) == 0) return false;

                // Don't count the root packages, or, if it somehow happens, import-parented objects.
                if (exp.OuterIndex <= 0) return false;

                // Don't count groupings, AKA categories, AKA sub-packages.
                if ((exp.Class?.ObjectName.ToString().ToUpperInvariant() ?? "") == "PACKAGE") return false;

                return true;
            }

            static public bool IsDirectChildOfPackage(UExportTableItem exp)
            {
                return exp.OuterIndex > 0 && (((UExportTableItem)exp.Outer).Class?.ObjectName.ToString().ToUpperInvariant() ?? "") == "PACKAGE";
            }

            public CookedObject(UExportTableItem exp, bool isContent)
            {
                ObjectName = exp.ObjectName;
                ObjectType = exp.Class?.ObjectName ?? "Class";
                ObjectRefPath = exp.GetReferencePath();
                SizeInBytes = exp.SerialSize;

                bIsContent = isContent;
                bIsAsset = isContent && IsDirectChildOfPackage(exp);
            }

            public void SetOuter(CookedObject newOuter)
            {
                //if (Outer != null) Outer.ApplySizeRecursive(-SizeInBytes);
                Outer = newOuter;
                //if (Outer != null) Outer.ApplySizeRecursive(SizeInBytes);
            }

            /*
            public void ApplySizeRecursive(long sizeAdd)
            {
                SizeInBytes += sizeAdd;
                if (Outer != null) Outer.ApplySizeRecursive(sizeAdd);
            }
            */

            public void AddReferenceRecursive(AnalysisPackage packageReferencingUs)
            {
                if (ReferencedBy.Contains(packageReferencingUs)) return;
                ReferencedBy.Add(packageReferencingUs);
                if (Outer != null) Outer.AddReferenceRecursive(packageReferencingUs);
            }
        };

        public class AnalysisPackage
        {
            public string PackagePath { get; protected set; }

            public Exception Error { get; protected set; }

            public List<CookedObject> ReferencedAssets { get; protected set; }

            public AnalysisPackage(string packagePath, string friendlyPath, string decompressCachePath, CookedContentAnalysis Analysis, Action<string> setStatusAct)
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
                        // This package is compressed, including the export table. Gotta decompress it first :/
                        setStatusAct($"Decompressing and analysing package: {friendlyPath}");

                        uncompressedPath = DecompressFacade.DecompressPackage(packagePath, decompressCachePath);

                        loadedPackage.Dispose();
                        loadedPackage = UnrealLoader.LoadPackage(uncompressedPath);
                    }
                    else
                    {
                        setStatusAct($"Analysing decompressed package: {friendlyPath}");
                    }

                    // Time to go through the package's exports and see which assets are present.
                    // Don't need to InitializePackage here, since we don't need the constructed objects (for now).
                    {
                        CookedObject obj, objOuter;
                        UExportTableItem expOuter;
                        string path;
                        bool alreadyRegistered, isContent;
                        ReferencedAssets = new List<CookedObject>();
                        foreach (var exp in loadedPackage.Exports)
                        {
                            if (!CookedObject.IsCookedContent(exp)) continue;

                            alreadyRegistered = Analysis.Objects.TryGetValue(path = exp.GetPath().ToUpperInvariant(), out obj);
                            if (!alreadyRegistered)
                            {
                                // New asset, register it.
                                obj = new CookedObject(exp, true);
                                Analysis.Objects.Add(path, obj);
                            }
                            ReferencedAssets.Add(obj);

                            if (alreadyRegistered)
                            {
                                obj.AddReferenceRecursive(this);
                                continue;
                            }

                            obj.ReferencedBy.Add(this);
                            
                            // This asseet wasn't registered before. Let's climb the parent chain and link its outer.
                            expOuter = (UExportTableItem)exp.Outer;
                            isContent = true;
                            while (expOuter != null)
                            {
                                // For each outer, check if it's considered "content". Do this until we reach one that isn't (possibly a package/grouping),
                                // after which all following outers will definitely be non-content.
                                isContent = isContent && CookedObject.IsCookedContent(expOuter);

                                alreadyRegistered = Analysis.Objects.TryGetValue(path = expOuter.GetPath().ToUpperInvariant(), out objOuter);
                                if (!alreadyRegistered)
                                {
                                    // New outer, register it.
                                    objOuter = new CookedObject(expOuter, isContent);
                                    Analysis.Objects.Add(path, objOuter);
                                }

                                obj.SetOuter(objOuter);
                                objOuter.Children.Add(obj);
                                obj = objOuter;

                                if (alreadyRegistered)
                                {
                                    obj.AddReferenceRecursive(this);
                                    break;
                                }

                                obj.ReferencedBy.Add(this);

                                // This outer wasn't registered before either, keep going.
                                expOuter = (UExportTableItem)expOuter.Outer;
                                continue;
                            }

                            if (expOuter == null)
                            {
                                // Got to the end of the outer chain, meaning that this is a never-before-registered
                                // force-cooked package!!!!! Add it to the tree.
                                Analysis.AssetTree.Add(obj);
                            }
                        }
                    }

                    loadedPackage.Dispose();

                    ReferencedAssets.TrimExcess();
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

        public List<CookedObject> AssetTree { get; protected set; } = new List<CookedObject>();
        public Dictionary<string, CookedObject> Objects { get; protected set; } = new Dictionary<string, CookedObject>();
        public List<AnalysisPackage> PackageFiles { get; protected set; } = null;

        public CookedContentAnalysis(ModObject mod)
        {
            Mod = mod;
        }

        public void RunAnalysis(Action<string> setStatusAct, Action<int> setProgressAct)
        {
            var decompressCachePath = Path.Combine(DecompressFacade.GetDecompressCacheDir(), "CookedContentAnalysis");
            Directory.CreateDirectory(decompressCachePath);

            var path = Mod.GetCookedDir();
            if (Directory.Exists(path))
            {
                List<string> allCookedPackageFiles = new List<string>();

                allCookedPackageFiles.AddRange(GetFilesByType(path, "*.u"));
                allCookedPackageFiles.AddRange(GetFilesByType(path, "*.upk"));
                allCookedPackageFiles.AddRange(GetFilesByType(path, "*.umap"));

                PackageFiles = new List<AnalysisPackage>(allCookedPackageFiles.Count);

                int packagesAnalysed = 0;
                foreach (var packagePath in allCookedPackageFiles)
                {
                    PackageFiles.Add(new AnalysisPackage(packagePath, GetRelativePath(packagePath, Mod.RootPath), decompressCachePath, this, setStatusAct));

                    packagesAnalysed++;
                    setProgressAct((int)(100f * packagesAnalysed / allCookedPackageFiles.Count));
                }
            }

            // We got what we wanted from the decompressed packages. Just in case there's some leftovers somehow, trash them.
            DecompressFacade.ClearDecompressCache(decompressCachePath);

            setStatusAct("Sorting...");

            SortAlphabeticallyRecursive(AssetTree);

            setStatusAct("");
        }

        static public string[] GetFilesByType(string path, string type)
        {
            // The engine seems to be able to read subfolders in CookedPC, so do this recursively.
            return Directory.GetFiles(path, type, SearchOption.AllDirectories);
        }

        public void SortAlphabeticallyRecursive(List<CookedObject> list)
        {
            list.Sort((x, y) => String.Compare(x.ObjectName, y.ObjectName, true));
            foreach (var obj in list)
            {
                SortAlphabeticallyRecursive(obj.Children);
            }
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
