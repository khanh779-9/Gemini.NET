using Commons;
using Models.Enums;
using Newtonsoft.Json;

namespace Models.API_Request
{
    public class SafetySetting
    {
        [JsonProperty("category")]
        public required string Category { get; set; }

        [JsonProperty("threshold")]
        public string Threshold { get; set; } = EnumHelper.GetDescription(SafetySettingHarmThreshold.BlockNone);
    }
}
