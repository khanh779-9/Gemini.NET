using Gemini.NET;
using Models.Enums;

namespace Examples
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var apiKey = Console.ReadLine();

            var generatorWithApiKey = new Generator(apiKey);
            var apiRequest = Generator.BuildDefaultRequest("What is **Love**?", 1.0F, ResponseMimeType.PlainText, true);
            try
            {
                var response = await generatorWithApiKey.GenerateContentAsync(apiRequest);
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
