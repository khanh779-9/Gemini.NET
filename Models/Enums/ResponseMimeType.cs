using System.ComponentModel;

namespace Models.Enums
{
    /// <summary>
    /// Enum representing different response MIME types.
    /// </summary>
    public enum ResponseMimeType : sbyte
    {
        /// <summary>
        /// JSON response MIME type.
        /// </summary>
        [Description("application/json")]
        Json,

        /// <summary>
        /// Plain text response MIME type.
        /// </summary>
        [Description("text/plain")]
        PlainText
    }
}
