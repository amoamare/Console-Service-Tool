namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Slb2 : INorData
    {
        internal Slb2Header Header;
        internal byte[] EncryptedData;

        internal Slb2(BinaryReader data, int sblSize = 0x7de00)
        {
            Header = new Slb2Header(data);
            EncryptedData = data.ReadBytes(sblSize);
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Header.ToArray());
            buffer.AddRange(EncryptedData);
            return buffer.ToArray();
        }
    }
}
