using System.Text.Json.Serialization;

namespace ConsoleServiceTool.Console.Sony.Shared.Models
{
    public class PS5ErrorCodeList
    {
        [JsonPropertyName("Revision")]
        public required Version Revision { get; set; }

        [JsonPropertyName("Description")]
        public required string Description { get; set; }

        [JsonPropertyName("PlayStation5")]
        public PlayStation? PlayStation5 { get; set; }

        [JsonPropertyName("PlayStation4")]
        public PlayStation? PlayStation4 { get; set; }
        [JsonPropertyName("PlayStation3")]
        public PlayStation? PlayStation3 { get; set; }
    }
}
