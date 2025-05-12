using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    [Flags]
    internal enum AblDebugPrintFlag : byte
    {
        [Description("Enabled")]
        Enabled = 0x01,
        [Description("Disabled")]
        Disabled = 0xFF
    }
}
