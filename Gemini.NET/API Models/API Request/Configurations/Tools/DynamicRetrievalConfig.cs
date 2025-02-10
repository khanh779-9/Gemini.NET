using Newtonsoft.Json;

namespace Models.Request
{
    public class DynamicRetrievalConfig
    {
        [JsonProperty("mode")]
        public required string Mode { get; set; } = "MODE_DYNAMIC";

        [JsonProperty("dynamic_threshold")]
        public required float DynamicThreshold { get; set; } = 0.3F;
    }
}
