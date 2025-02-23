using Gemini.NET.API_Models.API_Request;
using Gemini.NET.Client_Models;
using Gemini.NET.Helpers;
using Models.Enums;
using Models.Request;
using Models.Shared;

namespace Gemini.NET
{
    /// <summary>
    /// Builder class for constructing API requests to the Gemini service.
    /// Provides methods to set various parameters and configurations for the request.
    /// </summary>
    public class ApiRequestBuilder
    {
        private string? _prompt;
        private string? _systemInstruction;
        private bool _useGrounding = false;
        private GenerationConfig? _config;
        private List<SafetySetting>? _safetySettings;
        private List<Content>? _chatHistory;
        private List<ImageData>? _images;

        /// <summary>
        /// Sets the system instruction.
        /// </summary>
        /// <param name="systemInstruction">The system instruction to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the system instruction is null or empty.</exception>
        public ApiRequestBuilder WithSystemInstruction(string systemInstruction)
        {
            if (string.IsNullOrWhiteSpace(systemInstruction))
            {
                throw new ArgumentNullException(nameof(systemInstruction), "System instruction can't be an empty string.");
            }

            _systemInstruction = systemInstruction.Trim();
            return this;
        }

        /// <summary>
        /// Sets the generation configuration.
        /// </summary>
        /// <param name="config">The generation configuration to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the temperature is out of the valid range (0.0 to 2.0).</exception>
        public ApiRequestBuilder WithGenerationConfig(GenerationConfig config)
        {
            if (config.Temperature < 0.0F || config.Temperature > 2.0F)
            {
                throw new ArgumentOutOfRangeException(nameof(config), "Temperature must be between 0.0 and 2.0.");
            }

            _config = config;
            return this;
        }

        /// <summary>
        /// Enables grounding.
        /// </summary>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        public ApiRequestBuilder EnableGrounding()
        {
            _useGrounding = true;
            return this;
        }

        /// <summary>
        /// Sets the safety settings.
        /// </summary>
        /// <param name="safetySettings">The list of safety settings to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        public ApiRequestBuilder WithSafetySettings(IEnumerable<SafetySetting> safetySettings)
        {
            _safetySettings = safetySettings.ToList();
            return this;
        }

        /// <summary>
        /// Disables all safety settings.
        /// </summary>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        public ApiRequestBuilder DisableAllSafetySettings()
        {
            _safetySettings = new List<SafetySetting>
                {
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
                };

            return this;
        }

        /// <summary>
        /// Sets the default generation configuration.
        /// </summary>
        /// <param name="temperature">The sampling temperature to set.</param>
        /// <param name="responseMimeType">The response MIME type to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the temperature is out of the valid range (0.0 to 2.0).</exception>
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

        /// <summary>
        /// Sets the prompt.
        /// </summary>
        /// <param name="prompt">The prompt to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the prompt is null or empty.</exception>
        public ApiRequestBuilder WithPrompt(string prompt)
        {
            if (string.IsNullOrEmpty(prompt))
            {
                throw new ArgumentNullException(nameof(prompt), "Prompt can't be an empty string.");
            }

            _prompt = prompt.Trim();
            return this;
        }

        /// <summary>
        /// Sets the chat history.
        /// </summary>
        /// <param name="chatMessages">The list of chat messages to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the chat messages list is null or empty.</exception>
        public ApiRequestBuilder WithChatHistory(IEnumerable<ChatMessage> chatMessages)
        {
            if (chatMessages == null || !chatMessages.Any())
            {
                throw new ArgumentNullException(nameof(chatMessages), "Chat history can't be null or empty.");
            }

            _chatHistory = chatMessages
                .Select(message => new Content
                {
                    Parts = new List<Part>
                    {
                        new Part { Text = message.Content }
                    },
                    Role = EnumHelper.GetDescription(message.Role),
                })
                .ToList();

            return this;
        }

        /// <summary>
        /// Sets the images.
        /// </summary>
        /// <param name="images">The list of image data to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the images list is null or empty.</exception>
        public ApiRequestBuilder WithImages(IEnumerable<ImageData> images)
        {
            if (images == null || !images.Any())
            {
                throw new ArgumentNullException(nameof(images), "Images can't be null or empty.");
            }

            _images = images.ToList();
            return this;
        }

        /// <summary>
        /// Sets the images from file paths.
        /// </summary>
        /// <param name="imageFilePaths">The list of image file paths to set.</param>
        /// <returns>The current instance of <see cref="ApiRequestBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the image file paths list is null or empty.</exception>
        public ApiRequestBuilder WithImages(IEnumerable<string> imageFilePaths)
        {
            if (imageFilePaths == null || !imageFilePaths.Any())
            {
                throw new ArgumentNullException(nameof(imageFilePaths), "Image file paths can't be null or empty.");
            }

            _images = imageFilePaths.Select(ImageHelper.ReadImage).ToList();
            return this;
        }

        /// <summary>
        /// Builds the API request with the configured parameters.
        /// </summary>
        /// <returns>The constructed <see cref="ApiRequest"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the prompt is null or empty.</exception>
        public ApiRequest Build()
        {
            if (string.IsNullOrEmpty(_prompt) && _images == null)
            {
                throw new InvalidOperationException("Prompt or images must be set.");
            }

            var contents = _chatHistory ?? [];

            if (_images != null)
            {
                contents.AddRange(_images
                    .Select(image => new Content
                    {
                        Parts =
                        [
                            new Part
                            {
                                InlineData = new InlineData
                                {
                                    Data = image.Base64Data,
                                    MimeType = EnumHelper.GetDescription(image.MimeType)
                                }
                            }
                        ],
                        Role = EnumHelper.GetDescription(Role.User),
                    }));
            }

            contents.Add(new Content
            {
                Parts =
                [
                    new Part
                    {
                        Text = _prompt
                    }
                ],
                Role = EnumHelper.GetDescription(Role.User),
            });

            return new ApiRequest
            {
                Contents = contents,
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
