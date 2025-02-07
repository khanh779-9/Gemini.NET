using Commons;
using Newtonsoft.Json;

namespace Models.API_Request
{
    public class GenerationConfig
    {
        [JsonProperty("temperature")]
        public float Temperature { get; set; } = 1;

        [JsonProperty("topK")]
        public sbyte TopK { get; set; } = 40;

        [JsonProperty("topP")]
        public float TopP { get; set; } = 0.95F;

        [JsonProperty("maxOutputTokens")]
        public int MaxOutputTokens { get; set; } = 8192;

        [JsonProperty("responseMimeType")]
        public string ResponseMimeType { get; set; } = EnumHelper.GetDescription(Enums.ResponseMimeType.PlainText);
    }
}
