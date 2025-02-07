using Newtonsoft.Json;

namespace Models.Shared
{
    public class Tool
    {
        [JsonProperty("googleSearch")]
        public GoogleSearch? GoogleSearch { get; set; } = new GoogleSearch();
    }
}
