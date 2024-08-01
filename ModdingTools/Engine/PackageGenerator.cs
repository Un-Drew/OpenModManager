using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using UELib;
using UELib.Branch;
using UELib.Core;
using UELib.Flags;

namespace ModdingTools.Engine
{
    /// <summary>
    /// Barebones functionality for creating an AHiT package from scratch. Used for generating referencer packages
    /// (rather than having to go through the Make commandlet, which takes a much longer time).
    /// </summary>
    public class PackageGenerator : IDisposable
    {
        public UnrealPackage Package { get; protected set; }

        // Can't use the package's lists because they're read-only with no way to instance them...
        public GenTableCollection<GenNameTableItem> Names { get; protected set; } = new GenTableCollection<GenNameTableItem>();
        public GenTableCollection<GenExportTableItem> Exports { get; protected set; } = new GenTableCollection<GenExportTableItem>();
        public GenTableCollection<GenImportTableItem> Imports { get; protected set; } = new GenTableCollection<GenImportTableItem>();

        public long HeaderSizeOffset = 0;
        public long TableInfoOffset = 0;

        public ulong[] packageFlagsMap;

        protected bool _disposedValue;

        public PackageGenerator(string packagePath, bool replaceExisting = false, uint version = 893, ushort licenseeVersion = 5)
        {
            var stream = new UPackageStream(packagePath, replaceExisting ? FileMode.Create : FileMode.CreateNew, FileAccess.ReadWrite);

            // The package signature has to be written before the package is created, due to how UELib works at the moment.
            stream.Write(UnrealPackage.Signature);
            stream.Position = 0;

            Package = new UnrealPackage(stream);
            Package.BuildTarget = UnrealPackage.GameBuild.BuildName.Unset;

            // It's important to (and fortunate that we can) fill out the header info in the actual UnrealPackage object,
            // since some summary values like Version are used incredibly often by the stream, and, if not initialized
            // properly, could produce incorrect results (e.g. pre-UE3 indexes and string lengths are written differently).

            Package.Summary.Version = version;
            Package.Summary.LicenseeVersion = licenseeVersion;

            SetupBuild();
            SetupBranch();

            // This is always "None" in my experience.
            Package.Summary.FolderName = "None";

            stream.Package.Branch.EnumFlagsMap.TryGetValue(typeof(PackageFlag), out packageFlagsMap);
            Package.Summary.PackageFlags = new UnrealFlags<PackageFlag>(0, ref packageFlagsMap);

            // All mod packages seem to have this. Don't know if it affects Hat in any way!
            AddPackageFlag(PackageFlag.AllowDownload);

            Package.Summary.Guid = (UGuid)Guid.NewGuid();

            Package.Summary.Generations = new UArray<UGenerationTableItem>();

            Package.Summary.EngineVersion = 12097;  // AHiT packages from current-ver have this.

            // ToDo: What the heck even is this??? It's seemingly random on every single save!
            var rand = new Random();
            Package.Summary.PackageSource = (uint)rand.Next();

            Package.Summary.AdditionalPackagesToCook = new UArray<string>();
        }

        protected void SetupBuild()
        {
            if (Package.Build == null)
            {
                Package.Build = new UnrealPackage.GameBuild(Package);
            }
        }

        protected void SetupBranch()
        {
            if (Package.Build.EngineBranchType != null)
            {
                Package.Branch = (UELib.Branch.EngineBranch)Activator.CreateInstance(Package.Build.EngineBranchType, Package.Build.Generation);
            }
            else if (Package.Summary.UE4Version != 0)
            {
                Package.Branch = new UELib.Branch.UE4.EngineBranchUE4();
            }
            else
            {
                Package.Branch = new UELib.Branch.DefaultEngineBranch(Package.Build.Generation);
            }

            Package.Branch.Setup(Package);
        }

        public void AddPackageFlag(PackageFlag flag)
        {
            AddFlag(Package.Summary.PackageFlags, flag, ref packageFlagsMap);
        }

