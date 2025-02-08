using Newtonsoft.Json;

namespace Models.API_Response
{
    /// <summary>
    /// Represents details about the candidates tokens.
    /// </summary>
    public class CandidatesTokensDetail
    {
        /// <summary>
        /// Gets or sets the modality of the candidates tokens.
        /// </summary>
        [JsonProperty("modality")]
        public string? Modality { get; set; }

        /// <summary>
        /// Gets or sets the token count of the candidates tokens.
        /// </summary>
        [JsonProperty("tokenCount")]
        public int? TokenCount { get; set; }
    }
}
