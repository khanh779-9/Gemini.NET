# Gemini.NET - Lightweight .NET SDK for Gemini API

[![NuGet Version](https://img.shields.io/nuget/v/Gemini.NET)](https://www.nuget.org/packages/Gemini.NET)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Gemini.NET)](https://www.nuget.org/packages/Gemini.NET)

![Gemini.NET Logo](https://i.imgur.com/ee8T0gX.png)

**Gemini.NET** is a lightweight and user-friendly .NET SDK designed to simplify the integration of Google's Gemini API into your .NET applications. It provides a straightforward and efficient way to generate content, manage API requests, and leverage Gemini's powerful features.

## **✨ Key Features**

* **Simple API Request Builder:**  Easily construct Gemini API requests with a fluent and intuitive interface.
* **Latest Gemini Models:** Supports the most recent Gemini model versions, ensuring access to the latest advancements.
* **Flexible Configuration:** Customize grounding and safety settings to tailor API behavior to your needs.
* **Versatile Response Handling:**  Handles both JSON and plain text responses seamlessly.
* **API Key Validation:**  Built-in methods to validate your API keys for secure and reliable usage.
* **Multi-Image Input:**  Enables inputting multiple images for richer content generation.
* **Customizable System Instructions:**  Fine-tune Gemini's behavior with custom system instructions.

### TO DO:

* **Pre-built Utilities:** Includes optimized utilities for common tasks like: → 
    * **Image OCR:** Extract text from images.
    * **Audio/Video Transcription:** Convert audio and video to text.
    * **Text Summarization:** Condense lengthy text into concise summaries.
    * **Translation:** Translate text between languages.
    * **Dictionary:**  Look up word definitions.
    * **JSON Conversion:**  Work with JSON data effectively.

## **📦 Installation**

Install Gemini.NET using the **NuGet Package Manager** in Visual Studio or the .NET CLI.

**NuGet Package Manager:**

![alt text](https://i.imgur.com/6TFlTE4.png)

1. Open your project in Visual Studio.
2. Go to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution...**
3. Search for `Gemini.NET` and install the package.

**.NET CLI:**

```bash
dotnet add package Gemini.NET
```

For more detailed instructions, visit the Gemini.NET's [NuGet Gallery page](https://www.nuget.org/packages/Gemini.NET).

---

## 🚀 Getting Started

Here's a quick example to get you started with generating content using Gemini.NET:

```csharp
using Gemini.NET;
using Models.Request;
using Models.Enums;

// Initialize the Generator with your API key
var generator = new Generator("YOUR_API_KEY");

// Build an API request
var apiRequest = new ApiRequestBuilder()
    .WithPrompt("Write a short poem about the stars.")
    .WithDefaultGenerationConfig(temperature: 0.7F, responseMimeType: ResponseMimeType.PlainText)
    .Build();

// Generate content using the latest stable model
var modelVersion = Generator.GetLatestStableModelVersion();
var response = await generator.GenerateContentAsync(apiRequest, modelVersion);

// Print the generated content
Console.WriteLine("Generated Poem:\n" + response.Result);
```

Replace `"YOUR_API_KEY"` with your actual Gemini API key and run this code in your .NET 8 project.

---

## **🛠️ Usage Guidance**

### ApiRequestBuilder Class

The `ApiRequestBuilder` class provides a fluent API to create and configure `ApiRequest` objects.

**Available Methods:**

* **`WithSystemInstruction(string systemInstruction)`:** Sets instructions for Gemini's behavior.
* **`WithGenerationConfig(GenerationConfig config)`:**  Provides detailed generation settings (temperature, top_p, etc.).
* **`EnableGrounding()`:**  Enables grounding to get source attribution.
* **`WithSafetySettings(IEnumerable<SafetySetting> safetySettings)`:** Configures content safety filters.
* **`DisableAllSafetySettings()`:**  Disables all safety filters (use with caution).
* **`WithDefaultGenerationConfig(float temperature = 1.0F, ResponseMimeType responseMimeType = ResponseMimeType.PlainText)`:** Sets common generation parameters.
* **`WithPrompt(string prompt)`:**  Sets the primary text prompt for the API.
* **`WithChatHistory(IEnumerable<ChatMessage> chatMessages)`:**  Provides conversation history for chat-based models.
* **`WithBase64Images(IEnumerable<string> images)`:**  Includes Base64 encoded images as input.
* **`Build()`:**  Constructs the `ApiRequest` object.

**Example Usage:**

```csharp
using Models.Request;
using Models.Enums;
using System.Collections.Generic;

var apiRequestBuilder = new ApiRequestBuilder()
    .WithSystemInstruction("Act as a helpful assistant.")
    .WithPrompt("Translate 'Hello world' to Spanish.")
    .WithDefaultGenerationConfig(temperature: 0.6F, responseMimeType: ResponseMimeType.Json)
    .EnableGrounding()
    .WithSafetySettings(new List<SafetySetting> { new SafetySetting { Category = "Harassment", Threshold = "BLOCK_MEDIUM_AND_ABOVE" } })
    .Build();

// apiRequestBuilder is now ready to be used with Generator.GenerateContentAsync()
```

### Generator Class

The `Generator` class is the primary entry point for interacting with the Gemini API. It handles API key management, request execution, and response processing.

#### Initialization

You can initialize the `Generator` using either an API key or Google Cloud project credentials.

**Using API Key:**

```csharp
using Gemini.NET;

var generator = new Generator("YOUR_API_KEY");
```

**Using Google Cloud Project Credentials:**

```csharp
using Gemini.NET;

var generator = new Generator("YOUR_CLOUD_PROJECT_NAME", "YOUR_CLOUD_PROJECT_ID", "YOUR_BEARER_TOKEN");
```

#### API Key Validation

Verify your API key's validity using `IsValidApiKeyAsync()`:

```csharp
bool isValid = await generator.IsValidApiKeyAsync();
if (isValid)
{
    Console.WriteLine("API key is valid.");
}
else
{
    Console.WriteLine("API key is invalid or expired.");
}
```

#### Configuring Response Details (Grounding & Search)

Control the inclusion of grounding details and search entry points in the API response.

```csharp
// Include Grounding Detail in response
generator.IncludesGroundingDetailInResponse();

// Exclude Grounding Detail from response (default)
generator.ExcludesGroundingDetailFromResponse();

// Include Search Entry Point in response
generator.IncludesSearchEntryPointInResponse();

// Exclude Search Entry Point from response (default)
generator.ExcludesSearchEntryPointFromResponse();
```

#### Generating Content

1. **Create an `ApiRequest`:** Use `ApiRequestBuilder` to construct your request.
2. **Call `GenerateContentAsync()`:** Send the request to the Gemini API.

**Example:**

```csharp
using Models.Request;
using Models.Enums;

// Build API Request
var apiRequest = new ApiRequestBuilder()
    .WithPrompt("Explain quantum physics in simple terms.")
    .WithDefaultGenerationConfig(temperature: 0.5F, responseMimeType: ResponseMimeType.PlainText)
    .Build();

// Select Model Version
var modelVersion = ModelVersion.Gemini_20_Flash; // Or use Generator.GetLatestStableModelVersion()

// Generate Content
var response = await generator.GenerateContentAsync(apiRequest, modelVersion);

Console.WriteLine("Generated Explanation:\n" + response.Result);

if (response.GroundingDetail != null) // Check for grounding details
{
    Console.WriteLine("\nGrounding Detail (HTML):\n" + response.GroundingDetail.RenderedContentAsHtml);
}
```

#### Getting the Latest Stable Model Version

Retrieve the latest recommended model version:

```csharp
var latestModelVersion = Generator.GetLatestStableModelVersion();
Console.WriteLine("Latest Stable Model Version: " + latestModelVersion);
```

### Validator Class

The `Validator` class offers utility methods for checking model capabilities and API key formats.

**Methods:**

* **`SupportsGrouding(ModelVersion modelVersion)`:**  Checks if a model version supports grounding.
* **`SupportsJsonOutput(ModelVersion modelVersion)`:** Checks if a model version supports JSON output.
* **`CanBeValidApiKey(string apiKey)`:**  Validates the format of a Gemini API key.

**Example Usage:**

```csharp
using Models.Enums;
using Gemini.NET;

bool groundingSupported = Validator.SupportsGrouding(ModelVersion.Gemini_20_Flash);
Console.WriteLine($"Gemini Flash supports grounding: {groundingSupported}");

bool jsonOutputSupported = Validator.SupportsJsonOutput(ModelVersion.Gemini_20_Flash);
Console.WriteLine($"Gemini Flash supports JSON output: {jsonOutputSupported}");

bool apiKeyFormatValid = Validator.CanBeValidApiKey("YOUR_API_KEY");
Console.WriteLine($"API Key format is valid: {apiKeyFormatValid}");
```

## **🤝 Contributing**

We welcome contributions to Gemini.NET!  Whether you're fixing a bug, suggesting a new feature, improving documentation, or writing code, your help is appreciated.

**How to Contribute:**

1. **Fork the repository:** Start by forking the Gemini.NET repository to your own GitHub account.
2. **Create a branch:**  Create a new branch for your contribution (e.g., `feature/new-utility` or `fix/bug-ocr`).
3. **Make your changes:** Implement your feature, bug fix, or documentation update.
4. **Test your changes:** Ensure your changes are working correctly and don't introduce regressions.
5. **Submit a pull request:** Once you're happy with your contribution, submit a pull request to the main repository, explaining your changes in detail.

**Types of Contributions We Appreciate:**

* **Bug Reports:** If you find a bug, please report it by creating an issue. Provide clear steps to reproduce the bug and any relevant details about your environment.
* **Feature Requests:** Have a great idea for a new feature or utility?  Open an issue to discuss it!
* **Code Contributions:**  We welcome code contributions that add new features, improve existing functionality, or fix bugs.
* **Documentation Improvements:** Help us make the documentation clearer, more comprehensive, and easier to understand.
* **Examples and Tutorials:**  Creating examples and tutorials can help other developers get started with Gemini.NET more quickly.

**Contribution Guidelines:**

* Follow the existing code style and conventions.
* Write clear and concise commit messages.
* Ensure your code is well-tested.
* Be respectful and considerate in your interactions with other contributors.

Please note that by contributing to Gemini.NET, you agree to abide by the project's Code of Conduct (if applicable, otherwise standard open source community guidelines apply).

We look forward to your contributions!
