using Newtonsoft.Json;

namespace Models.API_Response.Failed
{
    public class FieldViolation
    {
        [JsonProperty("field")]
        public string Field;

        [JsonProperty("description")]
        public string Description;
    }
}
