using Newtonsoft.Json;

namespace Models.API_Response.Success
{
    public class UsageMetadata
    {
        [JsonProperty("promptTokenCount")]
        public int? PromptTokenCount { get; set; }

        [JsonProperty("candidatesTokenCount")]
        public int? CandidatesTokenCount { get; set; }

        [JsonProperty("totalTokenCount")]
        public int? TotalTokenCount { get; set; }

        [JsonProperty("promptTokensDetails")]
        public List<PromptTokensDetail>? PromptTokensDetails { get; set; }

        [JsonProperty("candidatesTokensDetails")]
        public List<CandidatesTokensDetail>? CandidatesTokensDetails { get; set; }
    }
}