        public void RemovePackageFlag(PackageFlag flag)
        {
            RemoveFlag(Package.Summary.PackageFlags, flag, ref packageFlagsMap);
        }

        // Yeap, gotta pass the flags map every single time (:
        public void AddFlag<TEnum>(UnrealFlags<TEnum> flags, TEnum flagIndex, ref ulong[] flagsMap) where TEnum : Enum
        {
            var flag = flagsMap[(int)(object)flagIndex];
            if (flag != 0L)
            {
                flags.Flags |= flag;
            }
        }

        public void RemoveFlag<TEnum>(UnrealFlags<TEnum> flags, TEnum flagIndex, ref ulong[] flagsMap) where TEnum : Enum
        {
            var flag = flagsMap[(int)(object)flagIndex];
            if (flag != 0L)
            {
                flags.Flags &= ~flag;
            }
        }

        public void SerializeHeader()
        {
            SerializeHeader(Package.Stream, ref Package.Summary);
        }

        public void SerializeHeader(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary)
        {
            stream.Position = 4;

            // Version + Licensee version
            uint versionCombo = (summary.Version & 0xFFFFU) | ((uint)summary.LicenseeVersion << 16);
            stream.Write(versionCombo);

            // Header size
            if (summary.Version >= 249)
            {
                HeaderSizeOffset = stream.Position;
                RewriteHeaderSize(stream, ref summary);
            }

            // Folder name
            if (summary.Version >= 269)
            {
                stream.Write(summary.FolderName);
            }

            // Package flags
            stream.Write((uint)summary.PackageFlags.Flags);

            // Table info (names, exports, imports, dependencies)
            TableInfoOffset = stream.Position;
            RewriteTableInfo(stream, ref summary);

            // Guid
            if (summary.Version >= 68)
            {
                summary.Guid.Serialize(stream);
            }

            // Generations
            stream.Write((int)summary.Generations.Count);
            // There's no WriteArray function for an already read length, so write the entires manually.
            foreach (UGenerationTableItem item in summary.Generations)
            {
                item.Serialize(stream);
            }

            // Engine version
            if (stream.Version >= 245)
            {
                stream.Write(summary.EngineVersion);
            }

            // Cooker version
            if (stream.Version >= 277)
            {
                stream.Write(summary.CookerVersion);
            }

            // Compression flags
            if (stream.Version >= 334)
            {
                stream.Write(summary.CompressionFlags);
                // Compressed chunks array - always empty.
                stream.Write((int)0);
            }

            // Package source
            if (stream.Version >= 482)
            {
                stream.Write(summary.PackageSource);
            }

            // Additional packages to cook
            if (stream.Version >= 516)
            {
                stream.WriteIndex(summary.AdditionalPackagesToCook.Count);
                foreach (string item in summary.AdditionalPackagesToCook)
                {
                    stream.Write(item);
                }
            }

            // Idk, some list related to textures? We won't have any of those here though.
            if (stream.Version >= 767)
            {
                stream.Write((int)0);
            }
        }

        public void RewriteHeaderSize()
        {
            RewriteHeaderSize(Package.Stream, ref Package.Summary);
        }

        public void RewriteHeaderSize(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary)
        {
            stream.Position = HeaderSizeOffset;
            stream.Write(summary.HeaderSize);
        }

        /// <summary>
        /// How much to write from the table info. Each entry will cause the rewrite of the previous as well.
        /// </summary>
        [Flags]
        public enum TableInfoRewriteScope
        {
            Names             = 0x01,
            Exports           = 0x02 | Names,
            Imports           = 0x04 | Exports,
            Heritage          = 0x08 | Imports,
            Depends           = 0x10 | Heritage,
            ImportExportGuids = 0x20 | Depends,
            Thumbnails        = 0x40 | ImportExportGuids,

