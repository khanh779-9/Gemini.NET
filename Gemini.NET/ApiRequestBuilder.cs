using Commons;
using Models.API_Request;
using Models.Enums;
using Models.Shared;

namespace Gemini.NET
{
    public class ApiRequestBuilder
    {
        private string? _prompt;
        private string? _systemInstruction;
        private GenerationConfig? _config;
        private bool _useGrounding = false;
        private List<SafetySetting>? _safetySettings;

        public ApiRequestBuilder WithSystemInstruction(string systemInstruction)
        {
            if (string.IsNullOrEmpty(systemInstruction))
            {
                throw new ArgumentNullException(nameof(systemInstruction), "System instruction can't be an empty string.");
            }

            _systemInstruction = systemInstruction.Trim();
            return this;
        }

        public ApiRequestBuilder WithGenerationConfig(GenerationConfig config)
        {
            if (config.Temperature < 0.0F || config.Temperature > 2.0F)
            {
                throw new ArgumentOutOfRangeException(nameof(config), "Temperature must be between 0.0 and 2.0.");
            }

            _config = config;
            return this;
        }

        public ApiRequestBuilder EnableGrounding()
        {
            _useGrounding = true;
            return this;
        }

        public ApiRequestBuilder WithSafetySettings(List<SafetySetting> safetySettings)
        {
            _safetySettings = safetySettings;
            return this;
        }

        public ApiRequestBuilder DisableAllSafetySettings()
        {
            _safetySettings =
            [
                new SafetySetting
                {
                    Category = EnumHelper.GetDescription(SafetySettingHarmCategory.DangerousContent),
                },
                new SafetySetting
                {
                    Category = EnumHelper.GetDescription(SafetySettingHarmCategory.Harassment),
                },
                new SafetySetting
                {
                    Category = EnumHelper.GetDescription(SafetySettingHarmCategory.CivicIntegrity),
                },
                new SafetySetting
                {
                    Category = EnumHelper.GetDescription(SafetySettingHarmCategory.HateSpeech),
                },
                new SafetySetting
                {
                    Category = EnumHelper.GetDescription(SafetySettingHarmCategory.SexuallyExplicit),
                },
            ];

            return this;
        }

        public ApiRequestBuilder WithDefaultGenerationConfig(float temperature = 1, ResponseMimeType responseMimeType = ResponseMimeType.PlainText)
        {
            if (temperature < 0.0F || temperature > 2.0F)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature), "Temperature must be between 0.0 and 2.0.");
            }

            _config = new GenerationConfig
            {
                Temperature = temperature,
                ResponseMimeType = EnumHelper.GetDescription(responseMimeType),
            };

            return this;
        }

        public ApiRequestBuilder WithPrompt(string prompt)
        {
            if (string.IsNullOrEmpty(prompt))
            {
                throw new ArgumentNullException(nameof(prompt), "Prompt can't be an empty string.");
            }

            _prompt = prompt;
            return this;
        }

        public ApiRequest Build()
        {
            if (string.IsNullOrEmpty(_prompt))
            {
                throw new ArgumentNullException(nameof(_prompt), "Prompt can't be an empty string.");
            }

            return new ApiRequest
            {
                Contents =
                [
                    new Content
                    {
                        Parts =
                        [
                            new Part
                            {
                                Text = _prompt
                            }
                        ],
                        Role = EnumHelper.GetDescription(Role.User),
                    }
                ],
                GenerationConfig = _config,
                SafetySettings = _safetySettings,
                Tools = _useGrounding
                    ?
                    [
                        new Tool
                        {
                            GoogleSearch = new GoogleSearch()
                        }
                    ]
                    : null,
                SystemInstruction = string.IsNullOrEmpty(_systemInstruction)
                    ? null
                    : new SystemInstruction
                    {
                        Parts =
                        [
                            new Part
                            {
                                Text = _systemInstruction
                            }
                        ]
                    }
            };
        }
    }
}
