using ConsoleServiceTool.Utils;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Nor : INorData
    {
        internal const long ExpectedSize = 2097152L;
        internal NorHeader Header;
        internal NorActiveSlot ActiveSlot;
        internal NorMbr Mbr1;
        internal NorMbr Mbr2;
        internal Slb2 EmcIplA;
        internal Slb2 EmcIplB;
        internal Slb2 UsbPdcA;
        internal Slb2 UsbPdcB;
        internal byte[] Unk = new byte[0xA4000];
        internal Nvs Nvs;
        internal byte[] Reserved = new byte[0x31000];

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
