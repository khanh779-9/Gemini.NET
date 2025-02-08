using Newtonsoft.Json;

namespace Models.API_Response
{
    /// <summary>
    /// Represents details about the prompt tokens.
    /// </summary>
    public class PromptTokensDetail
    {
        /// <summary>
        /// Gets or sets the modality of the prompt tokens.
        /// </summary>
        [JsonProperty("modality")]
        public string Modality { get; set; }

        /// <summary>
        /// Gets or sets the token count of the prompt tokens.
        /// </summary>
        [JsonProperty("tokenCount")]
        public int? TokenCount { get; set; }
    }
}
