namespace Gemini.NET.Response_Models
{
    public class GroundingDetail
    {
        public required string? RenderedContentAsHtml { get; set; }
        public List<GroundingSource>? Sources { get; set; }
        public List<string>? ReliableInformation { get; set; }
        public List<string>? SearchSuggestions { get; set; }
    }
}
