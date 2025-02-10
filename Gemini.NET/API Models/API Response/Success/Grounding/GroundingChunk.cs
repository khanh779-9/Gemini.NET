using Newtonsoft.Json;

namespace Models.Response.Success
{
    public class GroundingChunk
    {
        [JsonProperty("web")]
        public Web Web { get; set; }
    }
}
