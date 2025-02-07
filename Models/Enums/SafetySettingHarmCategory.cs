using System.ComponentModel;

namespace Models.Enums
{
    public enum SafetySettingHarmCategory
    {
        [Description("HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent,

        [Description("HARM_CATEGORY_HARASSMENT")]
        Harassment,

        [Description("HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        [Description("HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        [Description("HARM_CATEGORY_CIVIC_INTEGRITY")]
        CivicIntegrity,
    }
}
