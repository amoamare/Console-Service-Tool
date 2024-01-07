namespace ConsoleServiceTool.Console.Sony.Shared
{
    //SONY COMPUTER ENTERTAINMENT INC.
    internal class NorHeader : INorData
    {
        private readonly byte[] Magic = {
                0x53, 0x4F, 0x4E, 0x59, 0x20, 0x43, 0x4F, 0x4D, 0x50, 0x55, 0x54, 0x45,
                0x52, 0x20, 0x45, 0x4E, 0x54, 0x45, 0x52, 0x54, 0x41, 0x49, 0x4E, 0x4D,
                0x45, 0x4E, 0x54, 0x20, 0x49, 0x4E, 0x43, 0x2E
            };

        internal uint Version;
        internal uint Mbr1Start;
        internal uint Mbr2Start;
        internal byte[] Unknown = new byte[sizeof(int) * 4];
        internal uint Reserved;
        internal byte[] Unused = new byte[0x1c0];
        internal byte[] Reserved2 = new byte[0xe00];

        internal bool WarnHeaderCorrupted = false;

        internal NorHeader(BinaryReader data)
        {
            for (var i = 0; i < Magic.Length; i++)
            {
                if (data.ReadByte() != Magic[i])
                {
                    WarnHeaderCorrupted = true;
                }
            }
            Version = data.ReadUInt32();
            Mbr1Start = data.ReadUInt32();
            Mbr2Start = data.ReadUInt32();
            Unknown = data.ReadBytes(Unknown.Length);
            Reserved = data.ReadUInt32();
            Unused = data.ReadBytes(Unused.Length);
            Reserved2 = data.ReadBytes(Reserved2.Length);
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Magic);
            buffer.AddRange(BitConverter.GetBytes(Version));
            buffer.AddRange(BitConverter.GetBytes(Mbr1Start));
            buffer.AddRange(BitConverter.GetBytes(Mbr2Start));
            buffer.AddRange(Unknown);
            buffer.AddRange(BitConverter.GetBytes(Reserved));
            buffer.AddRange(Unused);
            buffer.AddRange(Reserved2);
            return buffer.ToArray();

        }
    }
}