            All = Names | Exports | Imports | Heritage | Depends | ImportExportGuids | Thumbnails
        };

        public void RewriteTableInfo(TableInfoRewriteScope scope = TableInfoRewriteScope.All)
        {
            RewriteTableInfo(Package.Stream, ref Package.Summary, scope: scope);
        }

        public void RewriteTableInfo(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary, TableInfoRewriteScope scope = TableInfoRewriteScope.All)
        {
            if ((scope & TableInfoRewriteScope.Names) == 0) return;

            stream.Position = TableInfoOffset;

            stream.Write(summary.NameCount);
            stream.Write(summary.NameOffset);

            if ((scope & TableInfoRewriteScope.Exports) == 0) return;

            stream.Write(summary.ExportCount);
            stream.Write(summary.ExportOffset);

            if ((scope & TableInfoRewriteScope.Imports) == 0) return;

            stream.Write(summary.ImportCount);
            stream.Write(summary.ImportOffset);

            if ((scope & TableInfoRewriteScope.Heritage) == 0) return;

            if (summary.Version < 68)
            {
                stream.Write(summary.HeritageCount);
                stream.Write(summary.HeritageOffset);
            }

            if ((scope & TableInfoRewriteScope.Depends) == 0) return;

            if (summary.Version >= 415)
            {
                stream.Write(summary.DependsOffset);
            }

            if ((scope & TableInfoRewriteScope.ImportExportGuids) == 0) return;

            if (summary.Version >= 623)
            {
                stream.Write(summary.ImportExportGuidsOffset);
                stream.Write(summary.ImportGuidsCount);
                stream.Write(summary.ExportGuidsCount);
            }

            if ((scope & TableInfoRewriteScope.Thumbnails) == 0) return;

            if (summary.Version >= 584)
            {
                stream.Write(summary.ThumbnailTableOffset);
            }
        }

        public void SerializeNameTable()
        {
            SerializeNameTable(Package.Stream, ref Package.Summary);
        }

        public void SerializeNameTable(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary)
        {
            summary.NameCount = Names.Count;
            summary.NameOffset = (int)stream.Position;

            foreach (GenNameTableItem name in Names)
            {
                name.Offset = stream.Position;
                name.Serialize(stream);
                name.Size = stream.Position - name.Offset;
            }
        }

        public void SerializeImportTable()
        {
            SerializeImportTable(Package.Stream, ref Package.Summary);
        }

        public void SerializeImportTable(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary)
        {
            summary.ImportCount = Imports.Count;
            summary.ImportOffset = (int)stream.Position;

            foreach (GenImportTableItem import in Imports)
            {
                import.Offset = stream.Position;
                import.Serialize(stream);
                import.Size = stream.Position - import.Offset;
            }
        }

        public void SerializeExportTable()
        {
            SerializeExportTable(Package.Stream, ref Package.Summary);
        }

        public void SerializeExportTable(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary)
        {
            summary.ExportCount = Exports.Count;
            summary.ExportOffset = (int)stream.Position;

            foreach (GenExportTableItem export in Exports)
            {
                export.Offset = stream.Position;
                export.Serialize(stream);
                export.Size = stream.Position - export.Offset;
            }
        }

        public void SerializeDependsMap()
        {
            SerializeDependsMap(Package.Stream, ref Package.Summary);
        }

        public void SerializeDependsMap(UPackageStream stream, ref UnrealPackage.PackageFileSummary summary)
        {
            summary.DependsOffset = (int)stream.Position;

            foreach (GenExportTableItem export in Exports)
            {
                export.SerializeDepends(stream);
            }
        }

        public void RewriteExportTableSerialInfos()
        {
            RewriteExportTableSerialInfos(Package.Stream);
        }

        public void RewriteExportTableSerialInfos(UPackageStream stream)
        {
            foreach (GenExportTableItem export in Exports)
            {
                export.RewriteSerialInfo(stream);
            }
        }

