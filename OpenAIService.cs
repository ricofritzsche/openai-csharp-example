using System.Text;
using Newtonsoft.Json;

namespace openai_csharp_example;

public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OpenAIService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
    }

    public async Task<string> SendPromptAndGetResponse(IEnumerable<object> messages)
    {
        const string requestUri = "https://api.openai.com/v1/chat/completions";
        var requestBody = new
        {
            temperature = 0.2,
            model="gpt-3.5-turbo",
            messages= messages.ToList()
        };

        _httpClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

        var response = await _httpClient.PostAsync(
            requestUri,
            new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        var responseBody = JsonConvert.DeserializeObject<ResponseBody>(await response.Content.ReadAsStringAsync());
        return responseBody.Choices[0].Message.Content.Trim();
    }
}