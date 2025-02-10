using Newtonsoft.Json;

namespace Models.Request
{
    public class GoogleSearchRetrieval
    {
        [JsonProperty("dynamic_retrieval_config")]
        public required DynamicRetrievalConfig DynamicRetrievalConfig { get; set; }
    }
}
