namespace Gemini.NET.Client_Models
{
    /// <summary>
    /// The response with a result and optional grounding details.
    /// </summary>
    public class ModelResponse
    {
        /// <summary>
        /// The response of Gemini.
        /// </summary>
        public required string Result { get; set; }

        /// <summary>
        /// The grounding details of the response.
        /// </summary>
        public GroundingDetail? GroundingDetail { get; set; }
    }
}
