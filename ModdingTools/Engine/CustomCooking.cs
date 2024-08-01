using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModdingTools.Modding;
using ModdingTools.Settings;
using UELib;
using UELib.Flags;

namespace ModdingTools.Engine
{
    // Moving all custom cook logic here, as this is quite a lot to dump in ModObject...
    public class CustomCooking
    {
        public struct CustomCookCommand
        {
            /// <summary>
            /// If true, any special file conditions below will take place in a temporary mod folder.
            /// </summary>
            public bool CookInTempMod;

            /// <summary>
            /// If true, the compiled script package is cooked as a .upk.
            /// </summary>
            public bool ModPackageAsContent;

            /// <summary>
            /// If true, a package file will be auto-generated to reference the classes marked AlwaysLoaded in this mod's package.
            /// 
            /// Requires ModPackageAsContent == true.
            /// </summary>
            public bool UseAutoScriptReferencer;

            /// <summary>
            /// If true, a .u package will be cooked as a .umap, otherwise it'll be cooked as a .u.
            /// </summary>
            /// <remarks>
            /// NOTE: This refers to the final .u package that will be used by the cooked mod, which isn't
            ///       NECESSARILY the mod's compiled script package! If UseAutoScriptReferencer == true,
            ///       this will be applied to the auto-generated referencer package!
            /// </remarks>
            public bool AlwaysLoadedScriptPackageAsMap;

            /// <summary>
            /// Deletes the newly generated cooked package that matches the mod's folder after the command, if it's undesired.
            /// Note the wording - if CookInTempMod == true, this will delete a package with the temp mod's name.
            /// </summary>
            public bool DeleteModPackageAtEnd;
        }

        const string COOK_TEMP_MOD_NAME = @"OMMCookTempMod";

        static public List<CustomCookCommand> DetermineRequiredCookCommands(ModObject mod, CookSettings settings)
        {
            List<CustomCookCommand> cookCommands = new List<CustomCookCommand>();

            bool hasCompiledScripts = mod.HasCompiledScripts();
            bool hasMaps = mod.HasAnyMaps();

            CustomCookCommand command;

            // Values that are global for all cook commands.
            command.ModPackageAsContent = (settings.Script_LoadScope != CookSettings.ScriptLoadScope.AlwaysLoaded);
            command.UseAutoScriptReferencer = (settings.Script_LoadScope == CookSettings.ScriptLoadScope.Auto);

            // Cook the mod normally (including maps). Happen first, before stuff like the AlwaysLoaded workaround starts overriding the files.
            if (hasMaps || !settings.Script_AlwaysLoadedWorkaround)
            {
                // When maps are cooked, the AlwaysLoaded part of the mod's scripts MUST be a .u, so it's treated AlwaysLoaded.
                command.AlwaysLoadedScriptPackageAsMap = false;
                // Not in the temp mod, 'cause our maps aren't there! Plus, this ensures the chapter package gets cooked too.
                // ToDo: May need to change this when I implement Cook Groups. For now, this is good enough.
                command.CookInTempMod = false;
                // If we're using the workaround, we'll cook the script package separately, if needed. Either way, we definitely won't need this one!
                // NOTE: We still need to do this even if the mod's package is a .upk, since EVEN THEN the engine will try to cook it.
                command.DeleteModPackageAtEnd = settings.Script_AlwaysLoadedWorkaround;

                cookCommands.Add(command);
            }

            // AlwaysLoaded workaround - cooking a script package as a map.
            if (settings.Script_AlwaysLoadedWorkaround && settings.Script_LoadScope != CookSettings.ScriptLoadScope.NonAlwaysLoaded && hasCompiledScripts)
            {
                // Workaround turns the AlwaysLoaded part of the mod's scripts into a .umap, since those can embed Non-AL classes.
                command.AlwaysLoadedScriptPackageAsMap = true;
                // If the mod has other maps, it's easier to isolate the forced .umap in a temp mod, than to disable all other maps.
                command.CookInTempMod = hasMaps;
                command.DeleteModPackageAtEnd = false;

                cookCommands.Add(command);
            }

            return cookCommands;
        }

