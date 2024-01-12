namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Nor : INorData
    {
        internal const long ExpectedSize = 2097152L;
        internal NorHeader Header; //offset  0x00000 | Size 0x1000
        internal NorActiveSlot ActiveSlot; //offset  0x1000 | Size 0x1000
        internal NorMbr Mbr1; //offset  0x2000 | Size 0x1000
        internal NorMbr Mbr2; //offset  0x3000 | Size 0x1000
        internal Slb2 EmcIplA; //offset 0x4000 | Size 0x7E000
        internal Slb2 EmcIplB; //offset 0x82000 | Size 0x7E000
        internal Slb2 UsbPdcA; //offset 0x100000| Size 0x10000
        internal Slb2 UsbPdcB; //offset 0x110000 | Size 0x10000
        internal byte[] Unk = new byte[0xA4000]; //offset 0x120000
        internal Nvs Nvs; //ofset 0x1C4000
        internal byte[] Reserved = new byte[0x31000]; //offset 0x1CF000

        internal bool WarnInvalidSize = false;

        internal Nor(FileInfo fileInfo)
        {
            WarnInvalidSize = fileInfo.Length != ExpectedSize;
            using var bytes = fileInfo.OpenRead();
            using var binReader = new BinaryReader(bytes);
            Header = new NorHeader(binReader);
            ActiveSlot = new NorActiveSlot(binReader);
            Mbr1 = new NorMbr(binReader);
            Mbr2 = new NorMbr(binReader);
            EmcIplA = new Slb2(binReader);
            EmcIplB = new Slb2(binReader);
            UsbPdcA = new Slb2(binReader, 0xfe00);
            UsbPdcB = new Slb2(binReader, 0xfe00);
            bytes.ReadExactly(Unk);
            Nvs = new Nvs(binReader);

            bytes.ReadExactly(Reserved);            
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Header.ToArray());
            buffer.AddRange(ActiveSlot.ToArray());
            buffer.AddRange(Mbr1.ToArray());
            buffer.AddRange(Mbr2.ToArray());
            buffer.AddRange(EmcIplA.ToArray());
            buffer.AddRange(EmcIplB.ToArray());
            buffer.AddRange(UsbPdcA.ToArray());
            buffer.AddRange(UsbPdcB.ToArray());
            buffer.AddRange(Unk);
            buffer.AddRange(Nvs.ToArray());
            buffer.AddRange(Reserved);
            return buffer.ToArray();

        }
    }
}
