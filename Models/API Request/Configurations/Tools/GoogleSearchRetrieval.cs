using Newtonsoft.Json;

namespace Models.API_Request
{
    public class GoogleSearchRetrieval
    {
        [JsonProperty("dynamic_retrieval_config")]
        public required DynamicRetrievalConfig DynamicRetrievalConfig { get; set; }
    }
}
