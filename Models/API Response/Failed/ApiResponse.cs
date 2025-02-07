using Newtonsoft.Json;

namespace Models.API_Response.Failed
{
    public class ApiResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
