using Newtonsoft.Json;

namespace Models.Shared
{
    /// <summary>
    /// Represents the content with a role and parts.
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Gets or sets the role of the content.
        /// </summary>
        [JsonProperty("role")]
        public required string Role { get; set; }

        /// <summary>
        /// Gets or sets the parts of the content.
        /// </summary>
        [JsonProperty("parts")]
        public required List<Part> Parts { get; set; }
    }
}
