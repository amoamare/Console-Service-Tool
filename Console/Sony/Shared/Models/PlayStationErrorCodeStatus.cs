using System.Text.Json.Serialization;

namespace ConsoleServiceTool.Console.Sony.Shared.Models
{
    public enum PlayStationErrorCodeStatus
    {
        [JsonPropertyName("Unknown")]
        Unknown,
        [JsonPropertyName("Unconfirmed")]
        Unconfirmed,
        [JsonPropertyName("User Submitted")]
        UserSubmitted,
        [JsonPropertyName("Confirmed")]
        Confirmed
    }
}
