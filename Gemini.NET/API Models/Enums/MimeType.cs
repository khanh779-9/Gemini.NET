using System.ComponentModel;

namespace Gemini.NET.API_Models.Enums
{
    /// <summary>
    /// The media type of the file specified in the Inline Data
    /// </summary>
    public enum MimeType
    {
        /// <summary>
        /// MIME type for PNG images.
        /// </summary>
        [Description("image/png")]
        ImagePng,

        /// <summary>
        /// JPEG images.
        /// </summary>
        [Description("image/jpeg")]
        ImageJpeg,

        /// <summary>
        /// WEBP images.
        /// </summary>
        [Description("image/webp")]
        ImageWebp,

        /// <summary>
        /// HEIC images.
        /// </summary>
        [Description("image/heic")]
        ImageHeic,

        /// <summary>
        /// HEIF images.
        /// </summary>
        [Description("image/heif")]
        ImageHeif,
    }
}
