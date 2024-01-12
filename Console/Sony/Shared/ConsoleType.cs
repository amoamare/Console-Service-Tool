using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.Shared
{
    internal enum ConsoleType
    {
        [Description("Slim Edition")]
        SlimEdition = 0x22010101,
        [Description("Disk")]
        Disk = 0x22020101,
        [Description("Digital")]
        Digitial = 0x022030101
    }
}
