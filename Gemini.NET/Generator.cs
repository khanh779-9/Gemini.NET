using Commons;
using Models.API_Request;
using Models.Enums;
using Models.Shared;
using System.Net.Http.Headers;
using System.Text;

namespace Gemini.NET
{
    public class Generator
    {
        private const string _apiEndpointPrefix = "https://generativelanguage.googleapis.com/v1beta/models";

        private readonly HttpClient _client = new();
        private readonly string? _apiKey;

        public Generator(string apiKey)
        {
            if (!Validator.CanBeValidApiKey(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey), "Invalid API key.");
            }

            _apiKey = apiKey;
        }

        public Generator(string cloudProjectName, string cloudProjectId, string bearerToken)
        {
            if (string.IsNullOrEmpty(cloudProjectName))
            {
                throw new ArgumentNullException(nameof(cloudProjectName), "Cloud project name is required.");
            }

            if (string.IsNullOrEmpty(cloudProjectId))
            {
                throw new ArgumentNullException(nameof(cloudProjectId), "Cloud project ID is required.");
            }

            if (string.IsNullOrEmpty(bearerToken))
            {
                throw new ArgumentNullException(nameof(bearerToken), "Bearer token is required.");
            }

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add(cloudProjectName, cloudProjectId);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        public static ApiRequest BuildDefaultRequest(string prompt, float temperature = 1.0F, ResponseMimeType responseMimeType = ResponseMimeType.PlainText, bool useGrounding = false, string systemInstruction = "")
        {
            prompt = string.IsNullOrEmpty(prompt) ? string.Empty : prompt.Trim();
            systemInstruction = string.IsNullOrEmpty(systemInstruction) ? string.Empty : systemInstruction.Trim();

            if (string.IsNullOrEmpty(prompt))
            {
                throw new ArgumentNullException(nameof(prompt), "Prompt is required.");
            }

            if (temperature < 0.0F || temperature > 2.0F)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature), "Temperature must be between 0.0 and 2.0.");
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
                                Text = prompt
                            }
                        ],
                        Role = EnumHelper.GetDescription(Role.User),
                    }
                ],
                GenerationConfig = new GenerationConfig
                {
                    Temperature = temperature,
                    ResponseMimeType = EnumHelper.GetDescription(responseMimeType),
                },
                SafetySettings =
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
                ],
                Tools = useGrounding
                    ?
                    [
                        new Tool
                        {
                            GoogleSearch = new GoogleSearch()
                        }
                    ]
                    : null,
                SystemInstruction = string.IsNullOrEmpty(systemInstruction)
                    ? null
                    : new SystemInstruction
                    {
                        Parts =
                        [
                            new Part
                            {
                                Text = systemInstruction
                            }
                        ]
                    }
            };
        }

        public async Task<Models.API_Response.Success.ApiResponse> GenerateContentAsync(ApiRequest request, ModelVersion modelVersion = ModelVersion.Gemini_20_Flash)
        {
            if (request.Tools != null && request.Tools.Count > 0 && !Validator.SupportsGrouding(modelVersion))
            {
                throw new ArgumentNullException(nameof(request), "Grounding is not supported for this model version.");
            }

            if (request.GenerationConfig.ResponseMimeType == EnumHelper.GetDescription(ResponseMimeType.Json) && !Validator.SupportsJsonOutput(modelVersion))
            {
                throw new ArgumentNullException(nameof(request), "JSON output is not supported for this model version.");
            }

            var endpoint = $@"{_apiEndpointPrefix}/{EnumHelper.GetDescription(modelVersion)}:generateContent";

            if (!string.IsNullOrEmpty(_apiKey))
            {
                endpoint += $"?key={_apiKey}";
                _client.DefaultRequestHeaders.Clear();
            }

            var json = JsonHelper.AsString(request);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(endpoint, body).ConfigureAwait(false);
                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                try
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var dto = JsonHelper.AsObject<Models.API_Response.Failed.ApiResponse>(responseData);
                        throw new InvalidOperationException(dto == null ? "Undefined" : $"{dto.Error.Status} ({dto.Error.Code}): {dto.Error.Message}");
                    }

                    return JsonHelper.AsObject<Models.API_Response.Success.ApiResponse>(responseData);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Failed to parse response from JSON:\n{responseData}", ex);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to send request to Gemini:\n{json}", ex);
            }
        }
    }
}
