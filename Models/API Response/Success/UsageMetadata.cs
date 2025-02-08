using Newtonsoft.Json;

namespace Models.API_Response.Success
{
    /// <summary>
    /// Represents metadata about the usage of the API.
    /// </summary>
    public class UsageMetadata
    {
        /// <summary>
        /// Gets or sets the prompt token count.
        /// </summary>
        [JsonProperty("promptTokenCount")]
        public int? PromptTokenCount { get; set; }

        /// <summary>
        /// Gets or sets the candidates token count.
        /// </summary>
        [JsonProperty("candidatesTokenCount")]
        public int? CandidatesTokenCount { get; set; }

        /// <summary>
        /// Gets or sets the total token count.
        /// </summary>
        [JsonProperty("totalTokenCount")]
        public int? TotalTokenCount { get; set; }

        /// <summary>
        /// Gets or sets the details of the prompt tokens.
        /// </summary>
        [JsonProperty("promptTokensDetails")]
        public List<PromptTokensDetail>? PromptTokensDetails { get; set; }

        /// <summary>
        /// Gets or sets the details of the candidates tokens.
        /// </summary>
        [JsonProperty("candidatesTokensDetails")]
        public List<CandidatesTokensDetail>? CandidatesTokensDetails { get; set; }
    }
}
