namespace openai_csharp_example;

public class ChatSession
{
    private readonly List<object> _messages;

    public ChatSession()
    {
        _messages = new List<object>
        {
            new
            {
                role = "system",
                content = "You are a helpful assistant."
            }
        };
    }

    public void AddMessage(string role, string content)
    {
        _messages.Add(new { role, content });
    }

    public IEnumerable<object> GetMessages() => _messages.ToArray();
}
