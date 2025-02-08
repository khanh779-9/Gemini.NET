using Models.Enums;

namespace Gemini.NET.Client_Models
{
    public class ChatMessage
    {
        public required Role Role { get; set; }
        public required string Content { get; set; }
    }
}
