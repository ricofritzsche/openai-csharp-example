namespace openai_csharp_example;

using Microsoft.Extensions.Configuration;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        
        var configuration = builder.Build();
        var apiKey = configuration["OpenAI:ApiKey"];
    
        using var httpClient = new HttpClient();
        var openAIService = new OpenAIService(httpClient, apiKey);

        var chatSession = new ChatSession();

        while (true)
        {
            Console.Write("You: ");
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Input can't be empty. Please try again.");
                continue;
            }

            chatSession.AddMessage("user", userInput);

            try
            {
                var response = await openAIService.SendPromptAndGetResponse(chatSession.GetMessages());
                Console.WriteLine($"OpenAI: {response}");
                chatSession.AddMessage("assistant", response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                break;
            }
        }
    }
}