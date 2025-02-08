using System.ComponentModel;

namespace Models.Enums
{
    /// <summary>
    /// Enum representing different model versions.
    /// </summary>
    public enum ModelVersion : sbyte
    {
        /// <summary>
        /// Undefined model version.
        /// </summary>
        [Description("undefined")]
        Undefined,

        /// <summary>
        /// Gemini 1.5 Flash model version.
        /// </summary>
        [Description("gemini-1.5-flash")]
        Gemini_15_Flash,

        /// <summary>
        /// Gemini 1.5 Pro model version.
        /// </summary>
        [Description("gemini-1.5-pro")]
        Gemini_15_Pro,

        /// <summary>
        /// Gemini 2.0 Flash Lite model version.
        /// </summary>
        [Description("gemini-2.0-flash-lite-preview-02-05")]
        Gemini_20_Flash_Lite,

        /// <summary>
        /// Gemini 2.0 Pro model version.
        /// </summary>
        [Description("gemini-2.0-pro-exp-02-05")]
        Gemini_20_Pro,

        /// <summary>
        /// Gemini 2.0 Flash Thinking model version.
        /// </summary>
        [Description("gemini-2.0-flash-thinking-exp-01-21")]
        Gemini_20_Flash_Thinking,

        /// <summary>
        /// Gemini 2.0 Flash model version.
        /// </summary>
        [Description("gemini-2.0-flash")]
        Gemini_20_Flash,
    }
}
