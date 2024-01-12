using System.Runtime.InteropServices;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    [StructLayout(LayoutKind.Sequential)]
    internal class Slb2Header : INorData
    {
        //SLB2 || 0x7E000 || 516,096 bytes
        private readonly byte[] Magic = {
                0x53, 0x4C, 0x42, 0x32
        };
        private const int MaxEntrySize = 10;
        internal uint Version { get; set; }
        internal uint Flags { get; set; }
        internal uint EntryNum { get; set; } //entires
        internal uint SizeInSector { get; set; }  //blocks
        internal byte[] Reserved = new byte[sizeof(uint) * 3]; // padding for alignment

        internal Slb2Entry[] EntryList = new Slb2Entry[MaxEntrySize];

        internal bool WarnHeaderCorrupted = false;

        internal Slb2Header(BinaryReader data)
        {
            for (var i = 0; i < Magic.Length; i++)
            {
                var d = data.ReadByte();
                if (d != Magic[i])
                {
                    WarnHeaderCorrupted = true;
                }
            }
            Version = data.ReadUInt32();
            Flags = data.ReadUInt32();
            EntryNum = data.ReadUInt32();
            SizeInSector = data.ReadUInt32();
            Reserved = data.ReadBytes(Reserved.Length);
            for (var i = 0; i < MaxEntrySize; i++)
            {
                EntryList[i] = new Slb2Entry(data);
            }

        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Magic);
            buffer.AddRange(BitConverter.GetBytes(Version));
            buffer.AddRange(BitConverter.GetBytes(Flags));
            buffer.AddRange(BitConverter.GetBytes(EntryNum));
            buffer.AddRange(BitConverter.GetBytes(SizeInSector));
            buffer.AddRange(Reserved);
            foreach (var entry in EntryList)
            {
                buffer.AddRange(entry.ToArray());
            }
            return buffer.ToArray();
        }
    }
}
