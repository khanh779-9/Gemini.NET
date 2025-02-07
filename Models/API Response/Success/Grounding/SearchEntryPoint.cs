using Newtonsoft.Json;

namespace Models.API_Response.Success
{
    public class SearchEntryPoint
    {
        [JsonProperty("renderedContent")]
        public string RenderedContent { get; set; }
    }
}
