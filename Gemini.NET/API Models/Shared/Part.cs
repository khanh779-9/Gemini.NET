using Newtonsoft.Json;

namespace Models.Shared
{
    /// <summary>
    /// Represents a single part of a content block in the API request/response.
    /// Parts are the basic building blocks of messages in the conversation,
    /// allowing for structured content delivery in the API communication.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// The text content of this part.
        /// This is a required field that contains the actual message text or data.
        /// Multiple parts can be combined within a Content object to form a complete message.
        /// </summary>
        [JsonProperty("text")]
        public required string Text { get; set; }
    }
}
