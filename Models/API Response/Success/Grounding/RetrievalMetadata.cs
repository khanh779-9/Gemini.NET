using Newtonsoft.Json;

namespace Models.API_Response.Success
{
    public class RetrievalMetadata
    {
        [JsonProperty("googleSearchDynamicRetrievalScore")]
        public double? GoogleSearchDynamicRetrievalScore { get; set; }
    }
}