        private const int NOT_COOKING = 0;
        private const int COOKING = 1;
        private static int _isCookingAMod = NOT_COOKING;

        // Wrapper for custom cooking. Aborts if another custom cook is already happening.
        static public bool TryCustomCook(AbstractProcessRunner runner, ModObject mod, List<CustomCookCommand> cookCommands)
        {
            /*
            // TODO: Remove!!!!!
            try
            {
                PackageGenTest();
            }
            catch (Exception ex)
            {
                runner.Log("Ooopsie woopsie!\n" + ex.ToString(), CUFramework.Shared.LogLevel.Warn);
                return false;
            }
            return true;
            */

            if (Interlocked.Exchange(ref _isCookingAMod, COOKING) == COOKING)
            {
                runner.Log("Cannot run 2 custom cooks at once! Aborting...", CUFramework.Shared.LogLevel.Error);
                return false;
            }

            bool result = CustomCook(runner, mod, cookCommands);

            Interlocked.Exchange(ref _isCookingAMod, NOT_COOKING);

            return result;
        }

        static private bool CustomCook(AbstractProcessRunner runner, ModObject mod, List<CustomCookCommand> cookCommands)
        {
            // Variables required for deleting/recovering the files to their original locations, in case of a catastrophic failure or something.
            string tempModPath = null;
            string origCompiledPkgPath = null;
            string currCompiledPkgPath = null;

            bool result = true;

            try
            {
                // NOTE: By this point, the CookedPC folder *should* be cleared, so no need to clear it here.

                // See if we require a temp mod at any point during this custom cook. If so, create it.
                if (cookCommands.Exists((comm) => comm.CookInTempMod))
                {
                    tempModPath = Path.Combine(Program.ProcFactory.GetGamePath(), @"HatinTimeGame", @"Mods", COOK_TEMP_MOD_NAME);
                    if (Directory.Exists(tempModPath))
                    {
                        // ToDo: This could easily happen if OMM crashes or is force-closed. Might wanna implement
                        //       some way to recover from this - especially when Cook Groups become a thing.
                        runner.Log(
                            "Custom cook requires creating a mod named " + COOK_TEMP_MOD_NAME + ", but that mod already exists!" +
                            " This is likely an artifact from a previous cook that was unexpectedly interrupted." +
                            " Please restore any Maps and Content from this mod's folder, then delete it.", CUFramework.Shared.LogLevel.Error);
                        return false;
                    }
                    Directory.CreateDirectory(tempModPath);
                    Directory.CreateDirectory(Path.Combine(tempModPath, @"Maps"));
                    using (StreamWriter sW = File.CreateText(Path.Combine(tempModPath, @"modinfo.ini")))
                    {
                        sW.WriteLine("[Info]");
                        sW.WriteLine("name=OMM temporary cooking mod...");
                        sW.WriteLine("author=\"Me??\"");
                        sW.WriteLine(
                            "description=\"This is an auto-generated mod created by Open Mod Manager during a custom cook." +
                            "[br][br]If you can read this, OMM might've crashed/was force-closed during the process." +
                            " Check for any Maps or Content before manually deleting this!\""
                        );
                        sW.WriteLine("version=\"1.0.0\"");
                        sW.WriteLine("is_cheat=false");
                        sW.WriteLine("icon=icon.jpg");
                    }
                }

                string modDirName = mod.GetDirectoryName();
                string modCookedDir = mod.GetCookedDir();
                string startPath, destPath, fileName;

                origCompiledPkgPath = Path.Combine(mod.GetCompiledScriptsDir(), modDirName + @".u");
                if (!File.Exists(origCompiledPkgPath))
                    // null means the script package doesn't exist.
                    origCompiledPkgPath = null;
                currCompiledPkgPath = origCompiledPkgPath;

                foreach (var command in cookCommands)
                {
                    if (command.AlwaysLoadedScriptPackageAsMap && origCompiledPkgPath == null)
                    {
                        runner.Log("Missing compiled scripts package - cannot perform AlwaysLoaded workaround!", CUFramework.Shared.LogLevel.Warn);
                        continue;
                    }

                    if (origCompiledPkgPath != null)
                    {
                        if (command.ModPackageAsContent || command.UseAutoScriptReferencer)
                        {
                            // It doesn't matter in which mod a .upk file is, as long as the engine can detect it, so it's ok if we always use the source mod here.
                            destPath = Path.Combine(mod.RootPath, @"Content", Path.GetFileNameWithoutExtension(origCompiledPkgPath) + ".upk");
                        }
                        else if (command.AlwaysLoadedScriptPackageAsMap)
                        {
                            // Move the """map""" in the appropriate mod: temp or source.
                            destPath = Path.Combine(command.CookInTempMod ? tempModPath : mod.RootPath, @"Maps", Path.GetFileNameWithoutExtension(origCompiledPkgPath) + @"_Ref.umap");
                        }
                        else
                        {
                            destPath = origCompiledPkgPath;
                        }

                        if (!TryMoveFile(ref currCompiledPkgPath, destPath, runner, false))
                        {
                            result = false;
                            break;
                        }
                    }

                    if (!runner.RunApp(
                        Program.ProcFactory.GetCustomCookMod(
                            command.CookInTempMod ? COOK_TEMP_MOD_NAME : modDirName,
                            mod.CookSettings.Maps_AudioLanguages, !mod.CookSettings.Common_ExcludeBaseAlwaysLoadedAssets
                        ),
                        cleanConsole: false
                    ))
                    {
                        runner.Log("Cook command failed, aborting...", CUFramework.Shared.LogLevel.Error);
                        result = false;
                        break;
                    }

                    if (command.DeleteModPackageAtEnd)
                    {
                        if (command.CookInTempMod)
                            destPath = Path.Combine(tempModPath, @"CookedPC", COOK_TEMP_MOD_NAME + @".u");
                        else
                            destPath = Path.Combine(modCookedDir, modDirName + @".u");

                        if (File.Exists(destPath))
                        {
                            try
                            {
                                File.Delete(destPath);
                            }
                            catch (Exception ex)
                            {
                                runner.Log($"Exception thrown while trying to delete file {destPath} :\n{ex}", CUFramework.Shared.LogLevel.Warn);
                            }
                        }
                    }

                    // When cooking in the temp mod, we need to move the files that were generated back into our source mod's cooked folder!
                    if (command.CookInTempMod)
                    {
                        try
                        {
                            if (!Directory.Exists(modCookedDir))
                            {
                                Directory.CreateDirectory(modCookedDir);
                            }

                            foreach (string file in Directory.GetFiles(Path.Combine(tempModPath, @"CookedPC")))
                            {
                                startPath = file;
                                TryMoveFile(ref startPath, Path.Combine(modCookedDir, Path.GetFileName(file)), runner, false);
                            }
                        }
                        catch (Exception ex)
                        {
                            runner.Log($"Exception thrown while trying to merge directory {Path.Combine(tempModPath, @"CookedPC")} into {modCookedDir}:\n{ex}", CUFramework.Shared.LogLevel.Warn);
                        }
                    }

                    // After force-cooking a package as a map, restore it back to a .u file!
                    if (command.AlwaysLoadedScriptPackageAsMap && Directory.Exists(modCookedDir))
                    {
                        startPath = Path.Combine(modCookedDir, modDirName + @"_Ref.umap");
                        if (File.Exists(startPath))
                        {
                            // Regardless of whether we used a referencer or not, the final cooked .u file should match the mod's name, for consistency's sake.
                            destPath = Path.Combine(modCookedDir, modDirName + @".u");
                            TryMoveFile(ref startPath, destPath, runner, true);
                        }
                        else
                        {
                            runner.Log($"File {startPath} was not generated during cook..? What the heck??", CUFramework.Shared.LogLevel.Error);
                        }

                        // And do the same for the localization .upk files it might've generated.
                        try
                        {
                            foreach (string file in Directory.GetFiles(modCookedDir, modDirName + @"_Ref_LOC_???.upk"))
                            {
                                fileName = Path.GetFileName(file);
                                startPath = file;
                                destPath = Path.Combine(modCookedDir, modDirName + fileName.Substring(fileName.Length - 12));
                                TryMoveFile(ref startPath, destPath, runner, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            runner.Log($"Exception thrown while trying to parse the {modCookedDir} folder for localization files:\n{ex}", CUFramework.Shared.LogLevel.Warn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                runner.Log("Unexpected exception during custom cook:\n" + ex.ToString(), CUFramework.Shared.LogLevel.Error);
                result = false;
            }

            bool safeToDeleteTempMod = true;

            // Restore moved files to their original locations.
            if (origCompiledPkgPath != null)
                TryMoveFile(ref currCompiledPkgPath, origCompiledPkgPath, runner, true);

            // Delete temp mod, if we made one (unless we weren't able to restore files from it...)
            if (safeToDeleteTempMod && tempModPath != null)
            {
                try
                {
                    Directory.Delete(tempModPath, recursive: true);
                    tempModPath = null;
                }
                catch (Exception ex)
                {
                    runner.Log($"Exception thrown while trying to delete temporary mod {COOK_TEMP_MOD_NAME}:\n{ex}", CUFramework.Shared.LogLevel.Warn);
                }
            }

            return result;
        }

        static public bool TryMoveFile(ref string startPath, string destPath, AbstractProcessRunner runner, bool restoring)
        {
            if (startPath == destPath)
                return true;

            if (File.Exists(destPath))
            {
                runner.Log($"Cannot {(restoring ? "restore" : "move")} {Path.GetFileName(startPath)} to {destPath} because a file with that name already exists. Possible leftover from last cook?", CUFramework.Shared.LogLevel.Error);
                return false;
            }

            try
            {
                File.Move(startPath, destPath);
            }
            catch (Exception ex)
            {
                runner.Log($"Exception thrown while trying to {(restoring ? "restore" : "move")} {startPath} to {destPath} :\n{ex}", CUFramework.Shared.LogLevel.Error);
                return false;
            }

            startPath = destPath;
            return true;
        }

        static public void PackageGenTest()
        {
            using (var pkg = new PackageGenerator(@"CustomReferencerTest.upk", replaceExisting: true))
            {
                IUnrealStream stream = pkg.Package.Stream;

                /*
                string[] names = new string[]
                {
                    "ArrayProperty",
                    "button_circle_blue",
                    "button_circle_yellow",
                    "Buttons",
                    "Circle",
                    "Class",
                    "Core",
                    "Drew_ObjectReferencerTest",
                    "Engine",
                    "HatInTime_Hud",
                    "MyObjectReferencer",
                    "None",
                    "ObjectReferencer",
                    "Package",
                    "ReferencedObjects",
                    "Texture2D",
                    "Textures"
                };

                pkg.Names.Capacity = names.Count();

                foreach (var name in names)
                {
                    pkg.Names.Add(new GenNameTableItem(name));
                }
                */

                pkg.Imports.Capacity = 8;

                var packageEngine = new GenImportTableItem()
                {
                    Name = new GenName("Engine", pkg),
                    ClassName = new GenName("Package", pkg),
                    ClassPackageName = new GenName("Core", pkg)
                };
                pkg.Imports.Add(packageEngine);

                var referencerClass = new GenImportTableItem()
                {
                    Name = new GenName("ObjectReferencer", pkg),
                    ClassName = new GenName("Class", pkg),
                    ClassPackageName = new GenName("Core", pkg),
                    Outer = packageEngine
                };
                pkg.Imports.Add(referencerClass);

                var packageHudContent = new GenImportTableItem()
                {
                    Name = new GenName("HatInTime_Hud", pkg),
                    ClassName = new GenName("Package", pkg),
                    ClassPackageName = new GenName("Core", pkg)
                };
                pkg.Imports.Add(packageHudContent);

                var groupingButtons = new GenImportTableItem()
                {
                    Name = new GenName("Buttons", pkg),
                    ClassName = new GenName("Package", pkg),
                    ClassPackageName = new GenName("Core", pkg),
                    Outer = packageHudContent
                };
                pkg.Imports.Add(groupingButtons);

                var groupingCircle = new GenImportTableItem()
                {
                    Name = new GenName("Circle", pkg),
                    ClassName = new GenName("Package", pkg),
                    ClassPackageName = new GenName("Core", pkg),
                    Outer = groupingButtons
                };
                pkg.Imports.Add(groupingCircle);

                var groupingTextures = new GenImportTableItem()
                {
                    Name = new GenName("Textures", pkg),
                    ClassName = new GenName("Package", pkg),
                    ClassPackageName = new GenName("Core", pkg),
                    Outer = groupingCircle
                };
                pkg.Imports.Add(groupingTextures);

                var refA = new GenImportTableItem()
                {
                    Name = new GenName("button_circle_blue", pkg),
                    ClassName = new GenName("Texture2D", pkg),
                    ClassPackageName = new GenName("Engine", pkg),
                    Outer = groupingTextures
                };
                pkg.Imports.Add(refA);

                var refB = new GenImportTableItem()
                {
                    Name = new GenName("button_circle_yellow", pkg),
                    ClassName = new GenName("Texture2D", pkg),
                    ClassPackageName = new GenName("Engine", pkg),
                    Outer = groupingTextures
                };
                pkg.Imports.Add(refB);

                var objectReferencer = new GenExportTableItem()
                {
                    Name = new GenName("MyObjectReferencer", pkg),
                    Outer = null,
                    Class = referencerClass,
                    Super = null,
                    Archetype = null,
                    ObjectFlags = (ulong)(
                        ObjectFlagsLO.Public | ObjectFlagsLO.LoadForClient | ObjectFlagsLO.LoadForServer
                        | ObjectFlagsLO.LoadForEdit | ObjectFlagsLO.Standalone
                    ),
                    // Ensure serial size & offset are BOTH written. Not necessary for Hat, but for older package versions it is.
                    // It's a good practice to let the export know, ahead of time, that there WILL be serial data written for this.
                    SerialSize = 1,
                    // Was not force-cooked, or exported in any other special way.
                    ExportFlags = 0,
                    Depends = new List<GenObjectRef>
                    {
                        refA,
                        groupingTextures,
                        groupingCircle,
                        groupingButtons,
                        refB
                    }
                };
                pkg.Exports.Add(objectReferencer);

                // The names used by the serialized properties should be initialized NOW, before the name table is written.
                var nameReferencedObjects = new GenName("ReferencedObjects", pkg);
                var nameArrayProperty = new GenName("ArrayProperty", pkg);
                var nameNone = new GenName("None", pkg);

                pkg.Package.Summary.Generations.Add(new UGenerationTableItem()
                {
                    NameCount = pkg.Names.Count,
                    ExportCount = pkg.Exports.Count,
                    NetObjectCount = pkg.Exports.Count,
                });

                // Serialize the full header.
                pkg.SerializeHeader();
                pkg.SerializeNameTable();
                pkg.SerializeImportTable();
                pkg.SerializeExportTable();
                pkg.SerializeDependsMap();

                // Now write the serial data for our referencer object (properties).
                objectReferencer.BeginWritingSerialData(stream);
                {
                    stream.Write((int)0); // Net index

                    nameReferencedObjects.Serialize(stream); // Default property name = ReferencedObjects
                    nameArrayProperty.Serialize(stream); // Default property type = ArrayProperty

                    stream.Write((int)12); stream.Write((int)0); // SizeInBytes = 12, and StaticArrayIndex = 0
                    {
                        stream.Write((int)2); // Length = 2
                        ((GenObjectRef)refA).Serialize(stream);
                        ((GenObjectRef)refB).Serialize(stream);
                    }

                    nameNone.Serialize(stream); // Default property name = None (end of properties)
                }
                objectReferencer.EndWritingSerialData(stream);

                // Rewrite the byte positions of all tables, until (and including) the depends map.
                pkg.RewriteTableInfo(PackageGenerator.TableInfoRewriteScope.Depends);
                // We wrote serial data earlier, so go to the referencer's export entry and rewrite the size and offset.
                objectReferencer.RewriteSerialInfo(stream);

                // Aaaand, we're done!
            }
        }
    }
}
