using System.Text.RegularExpressions;

namespace ConsoleServiceTool.Utils
{
    public static partial class MacValidator
    {
        private static readonly Regex Regex = MacRegex();

        public static bool IsValidMac(string mac) => !string.IsNullOrWhiteSpace(mac) && Regex.IsMatch(mac);
        
        [GeneratedRegex(@"^([0-9A-Fa-f]{2}([:-]?)){5}[0-9A-Fa-f]{2}$", RegexOptions.Compiled)]
        private static partial Regex MacRegex();
    }
}
