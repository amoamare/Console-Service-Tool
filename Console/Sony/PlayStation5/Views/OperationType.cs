using System.ComponentModel;


namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    internal enum OperationType
    {
        [Description("Read Error Codes")]
        ReadErrorCodes,
        [Description("Clear Error Codes")]
        ClearErrorCodes,
        [Description("Monitor Mode")]
        MonitorMode,
        [Description("Run Command Lists")]
        RunCommandList,
        [Description("Run Raw Command")]
        RunRawCommand,
        [Description("Code Lookup")]
        CodeLookUp
    }
}
