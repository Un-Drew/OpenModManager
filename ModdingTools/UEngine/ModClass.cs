﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ModdingTools.UEngine
{
    public class ModClass
    {
        public string ClassName { get; private set; }
        public string ExtendsClass { get; private set; }
        public string FileName { get; private set; }
        public ModClassType ClassType { get; private set; }

        public enum ModClassType
        {
            Sticker, Weapon, Remix, Badge, Hat, Skin, DWContract, Generic
        }

        private void DetectModClassType()
        {
            // Skin
            if ("Hat_Collectible_Skin".Equals(ExtendsClass))
            {
                ClassType = ModClassType.Skin;
            }
            // Hat
            else if (Utils.CollectionContains(ExtendsClass, new[]
            {
                "Hat_Ability_Trigger",
                "Hat_Ability_Help",
                "Hat_Ability_TimeStop",
                "Hat_Ability_FoxMask",
                "Hat_Ability_Sprint"
            }))
            {
                ClassType = ModClassType.Hat;
            }
            // Badge
            else if (Utils.CollectionContains(ExtendsClass, new[]
            {
                "Hat_Ability_Automatic",
                "Hat_Badge_Weapon"
            }))
            {
                ClassType = ModClassType.Badge;
            }
            // Remix
            else if ("Hat_Collectible_Remix".Equals(ExtendsClass))
            {
                ClassType = ModClassType.Remix;
            }
            // Sticker
            else if ("Hat_Collectible_Sticker".Equals(ExtendsClass))
            {
                ClassType = ModClassType.Sticker;
            }
            // Weapon
            else if (Utils.CollectionContains(ExtendsClass, new[]
            {
                "Hat_Weapon",
                "Hat_Weapon_Umbrella",
                "Hat_Weapon_Nyakuza_BaseballBat"
            }))
            {
                ClassType = ModClassType.Weapon;
            }
            // Death Wish
            else if ("Hat_SnatcherContract_DeathWish".Equals(ExtendsClass))
            {
                ClassType = ModClassType.DWContract;
            }
            // Generic
            else
            {
                ClassType = ModClassType.Generic;
            }
        }

        public Dictionary<string, string> DefaultProperties { get; private set; }

        public ModClass(string path)
        {
            var content = File.ReadAllLines(path);
            FileName = Path.GetFileName(path);

            DefaultProperties = new Dictionary<string, string>();

            int i = 0;

            bool defaultPropReadMode = false;
            foreach (var line in content)
            {
                var cleaned = Utils.ClearWhitespaces(line.Trim());
                if (defaultPropReadMode)
                {
                    if (cleaned.StartsWith("{") || cleaned.StartsWith("//") || string.IsNullOrWhiteSpace(cleaned))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        if (cleaned.StartsWith("}"))
                        {
                            defaultPropReadMode = false;
                            i++;
                            continue;
                        }
                        else
                        {
                            var kvPair = cleaned.Split('=');
                            if (kvPair.Length == 2)
                            {
                                var key = kvPair[0].Trim();

                                var value = kvPair[1].TrimEnd('}').TrimEnd(';').Trim().Trim('"');
                                if (DefaultProperties.ContainsKey(key))
                                {
                                    DefaultProperties[key] = value;
                                }
                                else
                                {
                                    DefaultProperties.Add(key, value);
                                }

                                if (kvPair[1].EndsWith("}"))
                                {
                                    defaultPropReadMode = false;
                                    i++;
                                    continue;
                                }
                            }
                            else
                            {
                                i++;
                                continue;
                            }  
                        }
                    }
                }
                else
                {
                    if (cleaned.StartsWith("defaultproperties"))
                    {
                        var contentA = Utils.ClearWhitespaces(string.Join(" ", content.Skip(i)), false);
                        if (contentA.StartsWith("defaultproperties{"))
                        {
                            defaultPropReadMode = true;
                            i++;
                            continue;
                        }
                    }
                    if (ClassName == null)
                    {
                        // Try to extract class name with extend object name
                        if (cleaned.StartsWith("class"))
                        {
                            var contentA = Utils.ClearWhitespaces(string.Join(" ", content.Skip(i)));
                            var result = Utils.Split(contentA, "class ");
                            ClassName = result[1].Split(' ')[0].Trim();
                            var ext = Utils.Split(contentA, " extends ");
                            if (ext.Length > 0)
                            {
                                ExtendsClass = ext[1].Split(';')[0].Trim().Split(' ')[0];
                            }
                        }
                    }
                }
                i++;
            }

            DetectModClassType();
        }

        public override string ToString()
        {
            var d = "FileName=" + FileName + ", Type=" + ClassType.ToString() + ", ClassName=" + ClassName + ", Extends=" + ExtendsClass + "\n\nDefaultProperties:\n\n";
            foreach (var prop in DefaultProperties)
            {
                d += "key: " + prop.Key + ", value: " + prop.Value + "\n"; 
            }

            return d;
        }
    }
}
