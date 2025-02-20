using Newtonsoft.Json;

namespace Gemini.NET.API_Models.API_Request
{
    public class InlineData
    {
        [JsonProperty("mime_type")]
        public required string MimeType { get; set; }

        [JsonProperty("data")]
        public required string Data { get; set; }
    }
}
