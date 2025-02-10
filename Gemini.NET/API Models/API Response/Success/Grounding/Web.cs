using Newtonsoft.Json;

namespace Models.Response.Success
{
    public class Web
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
