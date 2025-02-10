using Newtonsoft.Json;

namespace Models.Response.Failed
{
    public class Detail
    {
        [JsonProperty("@type")]
        public string Type;

        [JsonProperty("fieldViolations")]
        public List<FieldViolation> FieldViolations;
    }
}
