using ConsoleServiceTool.Utils;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Text;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class Nvs : INorData
    {

        private readonly byte[] Unknown = new byte[32]; //offset 0x1C4000
        private byte[] MacAddressData = new byte[6]; //offset 0x1C4020
        private readonly byte[] Data = new byte[0x2fea]; //offset 0x1C4026
        internal ConsoleType ConsoleType; //offset 0x1C7010
        private readonly byte[] Unknown0 = new byte[0x1ec]; //offset 0x1C7014
        private readonly byte[] MotherBoardSerialNumberData = new byte[16]; //offset 0x1C7200 
        private readonly byte[] SerialData = new byte[16]; //offset 0x1C7210
        private readonly byte[] Unknown1 = new byte[16]; //offset 0x1C7220
        private readonly byte[] SkuData = new byte[16]; //offset 0x1C7230
        private readonly byte[] Unknown2 = new byte[16]; //offset 0x1C7240
        private readonly byte[] BoardIdData = new byte[13]; //offset 0x1C7250
        private readonly byte[] Unknown3 = new byte[3]; //offset 0x1C725D
        private readonly byte[] Unknown4 = new byte[0x160]; //offset 0x1C7260

        private byte[] WifiMacAddressData1 = new byte[6]; //offset 0x1C73C0
        private byte[] WifiMacAddressData2 = new byte[6]; //offset 0x1C73C6
        private byte[] WifiMacAddressData3 = new byte[6]; //offset 0x1C73CC

        private readonly byte[] Unknown5 = new byte[0x222E]; //offset 0x1C73D2 0x222E //origianl 0x2342

        internal InterfaceDemonstrationUnit Idu; //offset 0x1C9600

        private readonly byte[] Unknown6 = new byte[0x113]; //offset 0x1C9601

        internal readonly short FirmwareVersion; //offset 0x1C9714
        private readonly byte[] Unknown7 = new byte[0x58EA]; //offset 0x1C9716

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

            Idu = (InterfaceDemonstrationUnit)reader.ReadByte();
            Unknown6 = reader.ReadBytes(Unknown6.Length);
            FirmwareVersion = reader.ReadInt16(); 
            Debug.WriteLine($"1 offset: 0x{reader.BaseStream.Position:X2}");
            Unknown7 = reader.ReadBytes(Unknown7.Length);
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
            buffer.Add((byte)Idu);
            buffer.AddRange(Unknown6); 
            data = new byte[sizeof(short)];
            BinaryPrimitives.WriteInt16LittleEndian(data, FirmwareVersion);
            buffer.AddRange(data);
            buffer.AddRange(Unknown7);
            return buffer.ToArray();
        }
    }
}
