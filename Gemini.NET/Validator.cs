using Models.Enums;

namespace Gemini.NET
{
    public static class Validator
    {
        public static bool SupportsGrouding(ModelVersion modelVersion)
        {
            var supportedVersions = new List<ModelVersion>
            {
                ModelVersion.Gemini_20_Flash,
            };

            return supportedVersions.Contains(modelVersion);
        }

        public static bool SupportsJsonOutput(ModelVersion modelVersion)
        {
            var notSupportedVersions = new List<ModelVersion>
            {
                ModelVersion.Gemini_20_Flash_Thinking,
            };

            return !notSupportedVersions.Contains(modelVersion);
        }

        public static bool CanBeValidApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return false;
            }

            if (apiKey.Length != 39 || apiKey.StartsWith("AIza"))
            {
                return false;
            }

            return true;
        }
    }
}
