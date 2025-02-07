using System.ComponentModel;

namespace Models.Enums
{
    public enum ModelVersion : sbyte
    {
        [Description("undefined")]
        Undefined,

        [Description("gemini-1.5-flash")]
        Gemini_15_Flash,

        [Description("gemini-1.5-pro")]
        Gemini_15_Pro,

        [Description("gemini-2.0-flash-lite-preview-02-05")]
        Gemini_20_Flash_Lite,

        [Description("gemini-2.0-pro-exp-02-05")]
        Gemini_20_Pro,

        [Description("gemini-2.0-flash-thinking-exp-01-21")]
        Gemini_20_Flash_Thinking,

        [Description("gemini-2.0-flash")]
        Gemini_20_Flash,
    }
}
