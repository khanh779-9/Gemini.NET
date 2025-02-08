namespace Gemini.NET.Response_Models
{
    public class Response
    {
        public required string Result { get; set; }
        public GroundingDetail? GroundingDetail { get; set; }
    }
}
