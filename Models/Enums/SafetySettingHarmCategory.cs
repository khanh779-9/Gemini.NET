using System.ComponentModel;

namespace Models.Enums
{
    /// <summary>
    /// Enum representing different harm categories.
    /// </summary>
    public enum SafetySettingHarmCategory : sbyte
    {
        /// <summary>
        /// Dangerous content category.
        /// </summary>
        [Description("HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent,

        /// <summary>
        /// Harassment category.
        /// </summary>
        [Description("HARM_CATEGORY_HARASSMENT")]
        Harassment,

        /// <summary>
        /// Hate speech category.
        /// </summary>
        [Description("HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        /// <summary>
        /// Sexually explicit content category.
        /// </summary>
        [Description("HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        /// <summary>
        /// Civic integrity category.
        /// </summary>
        [Description("HARM_CATEGORY_CIVIC_INTEGRITY")]
        CivicIntegrity,
    }
}
