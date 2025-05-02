using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal class NvsOS : INorData
    {
        private byte[] Unknown0 = new byte[0x068]; //offset 0x1C8000
        internal readonly int FirmwareVersion; //offset 0x1C8068
        private byte[] Unknown1 = new byte[0x294]; //offset 0x1C8000
        private BootMessageModeFlag _bootMessageModeFlag; //offset 0x1C8300
        private MpMemoryTestFlag _mpMemoryTestFlag;       //offset 0x1C8301
        private byte[] Unknown2 = new byte[2]; //offset 0x1C8302
        private AblDebugPrintFlag _ablDebugPrintFlag;     //offset 0x1C8304
        private byte[] Unknown3 = new byte[0xB]; //offset 0x1C8305
        private BiosMemoryTestFlag _biosMemoryTestFlag;   //offset 0x1C8310
        private byte[] Unknown4 = new byte[0xC6F]; //offset 0x1C8311
        private ManufacturingFlag _manufacturingFlag;     //offset 0x1C8F80
        private byte[] Unknown5 = new byte[0x67F]; //offset 0x1C8311
        private InterfaceDemonstrationUnit _idu; //offset 0x1C9600
        private byte[] Unknown6 = new byte[0x19FF]; //offset 0x1C8F81

        // Properties
        internal BootMessageModeFlag BootMessageModeFlag
        {
            get => _bootMessageModeFlag;
            set => _bootMessageModeFlag = value;
        }

        internal MpMemoryTestFlag MpMemoryTestFlag
        {
            get => _mpMemoryTestFlag;
            set => _mpMemoryTestFlag = value;
        }

        internal AblDebugPrintFlag AblDebugPrintFlag
        {
            get => _ablDebugPrintFlag;
            set => _ablDebugPrintFlag = value;
        }

        internal BiosMemoryTestFlag BiosMemoryTestFlag
        {
            get => _biosMemoryTestFlag;
            set => _biosMemoryTestFlag = value;
        }

        internal ManufacturingFlag ManufacturingFlag
        {
            get => _manufacturingFlag;
            set => _manufacturingFlag = value;
        }

        internal InterfaceDemonstrationUnit InterfaceDemonstrationUnit
        {
            get => _idu;
            set => _idu = value;
        }

        // Constructor
        internal NvsOS(BinaryReader reader)
        {
            Debug.WriteLine($"1 offset Unknown0: 0x{reader.BaseStream.Position:X2}");
            Unknown0 = reader.ReadBytes(Unknown0.Length);
            Debug.WriteLine($"1 offset FirmwareVersion: 0x{reader.BaseStream.Position:X2}");
            FirmwareVersion = reader.ReadInt32();
            Debug.WriteLine($"1 offset Unknown1: 0x{reader.BaseStream.Position:X2}");
            Unknown1 = reader.ReadBytes(Unknown1.Length);
            Debug.WriteLine($"1 offset BootMessageModeFlag: 0x{reader.BaseStream.Position:X2}");
            _bootMessageModeFlag = (BootMessageModeFlag)reader.ReadByte();
            Debug.WriteLine($"1 offset MpMemoryTestFlag: 0x{reader.BaseStream.Position:X2}");
            _mpMemoryTestFlag = (MpMemoryTestFlag)reader.ReadByte();
            Debug.WriteLine($"1 offset Unknown2: 0x{reader.BaseStream.Position:X2}");
            Unknown2 = reader.ReadBytes(Unknown2.Length);
            Debug.WriteLine($"1 offset AblDebugPrintFlag: 0x{reader.BaseStream.Position:X2}");
            _ablDebugPrintFlag = (AblDebugPrintFlag)reader.ReadByte();
            Debug.WriteLine($"1 offset Unknown3: 0x{reader.BaseStream.Position:X2}");
            Unknown3 = reader.ReadBytes(Unknown3.Length);
            Debug.WriteLine($"1 offset BiosMemoryTestFlag: 0x{reader.BaseStream.Position:X2}");
            _biosMemoryTestFlag = (BiosMemoryTestFlag)reader.ReadByte();
            Debug.WriteLine($"1 offset Unknown4: 0x{reader.BaseStream.Position:X2}");
            Unknown4 = reader.ReadBytes(Unknown4.Length);
            Debug.WriteLine($"1 offset ManufacturingFlag: 0x{reader.BaseStream.Position:X2}");
            _manufacturingFlag = (ManufacturingFlag)reader.ReadByte();
            Debug.WriteLine($"1 offset Unknown5: 0x{reader.BaseStream.Position:X2}");
            Unknown5 = reader.ReadBytes(Unknown5.Length);
            Debug.WriteLine($"1 offset InterfaceDemonstrationUnit: 0x{reader.BaseStream.Position:X2}");
            _idu = (InterfaceDemonstrationUnit)reader.ReadByte();
            Debug.WriteLine($"1 offset Unknown6: 0x{reader.BaseStream.Position:X2}");
            Unknown6 = reader.ReadBytes(Unknown6.Length);
            
        }

        public byte[] ToArray()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Unknown0);
            buffer.AddRange(BitConverter.GetBytes(FirmwareVersion));
            buffer.AddRange(Unknown1);
            buffer.Add((byte)_bootMessageModeFlag);
            buffer.Add((byte)_mpMemoryTestFlag);
            buffer.AddRange(Unknown2);
            buffer.Add((byte)_ablDebugPrintFlag);
            buffer.AddRange(Unknown3);
            buffer.Add((byte)_biosMemoryTestFlag);
            buffer.AddRange(Unknown4);
            buffer.Add((byte)_manufacturingFlag);
            buffer.AddRange(Unknown5);
            buffer.Add((byte)_idu);
            buffer.AddRange(Unknown6);

            return buffer.ToArray();
        }
    }
}
