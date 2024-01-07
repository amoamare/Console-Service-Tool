using ConsoleServiceTool.Utils;
using System.Text;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Slb2Entry : INorData
    {
        internal uint FileStartSector { get; set; }
        internal uint FileSizeInBytes { get; set; }
        internal byte[] Reserved = new byte[sizeof(uint) * 2]; // padding for alignment
        private readonly byte[] fileName = new byte[32];

        internal Slb2Entry(BinaryReader data)
        {
            FileStartSector = data.ReadUInt32();
            FileSizeInBytes = data.ReadUInt32();
            Reserved = data.ReadBytes(Reserved.Length);
            fileName = data.ReadBytes(fileName.Length);
        }

        internal string FileName
        {
            get => fileName.ReadCString();
            set => Encoding.ASCII.GetBytes(value);
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(FileStartSector));
            buffer.AddRange(BitConverter.GetBytes(FileSizeInBytes));
            buffer.AddRange(Reserved);
            buffer.AddRange(fileName);
            return buffer.ToArray();
        }
    }
}
