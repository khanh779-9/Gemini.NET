using Gemini.NET.API_Models.Enums;
using Gemini.NET.Client_Models;

namespace Gemini.NET.Helpers
{
    /// <summary>
    /// Helper class for image operations
    /// </summary>
    public static class ImageHelper
    {
        private static readonly List<MimeType> _imageMimeTypes =
        [
            MimeType.ImagePng,
            MimeType.ImageJpeg,
            MimeType.ImageHeic,
            MimeType.ImageHeif,
            MimeType.ImageWebp,
        ];

        /// <summary>
        /// Reads an image file and returns it as a Base64 encoded string
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static ImageData ReadImage(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException("Image file not found", imagePath);
            }

            var imageFormat = Path.GetExtension(imagePath).TrimStart('.');

            if (_imageMimeTypes.Exists(_imageMimeTypes => _imageMimeTypes.ToString().EndsWith(imageFormat, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Unsupported image format", nameof(imagePath));
            }

            var mimeType = _imageMimeTypes.Find(t => t.ToString().EndsWith(imageFormat, StringComparison.OrdinalIgnoreCase));

            var bytes = File.ReadAllBytes(imagePath);

            return new ImageData
            {
                Base64Data = Convert.ToBase64String(bytes),
                MimeType = mimeType
            };
        }
    }
}
