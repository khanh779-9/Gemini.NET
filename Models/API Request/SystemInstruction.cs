using Commons;
using Models.Shared;
using Newtonsoft.Json;

namespace Models.API_Request
{
    public class SystemInstruction
    {
        [JsonProperty("role")]
        public string Role { get; set; } = EnumHelper.GetDescription(Enums.Role.User);

        [JsonProperty("parts")]
        public required List<Part> Parts { get; set; }
    }
}
