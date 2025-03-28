using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    [Flags]
    internal enum MpMemoryTestFlag : byte
    {
        [Description("Enabled")]
        Enabled = 0x01,
        [Description("Disabled")]
        Disabled = 0xFF
    }
}
