using Gemini.NET;
using Microsoft.AspNetCore.Mvc;

namespace Example_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroundingController : ControllerBase
    {
        [HttpPost("GenerationWithGrounding")]
        public async Task<IActionResult> GenerateContentWithGrounding(string apiKey, string prompt)
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
