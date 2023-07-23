namespace openai_csharp_example;

public class Message
{
    public string Content { get; set; }
}

public class Choice
{
    public Message Message { get; set; }
}

public class ResponseBody
{
    public List<Choice> Choices { get; set; }
}
