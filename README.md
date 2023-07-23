# OpenAI C# Example

This repository contains a simple console application demonstrating how to interact with the OpenAI API using C# (.NET Core).

The application allows you to chat with an AI model (GPT-3.5-Turbo), taking user input from the command line, sending it to the OpenAI API and displaying the AI's response.

## Project Structure

The project is composed of a single console application that interacts with the OpenAI API. It is structured as follows:

- `Program.cs`: The entry point of the application. Contains a chat loop that continually prompts the user for input, sends it to the OpenAI API, and displays the AI's response.
- `OpenAIService.cs`: A service class that encapsulates the logic for sending prompts to the OpenAI API and parsing the API's response.
- `ChatSession.cs`: A class that manages a chat session, keeping track of the conversation history and adding user prompts to it.

## Setup

1. Clone the repository to your local machine.
2. Navigate to the root directory of the project.
3. Add your OpenAI API key to the project using .NET's Secret Manager:
```bash
dotnet user-secrets set "OpenAI:ApiKey" "<Your OpenAI API Key>"
 ``

4. Run the project:
```bash
dotnet run
```

## Usage

Once the application is running, simply type your message at the prompt and hit enter. The AI's response will be displayed on the next line.

## Learn More

This project was created as part of a blog post tutorial on using OpenAI with .NET Core. [Read the full tutorial here](https://blog.ricofritzsche.de/ai-powered-net-core-apps-a-comprehensive-guide-to-openai-integration-f24ae7ae55f0?sk=57f7780d138e8686c48da740e22a8060).

## License

This project is licensed under the terms of the MIT license.

