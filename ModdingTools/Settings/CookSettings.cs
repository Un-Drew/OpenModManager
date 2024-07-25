using ModdingTools.Engine;
using ModdingTools.Logging;
using ModdingTools.Modding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ModdingTools.Settings
{
    public class CookSettings
    {
        public enum ScriptLoadScope
        {
            AlwaysLoaded,
            NonAlwaysLoaded,
            Auto
        };

        public enum MoveMethod
        {
            Copy,
            Move
        };

        public bool EnableCustomCooking { get; set; } = false;

        /* GENERAL SETTINGS */

        public bool Common_CookInIsolation { get; set; } = false;
        public bool Common_ExcludeBaseAlwaysLoadedAssets { get; set; } = false;

        public bool Script_AlwaysLoadedWorkaround { get; set; } = false;
        public ScriptLoadScope Script_LoadScope { get; set; } = ScriptLoadScope.AlwaysLoaded;

        public string Maps_AudioLanguages { get; set; } = "";
        public bool Maps_DeleteLocInt { get; set; } = false;
        public MoveMethod Maps_MoveMethod { get; set; } = MoveMethod.Copy;

        [XmlIgnore]
        public ModObject Mod { get; protected set; }

        static string GetConfigDir(ModObject mod)
        {
            return Path.Combine(mod.RootPath, "OMMSettings");
        }

        static string GetConfigFile(ModObject mod)
        {
            return GetConfigFile(GetConfigDir(mod));
        }

        static string GetConfigFile(string cfgDir)
        {
            return Path.Combine(cfgDir, "CookSettings.xml");
        }

        static public CookSettings LoadSettingsForMod(ModObject mod)
        {
            if (mod == null)
                throw new ArgumentNullException(nameof(mod));

            CookSettings instance = null;
            string cfgFile = GetConfigFile(mod);

            if (File.Exists(cfgFile))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CookSettings));
                    using (Stream reader = new FileStream(cfgFile, FileMode.Open))
                    {
                        instance = (CookSettings)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    // ToDo: Not super happy about this since it's not exposed to the user if something goes wrong.
                    Debug.WriteLine("Uh-oh!\n" + ex.ToString());
                }
            }

            if (instance == null)
            {
                // In case the deserializer failed (probably because the file doesn't exist).
                instance = new CookSettings();
            }

            instance.Mod = mod;
            return instance;
        }

        public CookSettings() { }

        public CookSettings(ModObject mod)
        {
            Mod = mod;
        }

        public void Save()
        {
            if (Mod == null)
                throw new ArgumentNullException("Cook settings not tied to a specific mod, cannot save.");
            
            // Reget the cfg directory every time, in case the mod's folder was moved.
            string cfgDir = GetConfigDir(Mod);
            if (!Directory.Exists(cfgDir))
                Directory.CreateDirectory(cfgDir);

            XmlSerializer serializer = new XmlSerializer(typeof(CookSettings));
            Stream fs = new FileStream(GetConfigFile(cfgDir), FileMode.Create);
            using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
            {
                serializer.Serialize(writer, this);
                writer.Close();
            }
        }

        public void CopySettingsFrom(CookSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("Cannot copy from null settings!");

            EnableCustomCooking = settings.EnableCustomCooking;

            Common_CookInIsolation = settings.Common_CookInIsolation;
            Common_ExcludeBaseAlwaysLoadedAssets = settings.Common_ExcludeBaseAlwaysLoadedAssets;

            Script_AlwaysLoadedWorkaround = settings.Script_AlwaysLoadedWorkaround;
            Script_LoadScope = settings.Script_LoadScope;

            Maps_AudioLanguages = settings.Maps_AudioLanguages;
            Maps_DeleteLocInt = settings.Maps_DeleteLocInt;
            Maps_MoveMethod = settings.Maps_MoveMethod;
        }
    }
}
