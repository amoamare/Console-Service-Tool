using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    [Flags]
    internal enum BiosMemoryTestFlag : byte
    {
        [Description("CachedAndUncached")]
        CachedAndUncached = 0x50,
        [Description("Disabled")]
        Disabled = 0xFF
    }
}
