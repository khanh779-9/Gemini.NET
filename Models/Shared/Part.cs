using Newtonsoft.Json;

namespace Models.Shared
{
    /// <summary>
    /// Represents a part of the content.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Gets or sets the text of the part.
        /// </summary>
        [JsonProperty("text")]
        public required string Text { get; set; }
    }
}
