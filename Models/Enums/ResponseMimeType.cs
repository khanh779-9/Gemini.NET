using System.ComponentModel;

namespace Models.Enums
{
    public enum ResponseMimeType
    {
        [Description("application/json")]
        Json,

        [Description("text/plain")]
        PlainText
    }
}
