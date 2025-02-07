using Newtonsoft.Json;

namespace Models.API_Response.Failed
{
    public class Detail
    {
        [JsonProperty("@type")]
        public string Type;

        [JsonProperty("fieldViolations")]
        public List<FieldViolation> FieldViolations;
    }
}
