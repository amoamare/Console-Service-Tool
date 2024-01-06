namespace ConsoleServiceTool.Consoles.Sony.Shared
{
    internal class Slb2 : INorData
    {
        internal Slb2Header Header;
        internal byte[] RawData;

        internal Slb2(BinaryReader data, int sblSize = 0x7de00)
        {
            Header = new Slb2Header(data);
            RawData = data.ReadBytes(sblSize);
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Header.ToArray());
            buffer.AddRange(RawData);
            return buffer.ToArray();
        }
    }
}
