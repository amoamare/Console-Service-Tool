namespace ConsoleServiceTool.Console.Sony.Shared
{
    //Header: Sony Computer Entertainment Inc.
    internal class NorMbr : INorData
    {
        private readonly byte[] Magic = {
                0x53, 0x6F, 0x6E, 0x79, 0x20, 0x43, 0x6F, 0x6D, 0x70, 0x75, 0x74, 0x65,
                0x72, 0x20, 0x45, 0x6E, 0x74, 0x65, 0x72, 0x74, 0x61, 0x69, 0x6E, 0x6D,
                0x65, 0x6E, 0x74, 0x20, 0x49, 0x6E, 0x63, 0x2E
        }; //offset 0x2000
        private const int MaxPartitions = 16;
        internal uint Version; //offset 0x2020
        internal uint Sectors; //offset 0x2024
        internal ulong Reserved; //offset  0x2028
        internal uint LoaderStart;  //offset 0x2030
        internal uint LoaderCount; //offset 0x2034
        internal ulong Reserved2; //offset 0x2038
        internal MbrPartitions[] Partitions = new MbrPartitions[MaxPartitions];
        internal byte[] Reserved3 = new byte[0xe80]; //offset 0x2180

        internal bool WarnHeaderCorrupted = false;

        internal NorMbr(BinaryReader data)
        {
            for (var i = 0; i < Magic.Length; i++)
            {
                if (data.ReadByte() != Magic[i])
                {
                    //throw new FileFormatException();
                    WarnHeaderCorrupted = true;
                }
            }
            Version = data.ReadUInt32();
            Sectors = data.ReadUInt32();
            Reserved = data.ReadUInt64();
            LoaderStart = data.ReadUInt32();
            LoaderCount = data.ReadUInt32();
            Reserved2 = data.ReadUInt64();
            for (var i = 0; i < MaxPartitions; i++)
            {
                Partitions[i] = new MbrPartitions(data);
            }
            Reserved3 = data.ReadBytes(Reserved3.Length);
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Magic);
            buffer.AddRange(BitConverter.GetBytes(Version));
            buffer.AddRange(BitConverter.GetBytes(Sectors));
            buffer.AddRange(BitConverter.GetBytes(Reserved));
            buffer.AddRange(BitConverter.GetBytes(LoaderStart));
            buffer.AddRange(BitConverter.GetBytes(LoaderCount));
            buffer.AddRange(BitConverter.GetBytes(Reserved2));
            foreach (var entry in Partitions)
            {
                buffer.AddRange(entry.ToArray());
            }
            buffer.AddRange(Reserved3);
            return buffer.ToArray();
        }
    }
}
