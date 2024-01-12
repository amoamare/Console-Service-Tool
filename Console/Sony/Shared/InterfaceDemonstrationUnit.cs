using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    [Flags]
    internal enum InterfaceDemonstrationUnit : byte
    {
        [Description("Disabled")]
        Disabled = 0xff | 0x00,
        [Description("Enabled")]
        Enabled = 0x01
    }
}