        public GenObjectTableItem ObjIndexToEntry(int index)
        {
            if (index == 0)
                return null;
            if (index > 0)
            {
                if (Exports.Count <= index)
                    return null;
                return Exports[index - 1];
            }
            else
            {
                index = -index;
                if (Imports.Count <= index)
                    return null;
                return Imports[index - 1];
            }
        }

        static public int ObjEntryToIndex(GenObjectTableItem entry)
        {
            if (entry == null)
                return 0;
            return entry.ToObjIndex();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Package?.Dispose();
                    Package = null;
                }

                _disposedValue = true;
            }
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    // Custom table & name classes, as the access modifiers used in UELib's are kinda restrictive.
    //  v  v  v
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public struct GenName
    {
        public GenNameTableItem Name;
        public int Number;

        public GenName(GenNameTableItem name, int number)
        {
            Name = name;
            Number = number;
        }

        public GenName(string name, PackageGenerator pkg)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Number = -1;
            if (pkg.Package.Summary.Version >= (uint)PackageObjectLegacyVersion.NumberAddedToName)
            {
                int underscorePos = name.LastIndexOf('_');
                if (underscorePos != -1 && underscorePos != name.Length - 1)
                {
                    string rightSide = name.Substring(underscorePos + 1);
                    if (int.TryParse(rightSide, out Number) && Number >= 0)
                        name = name.Substring(0, underscorePos);
                    else
                        Number = -1;

                }
            }

            string upperName = name.ToUpperInvariant();
            Name = pkg.Names.FirstOrDefault(n => String.Equals(n.Text.ToUpperInvariant(), upperName));
            if (Name == null)
            {
                Name = new GenNameTableItem(name);
                pkg.Names.Add(Name);
            }
        }

        public void Deserialize(IUnrealStream stream, PackageGenerator pkg)
        {
            int tableIndex = stream.ReadIndex();
            int number;
            if (stream.Version >= (uint)PackageObjectLegacyVersion.NumberAddedToName)
                number = stream.ReadInt32() - 1;
            else
                number = -1;

            if (pkg.Names.Count <= tableIndex)
            {
                throw new IndexOutOfRangeException($"Name reference {tableIndex}, {number} is out of the name table range {pkg.Names.Count}.");
            }

            Number = number;
            Name = pkg.Names[tableIndex];
        }

        public void Serialize(IUnrealStream stream)
        {
            if (Name == null)
                throw new NullReferenceException("Failed to serialize null name reference!");

            stream.WriteIndex(Name.Index);
            if (stream.Version >= (uint)PackageObjectLegacyVersion.NumberAddedToName)
            {
                stream.Write(Number + 1);
            }
        }

