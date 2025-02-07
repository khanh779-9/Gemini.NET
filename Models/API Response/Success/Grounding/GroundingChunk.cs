using Newtonsoft.Json;

namespace Models.API_Response.Success
{
    public class GroundingChunk
    {
        [JsonProperty("web")]
        public Web Web { get; set; }
    }
}
