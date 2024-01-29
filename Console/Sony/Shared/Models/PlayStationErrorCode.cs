using System.Text.Json.Serialization;


namespace ConsoleServiceTool.Console.Sony.Shared.Models
{
    public class PlayStationErrorCode
    {
        [JsonPropertyName("ID")]
        public required string ID { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("Status")]
        public PlayStationErrorCodeStatus Status { get; set; }

        [JsonPropertyName("Priority")]
        public Priority Priority { get; set; }


        [JsonPropertyName("ReferenceImage")]
        public Uri? ReferenceImage { get; set; }
    }
}
