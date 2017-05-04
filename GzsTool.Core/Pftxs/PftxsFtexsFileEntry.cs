using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using GzsTool.Core.Utility;
using System;

namespace GzsTool.Core.Pftxs
{
    [XmlType("EntryData", Namespace = "Pftxs")]
    public class PftxsFtexsFileEntry
    {
        public const int HeaderSize = 16;

        [XmlIgnore]
        public ulong Hash { get; set; }

        [XmlAttribute("FilePath")]
        public string FilePath { get; set; }

        [XmlIgnore]
        public int Offset { get; set; }

        [XmlIgnore]
        public int Size { get; set; }

        [XmlIgnore]
        public byte[] Data { get; set; }

        [XmlIgnore]
        public bool FileNameFound { get; set; }

        public bool ShouldSerializeHash()
        {
            return FileNameFound == false;
        }

        public void CalculateHash()
        {
            bool filePathIsHash = true;

            try
            {
                Hash = Convert.ToUInt64(Path.GetFileNameWithoutExtension(FilePath), 16);
            }
            catch
            {
                filePathIsHash = false;
            }

            if(filePathIsHash)
            {
                ulong extension = Hashing.HashFileExtension(Path.GetExtension(FilePath).Substring(1));

                Hash |= (extension << 51);
            } //if ends
            else
            {
                Hash = Hashing.HashFileNameWithExtension(FilePath);
            } //else ends
        }

        [Conditional("DEBUG")]
        private void DebugAssertHashMatches()
        {
            ulong newHash = Hashing.HashFileNameWithExtension(FilePath);
            if (Hash != newHash)
            {
                Debug.WriteLine("Hash mismatch '{0}' {1}!={2}", FilePath, newHash, Hash);
            }
        }

        public void Read(Stream input)
        {
            BinaryReader reader = new BinaryReader(input, Encoding.Default, true);
            Hash = reader.ReadUInt64();
            Offset = reader.ReadInt32();
            Size = reader.ReadInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Hash);
            writer.Write(Offset);
            writer.Write(Size);
        }
    }
}