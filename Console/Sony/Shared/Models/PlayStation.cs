using System.Text.Json.Serialization;

namespace ConsoleServiceTool.Console.Sony.Shared.Models
{
    public class PlayStation
    {
        [JsonPropertyName("ErrorCodes")]
        public List<PlayStationErrorCode> ErrorCodes { get; set; }
    }
}
