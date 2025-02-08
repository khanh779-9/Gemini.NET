using Models.Shared;
using Newtonsoft.Json;

namespace Models.API_Request
{
    public class ApiRequest
    {
        [JsonProperty("contents")]
        public List<Content> Contents { get; set; }

        [JsonProperty("generationConfig")]
        public GenerationConfig GenerationConfig { get; set; }

        [JsonProperty("systemInstruction")]
        public SystemInstruction? SystemInstruction { get; set; }

        [JsonProperty("tools")]
        public List<Tool>? Tools { get; set; }

        [JsonProperty("safetySettings")]
        public List<SafetySetting>? SafetySettings { get; set; }
    }
}
