using Newtonsoft.Json;

namespace Models.Shared
{
    public class Part
    {
        [JsonProperty("text")]
        public required string Text { get; set; }
    }
}
