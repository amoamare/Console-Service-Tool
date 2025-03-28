using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    [Flags]
    internal enum BootMessageModeFlag : byte
    {
        [Description("Debug")]
        Debug = 0x02,
        [Description("Disabled")]
        Disabled = 0xFF
    }
}