        public override string ToString()
        {
            if (Name == null)
                return "";
            if (Number >= 0)
                return Name.Text + "_" + Number;
            else
                return Name.Text;
        }
    }

    public class GenNameTableItem : GenTableItem, IUnrealSerializableClass
    {
        public string Text;
        public ulong Flags;

        // TagExp | LoadForClient | LoadForServer | LoadForEditor. This seems to be the case for most (if not all?) names in Hat.
        const ulong DEFAULT_NAME_FLAGS = 0x70010;

        public GenNameTableItem() : this(null, DEFAULT_NAME_FLAGS) { }

        public GenNameTableItem(string text) : this(text, DEFAULT_NAME_FLAGS) { }

        public GenNameTableItem(string text, ulong flags)
        {
            Text = text;
            Flags = flags;
        }

        public void Deserialize(IUnrealStream stream)
        {
            if (stream.Version < 64)
                Text = stream.ReadAnsiNullString();
            else
                Text = stream.ReadString();

            GenExportTableItem.ReadObjectFlags(stream);
        }

        public void Serialize(IUnrealStream stream)
        {
            if (stream.Version < 64)
                WriteAnsiNullString(stream, Text);
            else
                stream.Write(Text);

            GenExportTableItem.WriteObjectFlags(stream, Flags);
        }

        static public bool IsUnicode(string s)
        {
            return s.Any(c => c >= 127);
        }

        static public void WriteAnsiNullString(IUnrealStream stream, string s)
        {
            if (IsUnicode(s))
                throw new ArgumentException("Versions below 64 may not use unicode strings.");

            Stream streamCast = (Stream)stream;
            foreach (byte c in s)
            {
                streamCast.WriteByte(c);
            }
            streamCast.WriteByte(0);
        }
    }

    public struct GenObjectRef
    {
        public GenObjectTableItem Obj;

        public GenObjectRef(GenObjectTableItem obj)
        {
            Obj = obj;
        }

        public static implicit operator GenObjectRef(GenObjectTableItem obj)
        {
            return new GenObjectRef(obj);
        }

        public static implicit operator GenObjectTableItem(GenObjectRef objRef)
        {
            return objRef.Obj;
        }

        public void Deserialize(IUnrealStream stream, PackageGenerator pkg, bool forceInt32 = false)
        {
            Obj = pkg.ObjIndexToEntry(forceInt32 ? stream.ReadInt32() : stream.ReadIndex());
        }

        public void Serialize(IUnrealStream stream, bool forceInt32 = false)
        {
            if (forceInt32)
                stream.Write(PackageGenerator.ObjEntryToIndex(Obj));
            else
                stream.WriteIndex(PackageGenerator.ObjEntryToIndex(Obj));
        }
    }

    public abstract class GenObjectTableItem : GenTableItem
    {
        public GenName Name;
        public GenObjectRef Outer;

        public abstract int ToObjIndex();
    }

    public class GenImportTableItem : GenObjectTableItem
    {
        public GenName ClassName;
        public GenName ClassPackageName;

        public override int ToObjIndex()
        {
            return -Index - 1;
        }

        public void Deserialize(IUnrealStream stream, PackageGenerator pkg)
        {
            ClassPackageName.Deserialize(stream, pkg);
            ClassName.Deserialize(stream, pkg);
            Outer.Deserialize(stream, pkg, forceInt32: true); // Always written as 32bits regardless of build.
            Name.Deserialize(stream, pkg);
        }

        public void Serialize(IUnrealStream stream)
        {
            ClassPackageName.Serialize(stream);
            ClassName.Serialize(stream);
            Outer.Serialize(stream, forceInt32: true); // Always written as 32bits regardless of build.
            Name.Serialize(stream);
        }
    }

    public class GenExportTableItem : GenObjectTableItem
    {
        public GenObjectRef Class;
        public GenObjectRef Super;
        public GenObjectRef Archetype;

        public ulong ObjectFlags;

        public uint SerialSize;
        public uint SerialOffset;

        public uint ExportFlags;
        public UGuid ForceExportGuid;
        public uint ForceExportPackageFlags;

        public long SerialInfoPos;
        public bool SerialOffsetWritten { get; protected set; }

        public List<GenObjectRef> Depends;

        public override int ToObjIndex()
        {
            return Index + 1;
        }

        public void Deserialize(IUnrealStream stream, PackageGenerator pkg)
        {
            Class.Deserialize(stream, pkg);
            Super.Deserialize(stream, pkg);
            Outer.Deserialize(stream, pkg, forceInt32: true); // Always written as 32bits regardless of build.
            Name.Deserialize(stream, pkg);
            if (stream.Version >= 220) // VArchetype
            {
                Archetype.Deserialize(stream, pkg, forceInt32: true);
            }
            ObjectFlags = ReadObjectFlags(stream);
            SerialInfoPos = stream.Position;
            SerialSize = (uint)stream.ReadIndex();
            if (SerialSize > 0 || stream.Version >= 249) // VSerialSizeConditionless
            {
                SerialOffset = (uint)stream.ReadIndex();
                SerialOffsetWritten = true;
            }
            else
            {
                SerialOffsetWritten = false;
            }

            if (stream.Version < 220)
                return;

            if (stream.Version < 543)
            {
                // NameToObject
                int componentMapCount = stream.ReadInt32();
                stream.Skip(componentMapCount * 12);
            }

            if (stream.Version < 247)
                return;

            ExportFlags = stream.ReadUInt32();

            if (stream.Version < (uint)PackageObjectLegacyVersion.NetObjectsAdded)
                return;

            // Array of objects
            int netObjectCount = stream.ReadInt32();
            stream.Skip(netObjectCount * 4);

            ForceExportGuid.Deserialize(stream);
            if (stream.Version > 486) // 475?  486(> Stargate Worlds)
            {
                ForceExportPackageFlags = stream.ReadUInt32();
            }
        }

        public void Serialize(IUnrealStream stream)
        {
            Class.Serialize(stream);
            Super.Serialize(stream);
            Outer.Serialize(stream, forceInt32: true); // Always written as 32bits regardless of build.
            Name.Serialize(stream);
            if (stream.Version >= 220) // VArchetype
            {
                Archetype.Serialize(stream, forceInt32: true);
            }
            WriteObjectFlags(stream, ObjectFlags);
            SerialInfoPos = stream.Position;
            WriteSerialInfo(stream, isRewrite: false);

            if (stream.Version < 220)
                return;

            if (stream.Version < 543)
            {
                // NOTE: Component map not supported.
                stream.Write((int)0);
            }

            if (stream.Version < 247)
                return;

            stream.Write(ExportFlags);

            if (stream.Version < (uint)PackageObjectLegacyVersion.NetObjectsAdded)
                return;

            // NOTE: Net objects not yet supported (as it's not needed for auto-referencers).
            stream.Write((int)0);

            ForceExportGuid.Serialize(stream);
            if (stream.Version > 486) // 475?  486(> Stargate Worlds)
            {
                stream.Write(ForceExportPackageFlags);
            }
        }

        public void RewriteSerialInfo(IUnrealStream stream)
        {
            WriteSerialInfo(stream, true);
        }

        protected void WriteSerialInfo(IUnrealStream stream, bool isRewrite)
        {
            if (SerialInfoPos == 0)
            {
                throw new DataMisalignedException($"Cannot rewrite serial info for export entry [{Index}] that wasn't yet serialized!");
            }

            stream.Position = SerialInfoPos;

            stream.WriteIndex((int)SerialSize);

            if (stream.Version < 249) // VSerialSizeConditionless
            {
                bool wantsToWriteOffset = (SerialSize > 0);
                if (isRewrite && wantsToWriteOffset != SerialOffsetWritten)
                {
                    if (wantsToWriteOffset)
                        throw new DataMisalignedException(
                            $"Attempted to rewrite non-null serial info for export entry [{Index}], but was not initially serialized as such." +
                            " To avoid this misalignment, please set a non-zero SerialSize BEFORE the initial serialization!"
                        );
                    else
                        throw new DataMisalignedException(
                            $"Attempted to rewrite null serial info for export entry [{Index}], but was not initially serialized as such." +
                            " To avoid this misalignment, please make sure the SerialSize remains zero BEFORE the initial serialization!"
                        );
                }
                if (!wantsToWriteOffset)
                {
                    SerialOffsetWritten = false;
                    return;
                }
            }

            stream.WriteIndex((int)SerialOffset);
            SerialOffsetWritten = true;
        }

        public void DeserializeDepends(IUnrealStream stream, PackageGenerator pkg)
        {
            int count = Math.Max(0, stream.ReadInt32());
            Depends = new List<GenObjectRef>(count);
            for (int i = 0; i < count; i++)
            {
                Depends[i].Deserialize(stream, pkg, forceInt32: true);
            }
        }

        public void SerializeDepends(IUnrealStream stream)
        {
            int count = Depends == null ? 0 : Depends.Count;
            stream.Write(count);
            for (int i = 0; i < count; i++)
            {
                Depends[i].Serialize(stream, forceInt32: false);
            }
        }

        public void BeginWritingSerialData(IUnrealStream stream)
        {
            SerialOffset = (uint)stream.Position;
        }

        public void EndWritingSerialData(IUnrealStream stream)
        {
            SerialSize = (uint)(stream.Position - SerialOffset);
        }

        static public ulong ReadObjectFlags(IUnrealStream stream)
        {
            ulong flags = stream.ReadUInt32();
            if (stream.Version >= UExportTableItem.VObjectFlagsToULONG)
            {
                flags = (flags << 32) | stream.ReadUInt32();
            }
            return flags;
        }

        static public void WriteObjectFlags(IUnrealStream stream, ulong flags)
        {
            if (stream.Version >= UExportTableItem.VObjectFlagsToULONG)
            {
                stream.Write((uint)(flags >> 32));
            }
            stream.Write((uint)flags);
        }
    }

    public abstract class GenTableItem
    {
        public int Index;
        public long Offset;
        public long Size;
    }

    // Collection meant for table items, that updates the index for the entries when they've been added/moved.
    public class GenTableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T> where T : GenTableItem
    {
        public int Capacity
        {
            get
            {
                return ((List<T>)Items).Capacity;
            }

            set
            {
                ((List<T>)Items).Capacity = value;
            }
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Avalability of New and Old items in the event, depending on the action:
            // - Add: New
            // - Remove: Old
            // - Move: Both
            // - Replace: Both
            // - Reset: Neither - because the entire list was cleared.
            // Indexes may not necessarily be guaranteed for other collection types!!

            if (e.Action == NotifyCollectionChangedAction.Reset)
                // Well, our collection is empty, so...
                return;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:  // Triggered by Add or Insert
                    UpdateIndexes(Math.Max(e.NewStartingIndex, 0), this.Count);
                    break;
                case NotifyCollectionChangedAction.Remove:  // Triggered when an item is Removed or Popped
                    UpdateIndexes(Math.Max(e.OldStartingIndex, 0), this.Count);
                    break;
                case NotifyCollectionChangedAction.Move:  // Item(s) in the collection was/were moved to another index.
                    if (e.OldStartingIndex < 0 || e.NewStartingIndex < 0)
                    {
                        UpdateIndexes(0, this.Count); // No index info, so let's just update everything...
                    }
                    else
                    {
                        int rangeStart, rangeEnd;
                        if (e.OldStartingIndex < e.NewStartingIndex)
                        {
                            // Moved forwards.
                            rangeStart = e.OldStartingIndex;
                            rangeEnd = e.NewStartingIndex + e.NewItems.Count;
                        }
                        else
                        {
                            // Moved backwards.
                            rangeStart = e.NewStartingIndex;
                            rangeEnd = e.OldStartingIndex + e.NewItems.Count; // NOTE: OldItems == NewItems
                        }
                        UpdateIndexes(rangeStart, rangeEnd);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:  // Item(s) in the list was/were replaced with others.
                    if (e.NewStartingIndex < 0)
                    {
                        UpdateIndexes(0, this.Count); // No index info, so let's just update everything...
                    }
                    else
                    {
                        // NOTE: No idea if OldItems could have a different length from NewItems. Better safe than sorry!! (:
                        UpdateIndexes(e.NewStartingIndex, (e.NewItems.Count == e.OldItems.Count) ? e.NewStartingIndex + e.NewItems.Count : this.Count);
                    }
                    break;
                default:
                    throw new NotImplementedException($"Uhhh... since when did {e.Action} exist?");
            }
        }

        public void UpdateIndexes(int rangeStart, int rangeEnd)
        {
            for (int i = rangeStart; i < rangeEnd; i++)
            {
                this[i].Index = i;
            }
        }
    }
}
