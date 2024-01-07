using ConsoleServiceTool.Utils;
using System.Buffers.Binary;
using System.Text;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Nvs : INorData
    {

        private readonly byte[] Unknown = new byte[32];
        private byte[] MacAddressData = new byte[6];
        private readonly byte[] Data = new byte[0x2fea]; //0x31DA
        internal ConsoleType ConsoleType;
        private readonly byte[] Unknown0 = new byte[0x1ec];
        private readonly byte[] MotherBoardSerialNumberData = new byte[16];
        private readonly byte[] SerialData = new byte[16];
        private readonly byte[] Unknown1 = new byte[16];
        private readonly byte[] SkuData = new byte[16];
        private readonly byte[] Unknown2 = new byte[16];
        private readonly byte[] BoardIdData = new byte[13];
        private readonly byte[] Unknown3 = new byte[3];
        private readonly byte[] Unknown4 = new byte[0x160];

        private byte[] WifiMacAddressData1 = new byte[6];
        private byte[] WifiMacAddressData2 = new byte[6];
        private byte[] WifiMacAddressData3 = new byte[6];

        private readonly byte[] Unknown5 = new byte[0x2342];

        internal readonly short FirmwareVersion; //offset 0x1C9714
        private readonly byte[] Unknown6 = new byte[0x58EA];

        internal string MacAddress
        {
            get => MacAddressData.ToHexString();
            set => MacAddressData = value.FromHexString();
        }

        internal string MotherBoardSerialNumber
        {
            get => MotherBoardSerialNumberData.ReadCString();
            set
            {
                Array.Clear(MotherBoardSerialNumberData);
                var data = Encoding.ASCII.GetBytes(value);
                Array.Copy(data, MotherBoardSerialNumberData, data.Length);
            }
        }

        internal string Serial
        {
            get => SerialData.ReadCString();
            set
            {
                Array.Clear(SerialData);
                var data = Encoding.ASCII.GetBytes(value);
                Array.Copy(data, SerialData, data.Length);
            }
        }

        internal string Sku
        {
            get => SkuData.ReadCString();
            set
            {
                Array.Clear(SkuData);
                var data = Encoding.ASCII.GetBytes(value);
                Array.Copy(data, SkuData, data.Length);
            }
        }

        internal string BoardId
        {
            get => BoardIdData.ReadCString();
            set
            {
                Array.Clear(BoardIdData);
                var data = Encoding.ASCII.GetBytes(value);
                Array.Copy(data, BoardIdData, data.Length);
            }
        }

        internal string WifiMacAddress
        {
            get => WifiMacAddressData1.ToHexString();
            set => WifiMacAddressData1 = value.FromHexString();
        }

        internal string WifiMacAddress1
        {
            get => WifiMacAddressData2.ToHexString();
            set => WifiMacAddressData2 = value.FromHexString();
        }

        internal string WifiMacAddress2
        {
            get => WifiMacAddressData3.ToHexString();
            set => WifiMacAddressData3 = value.FromHexString();
        }

        internal Nvs(BinaryReader reader)
        {
            Unknown = reader.ReadBytes(Unknown.Length);
            MacAddressData = reader.ReadBytes(MacAddressData.Length);
            Data = reader.ReadBytes(Data.Length);
            ConsoleType = (ConsoleType)BinaryPrimitives.ReverseEndianness(reader.ReadUInt32());
            Unknown0 = reader.ReadBytes(Unknown0.Length);
            MotherBoardSerialNumberData = reader.ReadBytes(MotherBoardSerialNumberData.Length);
            SerialData = reader.ReadBytes(SerialData.Length);
            Unknown1 = reader.ReadBytes(Unknown1.Length);
            SkuData = reader.ReadBytes(SkuData.Length);
            Unknown2 = reader.ReadBytes(Unknown2.Length);
            BoardIdData = reader.ReadBytes(BoardIdData.Length);
            Unknown3 = reader.ReadBytes(Unknown3.Length);
            Unknown4 = reader.ReadBytes(Unknown4.Length);
            WifiMacAddressData1 = reader.ReadBytes(WifiMacAddressData1.Length);
            WifiMacAddressData2 = reader.ReadBytes(WifiMacAddressData2.Length);
            WifiMacAddressData3 = reader.ReadBytes(WifiMacAddressData3.Length);
            Unknown5 = reader.ReadBytes(Unknown5.Length);
            FirmwareVersion = reader.ReadInt16();
            Unknown6 = reader.ReadBytes(Unknown6.Length);
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Unknown);
            buffer.AddRange(MacAddressData);
            buffer.AddRange(Data);
            var data = new byte[sizeof(uint)];
            BinaryPrimitives.WriteUInt32BigEndian(data, (uint)ConsoleType);
            buffer.AddRange(data);
            buffer.AddRange(Unknown0);
            buffer.AddRange(MotherBoardSerialNumberData);
            buffer.AddRange(SerialData);
            buffer.AddRange(Unknown1);
            buffer.AddRange(SkuData);
            buffer.AddRange(Unknown2);
            buffer.AddRange(BoardIdData);
            buffer.AddRange(Unknown3);
            buffer.AddRange(Unknown4);
            buffer.AddRange(WifiMacAddressData1);
            buffer.AddRange(WifiMacAddressData2);
            buffer.AddRange(WifiMacAddressData3);
            buffer.AddRange(Unknown5);
            data = new byte[sizeof(short)];
            BinaryPrimitives.WriteInt16LittleEndian(data, FirmwareVersion);
            buffer.AddRange(data);
            buffer.AddRange(Unknown6);
            return buffer.ToArray();
        }
    }
}
