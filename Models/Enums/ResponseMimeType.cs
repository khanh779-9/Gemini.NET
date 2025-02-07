using System.ComponentModel;

namespace Models.Enums
{
    public enum ResponseMimeType : sbyte
    {
        [Description("application/json")]
        Json,

        [Description("text/plain")]
        PlainText
    }
}
