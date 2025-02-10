using Newtonsoft.Json;

namespace Models.Response.Success
{
    public class RetrievalMetadata
    {
        [JsonProperty("googleSearchDynamicRetrievalScore")]
        public double? GoogleSearchDynamicRetrievalScore { get; set; }
    }
}
