using System.ComponentModel;

namespace Models.Enums
{

    /// <summary>
    /// Enum representing the harm block threshold settings.
    /// For more details, refer to <see href="https://ai.google.dev/api/generate-content#HarmBlockThreshold"/>.
    /// </summary>
    public enum SafetySettingHarmThreshold
    {
        /// <summary>
        /// Block when the probability score or the severity score is "LOW", MEDIUM or HIGH.
        /// </summary>
        [Description("BLOCK_LOW_AND_ABOVE")]
        BlockLowAndAbove,

        /// <summary>
        /// Block when the probability score or the severity score is MEDIUM or HIGH. 
        /// </summary>
        [Description("BLOCK_MEDIUM_AND_ABOVE")]
        BlockMediumAndAbove,

        /// <summary>
        /// Content with NEGLIGIBLE and LOW will be allowed.
        /// </summary>
        [Description("BLOCK_ONLY_HIGH")]
        BlockOnlyHigh,

        /// <summary>
        /// Block using the default threshold.
        /// </summary>
        [Description("HARM_BLOCK_THRESHOLD_UNSPECIFIED")]
        HarmBlockThresholdUnspecified,

        /// <summary>
        /// Turn off the safety filter. 
        /// </summary>
        [Description("OFF")]
        Off,

        /// <summary>
        /// All content will be allowed. 
        /// </summary>
        [Description("BLOCK_NONE")]
        BlockNone
    }
}
