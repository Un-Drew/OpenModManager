﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UELib;

namespace ModdingTools.Engine
{
    public class DecompressFacade
    {
        static public string GetDecompressorPath()
        {
            return Path.Combine(Program.GetAppRoot(), "decompress.exe");
        }

        static public string GetDecompressCacheDir()
        {
            return Path.Combine(Program.GetAppRoot(), "DecompressCache");
        }

        static public void EnsureDecompressCache()
        {
            var path = GetDecompressCacheDir();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        static public void ClearDecompressCache()
        {
            var path = GetDecompressCacheDir();
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*.u"))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(path, "*.upk"))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(path, "*.umap"))
                {
                    File.Delete(file);
                }
            }
        }

        // outDirectory needs to be the output folder, not file.
        static public string DecompressPackage(string packagePath, string outDirectory)
        {
            if (packagePath == null || outDirectory == null) throw new ArgumentNullException();

            var p = new Process();

            p.StartInfo.FileName = GetDecompressorPath();
            // Let's hope quotes actually work here!
            p.StartInfo.Arguments = $"\"-out={outDirectory}\" \"{packagePath}\"";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            // Behold! The decompress-inator!
            p.Start();
            p.WaitForExit();

            var outFile = Path.Combine(outDirectory, Path.GetFileName(packagePath));
            if (!File.Exists(outFile))
            {
                throw new FileNotFoundException($"Could not find decompressed result at {outFile}");
            }

            return outFile;
        }

        static public bool IsPackageCompressed(UnrealPackage package)
        {
            if (package == null) throw new ArgumentNullException();
            return package.Summary.CompressedChunks != null && package.Summary.CompressedChunks.Capacity > 0;
        }
    }
}
