using System.ComponentModel;

namespace ConsoleServiceTool.Console.Sony.PlayStation5
{
    internal enum UartErrors : uint
    {
        [Description("Bad Checksum")]
        BadCheckSum = 0xE0000004,

        [Description("Command Not Found")]
        CommandNotFound = 0xF0000006,

        [Description("Incorrect Argument")]
        IncorrectArgument = 0xF0000001
    }
}
