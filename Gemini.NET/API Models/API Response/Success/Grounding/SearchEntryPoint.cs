using Newtonsoft.Json;

namespace Models.Response.Success
{
    public class SearchEntryPoint
    {
        [JsonProperty("renderedContent")]
        public string? RenderedContent { get; set; }
    }
}
