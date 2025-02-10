using Newtonsoft.Json;

namespace Models.Response.Failed
{
    public class ApiResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
