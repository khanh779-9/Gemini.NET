using Newtonsoft.Json;

namespace Models.Shared
{
    public class Content
    {
        [JsonProperty("role")]
        public required string Role { get; set; }

        [JsonProperty("parts")]
        public required List<Part> Parts { get; set; }
    }
}
