using Commons;
using Gemini.NET.Response_Models;
using Models.API_Request;
using Models.Enums;
using System.Net.Http.Headers;
using System.Text;

namespace Gemini.NET
{
    public class Generator
    {
        private const string _apiEndpointPrefix = "https://generativelanguage.googleapis.com/v1beta/models";

        private readonly HttpClient _client = new();
        private readonly string? _apiKey;
        private bool _includesGroundingDetailInResponse = false;
        private bool _includesSearchEntryPointInResponse = false;

        public Generator(string apiKey)
        {
            if (!Validator.CanBeValidApiKey(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey), "Invalid API key.");
            }

            _apiKey = apiKey;
        }

        public Generator(string cloudProjectName, string cloudProjectId, string bearer)
        {
            if (string.IsNullOrEmpty(cloudProjectName))
            {
                throw new ArgumentNullException(nameof(cloudProjectName), "Cloud project name is required.");
            }

            if (string.IsNullOrEmpty(cloudProjectId))
            {
                throw new ArgumentNullException(nameof(cloudProjectId), "Cloud project ID is required.");
            }

            if (string.IsNullOrEmpty(bearer))
            {
                throw new ArgumentNullException(nameof(bearer), "Bearer token is required.");
            }

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add(cloudProjectName, cloudProjectId);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
        }

        public Generator IncludesGroundingDetailInResponse()
        {
            if (!_includesGroundingDetailInResponse)
            {
                _includesGroundingDetailInResponse = true;
            }
            return this;
        }

        public Generator ExcludesGroundingDetailFromResponse()
        {
            if (_includesGroundingDetailInResponse)
            {
                _includesGroundingDetailInResponse = false;
            }
            return this;
        }

        public Generator IncludesSearchEntryPointInResponse()
        {
            if (!_includesGroundingDetailInResponse)
            {
                throw new InvalidOperationException("Grounding detail must be included in the response to include search entry point.");
            }

            if (!_includesSearchEntryPointInResponse)
            {
                _includesSearchEntryPointInResponse = true;
            }

            return this;
        }

        public Generator ExcludesSearchEntryPointFromResponse()
        {
            if (_includesSearchEntryPointInResponse)
            {
                _includesSearchEntryPointInResponse = false;
            }

            return this;
        }

        public async Task<Response> GenerateContentAsync(ApiRequest request, ModelVersion modelVersion = ModelVersion.Gemini_20_Flash)
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
                    else
                    {
                        var dto = JsonHelper.AsObject<Models.API_Response.Success.ApiResponse>(responseData);
                        var groudingMetadata = dto.Candidates[0].GroundingMetadata;

                        return new()
                        {
                            Result = dto.Candidates[0].Content != null
                                ? dto.Candidates[0].Content.Parts[0].Text
                                : "Failed to generate content",
                            GroundingDetail = groudingMetadata == null || !_includesGroundingDetailInResponse
                                ? null
                                : new GroundingDetail
                                {
                                    RenderedContentAsHtml = _includesSearchEntryPointInResponse
                                        ? groudingMetadata?.SearchEntryPoint?.RenderedContent
                                        : null,
                                    SearchSuggestions = groudingMetadata?.WebSearchQueries,
                                    ReliableInformation = groudingMetadata?.GroundingSupports?
                                        .OrderByDescending(s => s.ConfidenceScores.Max())
                                        .Select(s => s.Segment.Text)
                                        .ToList(),
                                    Sources = groudingMetadata?.GroundingChunks?
                                        .Select(c => new GroundingSource
                                        {
                                            Domain = c.Web.Title,
                                            Url = c.Web.Uri,
                                        })
                                        .ToList(),
                                },
                        };
                    }
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

        public static ModelVersion GetLatestStableModelVersion()
        {
            return Enum.GetValues(typeof(ModelVersion)).Cast<ModelVersion>().Max();
        }
    }
}
