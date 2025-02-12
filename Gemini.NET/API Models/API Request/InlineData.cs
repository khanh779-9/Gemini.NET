using Gemini.NET.API_Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.NET.API_Models.API_Request
{
    public class InlineData
    {
        [JsonProperty("mime_type")]
        public required string MimeType { get; set; }

        [JsonProperty("data")]
        public required string Data { get; set; }
    }
}
