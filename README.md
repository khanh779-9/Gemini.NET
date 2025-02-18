# Gemini.NET

Gemini.NET is a lightweight SDK that enables integration of Gemini for .NET 8 in a simple way. This SDK provides a set of tools and utilities to interact with the Gemini API, allowing developers to generate content, perform tasks, and manage API requests and responses efficiently.

## Features

- Easy-to-use API request builder
- Support for latest Gemini model versions
- Grounding and safety settings configuration
- JSON and plain text response handling
- Validation methods for API keys and model versions

## Installation

You can install the Gemini.NET package via NuGet Package Manager:

```sh
dotnet add package Gemini.NET
```

---

## Usage

### Initializing the Generator

To use the Gemini.NET SDK, you need to initialize the `Generator` class with your API key that can be got from [**Google AI Studio**](https://aistudio.google.com/app/apikey):

```csharp
var generator = new Generator("AIzaSyAe...");
```

Alternatively, you can initialize the `Generator` with a Google Cloud project credentials and a bearer token:

```csharp
var generator = new Generator("cloudProjectName", "cloudProjectId", "bearerToken");
```

### Create an API Request

Use the `ApiRequestBuilder` class to construct your API requests:

```csharp
var apiRequest = new ApiRequestBuilder()
    .WithPrompt("Generate a creative story about a dragon.")
    .WithDefaultGenerationConfig(temperature: 0.7F, responseMimeType: ResponseMimeType.PlainText)
    .EnableGrounding()
    .DisableAllSafetySettings()
    .Build();
```

You can also include the chat history for the API request:

```csharp
var chatHistory = new List<ChatMessage> { new ChatMessage { Content = "Hello" } };
var apiRequest = new ApiRequestBuilder().WithChatHistory(chatHistory);
```

### Generate Content

Once you have built your API request, you can use the `Generator` class to generate content:

```csharp
var response = await generator.GenerateContentAsync(apiRequest, ModelVersion.Gemini_20_Flash);
Console.WriteLine(response.Result);
```

### Validate an API Key

You can validate your API key using the `IsValidApiKeyAsync` method:

```csharp
bool isValid = await generator.IsValidApiKeyAsync();
Console.WriteLine($"API Key is valid: {isValid}");
```

### Including Grounding Details in Response

You can include grounding details in the response by configuring the `Generator`:

```csharp
generator.IncludesGroundingDetailInResponse();
```

### Including Search Entry Point in Response

To include the search entry point in the response, ensure that grounding detail is included first:

```csharp
generator.IncludesGroundingDetailInResponse().IncludesSearchEntryPointInResponse();
```

---

## Classes and Methods

### [**Generator**](https://github.com/phanxuanquang/Gemini.NET/blob/master/Gemini.NET/Generator.cs)

#### Constructor

- `Generator(string apiKey)`: Initializes a new instance of the `Generator` class with the provided API key.
  - **Parameters:**
    - `apiKey`: The API key to use for authentication.
  - **Example:**
    ```csharp
    var generator = new Generator("your-api-key");
    ```

- `Generator(string cloudProjectName, string cloudProjectId, string bearer)`: Initializes a new instance of the `Generator` class with Google Cloud project creadentials and a bearer token.
  - **Parameters:**
    - `cloudProjectName`: The name of the cloud project.
    - `cloudProjectId`: The ID of the cloud project.
    - `bearer`: The bearer token for authentication.
  - **Example:**
    ```csharp
    var generator = new Generator("cloudProjectName", "cloudProjectId", "bearerToken");
    ```

#### Methods

- `Task<bool> IsValidApiKeyAsync()`: Checks if the provided API key is valid.
  - **Returns:** `true` if the API key is valid; otherwise, `false`.
  - **Example:**
    ```csharp
    bool isValid = await generator.IsValidApiKeyAsync();
    ```

- `Generator IncludesGroundingDetailInResponse()`: Includes grounding detail in the response.
  - **Returns:** The current instance of the `Generator` class.
  - **Example:**
    ```csharp
    generator.IncludesGroundingDetailInResponse();
    ```

- `Generator ExcludesGroundingDetailFromResponse()`: Excludes grounding detail from the response.
  - **Returns:** The current instance of the `Generator` class.
  - **Example:**
    ```csharp
    generator.ExcludesGroundingDetailFromResponse();
    ```

- `Generator IncludesSearchEntryPointInResponse()`: Includes search entry point in the response.
  - **Returns:** The current instance of the `Generator` class.
  - **Throws:** `InvalidOperationException` if grounding detail is not included in the response.
  - **Example:**
    ```csharp
    generator.IncludesGroundingDetailInResponse().IncludesSearchEntryPointInResponse();
    ```

- `Generator ExcludesSearchEntryPointFromResponse()`: Excludes search entry point from the response.
  - **Returns:** The current instance of the `Generator` class.
  - **Example:**
    ```csharp
    generator.ExcludesSearchEntryPointFromResponse();
    ```

- `Task<ModelResponse> GenerateContentAsync(ApiRequest request, ModelVersion modelVersion = ModelVersion.Gemini_20_Flash)`: Generates content based on the provided API request.
  - **Parameters:**
    - `request`: The API request to generate content for.
    - `modelVersion`: The model version to use for content generation.
  - **Returns:** A `ModelResponse` object containing the generated content.
  - **Example:**
    ```csharp
    var response = await generator.GenerateContentAsync(apiRequest, ModelVersion.Gemini_20_Flash);
    ```

- `static ModelVersion GetLatestStableModelVersion()`: Gets the latest stable model version of Gemini.
  - **Returns:** The latest stable `ModelVersion`.
  - **Example:**
    ```csharp
    var latestVersion = Generator.GetLatestStableModelVersion();
    ```

### [**ApiRequestBuilder**](https://github.com/phanxuanquang/Gemini.NET/blob/master/Gemini.NET/ApiRequestBuilder.cs)

#### Methods

- `ApiRequestBuilder WithSystemInstruction(string systemInstruction)`: Sets the system instruction for the API request.
  - **Parameters:**
    - `systemInstruction`: The system instruction to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var builder = new ApiRequestBuilder().WithSystemInstruction("Your system instruction");
    ```

- `ApiRequestBuilder WithGenerationConfig(GenerationConfig config)`: Sets the generation configuration for the API request.
  - **Parameters:**
    - `config`: The generation configuration to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var config = new GenerationConfig { Temperature = 0.7F };
    var builder = new ApiRequestBuilder().WithGenerationConfig(config);
    ```

- `ApiRequestBuilder EnableGrounding()`: Enables grounding for the API request.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var builder = new ApiRequestBuilder().EnableGrounding();
    ```

- `ApiRequestBuilder WithSafetySettings(List<SafetySetting> safetySettings)`: Sets the safety settings for the API request.
  - **Parameters:**
    - `safetySettings`: The list of safety settings to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var safetySettings = new List<SafetySetting> { new SafetySetting { Category = "HateSpeech" } };
    var builder = new ApiRequestBuilder().WithSafetySettings(safetySettings);
    ```

- `ApiRequestBuilder DisableAllSafetySettings()`: Disables all safety settings for the API request.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var builder = new ApiRequestBuilder().DisableAllSafetySettings();
    ```

- `ApiRequestBuilder WithDefaultGenerationConfig(float temperature = 1, ResponseMimeType responseMimeType = ResponseMimeType.PlainText)`: Sets the default generation configuration for the API request.
  - **Parameters:**
    - `temperature`: The sampling temperature to set.
    - `responseMimeType`: The response MIME type to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var builder = new ApiRequestBuilder().WithDefaultGenerationConfig(0.7F, ResponseMimeType.Json);
    ```

- `ApiRequestBuilder WithPrompt(string prompt)`: Sets the prompt for the API request.
  - **Parameters:**
    - `prompt`: The prompt to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var builder = new ApiRequestBuilder().WithPrompt("Generate a creative story about a dragon.");
    ```

- `ApiRequestBuilder WithChatHistory(List<ChatMessage> chatMessages)`: Sets the chat history for the API request.
  - **Parameters:**
    - `chatMessages`: The list of chat messages to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var chatHistory = new List<ChatMessage> { new ChatMessage { Content = "Hello" } };
    var builder = new ApiRequestBuilder().WithChatHistory(chatHistory);
    ```

- `ApiRequestBuilder WithInlineData(List<InlineData> inlineData)`: Sets the media content for the API request.
  - **Parameters:**
    - `inlineData`: The list of inline data to set.
  - **Returns:** The current instance of the `ApiRequestBuilder` class.
  - **Example:**
    ```csharp
    var inlineData = new List<InlineData> { new InlineData { MimeType = "image/png", Data = "base64encodeddata" } };
    var builder = new ApiRequestBuilder().WithInlineData(inlineData);
    ```

- `ApiRequest Build()`: Builds the API request with the configured parameters.
  - **Returns:** The constructed `ApiRequest`.
  - **Example:**
    ```csharp
    var apiRequest = new ApiRequestBuilder()
        .WithPrompt("Generate a creative story about a dragon.")
        .WithDefaultGenerationConfig(0.7F, ResponseMimeType.PlainText)
        .EnableGrounding()
        .DisableAllSafetySettings()
        .Build();
    ```

### [**Validator**](https://github.com/phanxuanquang/Gemini.NET/blob/master/Gemini.NET/Validator.cs)

#### Methods

- `static bool SupportsGrouding(ModelVersion modelVersion)`: Determines if the specified model version supports grounding.
  - **Parameters:**
    - `modelVersion`: The model version to check.
  - **Returns:** `true` if the model version supports grounding; otherwise, `false`.
  - **Example:**
    ```csharp
    bool supportsGrounding = Validator.SupportsGrouding(ModelVersion.Gemini_20_Flash);
    ```

- `static bool SupportsJsonOutput(ModelVersion modelVersion)`: Determines if the specified model version supports JSON output.
  - **Parameters:**
    - `modelVersion`: The model version to check.
  - **Returns:** `true` if the model version supports JSON output; otherwise, `false`.
  - **Example:**
    ```csharp
    bool supportsJson = Validator.SupportsJsonOutput(ModelVersion.Gemini_20_Flash);
    ```

- `static bool CanBeValidApiKey(string apiKey)`: Validates if the provided API key is in a valid Gemini API KEY format.
  - **Parameters:**
    - `apiKey`: The API key to validate.
  - **Returns:** `true` if the API key is valid; otherwise, `false`.
  - **Example:**
    ```csharp
    bool isValidApiKey = Validator.CanBeValidApiKey("your-api-key");
    ```
    
---

## Contributing

Contributions are welcome! Please open an issue or submit a pull request on GitHub.
