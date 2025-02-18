using Gemini.NET;
using Microsoft.AspNetCore.Mvc;

namespace Example_APIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeminiController : ControllerBase
    {
        [HttpPost(Name = "GenerateContentWithApiKey")]
        public async Task<IActionResult> GenerateContentWithApiKey(string apiKey, string prompt)
        {
            var generatorWithApiKey = new Generator(apiKey)
                .IncludesGroundingDetailInResponse()
                .IncludesSearchEntryPointInResponse();

            var apiRequest = new ApiRequestBuilder()
                .WithPrompt(prompt)
                .EnableGrounding()
                .WithDefaultGenerationConfig()
                .DisableAllSafetySettings()
                .Build();

            try
            {
                var response = await generatorWithApiKey.GenerateContentAsync(apiRequest, Generator.GetLatestStableModelVersion());
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
