namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class MbrPartitions : INorData
    {
        internal uint StartLba;
        internal uint Sectors;
        internal byte Flag1; // maybe part_id
        internal byte Flag2;
        internal ushort Unknown;
        internal ulong Padding;


        internal MbrPartitions(BinaryReader data)
        {
            StartLba = data.ReadUInt32();
            Sectors = data.ReadUInt32();
            Flag1 = data.ReadByte();
            Flag2 = data.ReadByte();
            Unknown = data.ReadUInt16();
            Padding = data.ReadUInt64();
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(StartLba));
            buffer.AddRange(BitConverter.GetBytes(Sectors));
            buffer.Add(Flag1);
            buffer.Add(Flag2);
            buffer.AddRange(BitConverter.GetBytes(Unknown));
            buffer.AddRange(BitConverter.GetBytes(Padding));
            return buffer.ToArray();
        }
    }
}
