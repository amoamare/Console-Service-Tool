using System.Text.Json.Serialization;

namespace ConsoleServiceTool.Console.Sony.Shared.Models
{
    public class PlayStation
    {
        [JsonPropertyName("ErrorCodes")]
        public required List<PlayStationErrorCode> ErrorCodes { get; set; }
    }
}
