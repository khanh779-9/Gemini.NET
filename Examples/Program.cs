using Gemini.NET;

namespace Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var generatorWithApiKey = new Generator("Your API Key");
            var generatorWithCloudProjectCredentials = new Generator("Project Name", "Project ID", "Bearer Token");
        }
    }
}
