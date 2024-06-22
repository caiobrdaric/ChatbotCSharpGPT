# ChatbotIA Documentation

<img src="https://github.com/caiobrdaric/ChatbotCSharpGPT/assets/97686912/fca5c104-8360-4f30-90be-00fe2def7e83" width="70px" height="70px" display: inline-block />

<img src="https://github.com/caiobrdaric/ChatbotCSharpGPT/assets/97686912/3383226b-1140-4474-87cc-7b6910b1a095" width="70px" height="70px" display: inline-block />

<img src="https://github.com/caiobrdaric/ChatbotCSharpGPT/assets/97686912/46290d9d-9394-4f23-a00f-e8f5ac5af317" width="50px" height="50px" display: inline-block />

<img src="https://github.com/caiobrdaric/ChatbotCSharpGPT/assets/97686912/f4215bff-bd87-4102-8c2d-1cf9eccf383b" width="130px" height="40px" display: inline-block />

<img src="https://github.com/caiobrdaric/ChatbotCSharpGPT/assets/97686912/d05649ba-0d5b-45de-84fe-4b902fb3ffb7" width="130px" height="40px" display: inline-block />

## Overview

This project is a simple console-based chatbot that interacts with OpenAI's GPT-3.5 model. The chatbot takes user input, sends it to the OpenAI API, and displays the response.

 The purpose of this Chat Bot is to chat with potential job candidates.
The chatbot will discover the following information about the candidate:

- How many years of experience he or she has.
- What is your favorite programming language.
- Whether or not you are willing to program using Ruby.
- Whether or not you are willing to work on site.
- Answer any questions the potential tenant may have about the job.
- When the candidate wants to be interviewed.

The rules:
- It is not possible to write messages with more than 30 words.
- You cannot talk about anything other than the job
- As soon as the bot finds out everything about the above objectives (and the candidate has no more doubts) he must say goodbye

## Technologies Used

-   **Language**: C#
-   **Framework**: .NET Core
-   **API**: OpenAI GPT-3.5
-   **Libraries**:
    -   `System.Text`
    -   `System.Text.Json`
    -   `System.Net.Http`
    -   `ChatbotIA.Model`

## How It Works

1. **User Interaction**: The application prompts the user to enter a question. (In principle it works this way, but the features described in the overview will be increased)
2. **API Request**: The user's question is sent to the OpenAI API. (As stated in topic one, questions and answers will be held)
3. **API Response**: The API response is processed and displayed back to the user.
4. **Repeat**: The process repeats until the user types "exit" to exit the application. (As said in topic one, as soon as all doubts are resolved and the user has no more questions, the bot will say goodbye)

## Code Explanation

The main logic of the application is divided into a few key parts:
- **Main Loop**
  -  `Validation`: Checks if the input is valid (non-empty).
  -   `API Key`: Sets the API key for authorization.
  -   `HTTP Client`: Creates an HTTP client to send the request.
  -   `Request Payload`: Constructs the request payload with model details, temperature, token limit, and user message.
  -   `Send Request`: Sends the request to the OpenAI API and waits for the response.
  -   `Handle Response`: If successful, parses and displays the response. Otherwise, displays an error message.

-   **Resposta Class**: Represents the structure of the API response.
    -   **choices**: A list of `Choice` objects containing the response details.
    -   **data**: An array of `Data` objects (not used in the current implementation).
-   **Choice Class**: Represents individual choices in the response.
    -   **index, logoprobs, finish_reason, message, description**: Various properties related to the response.
-   **Message Class**: Represents the message content and role.
-   **Data Class**: Represents additional data (not used in the current implementation).

## Running the Application

1.  Clone the repository.
2.  Open the project in your preferred C# IDE.
3.  Replace `your-api-key-here` with your actual OpenAI API key.
4.  Run the project.
5.  Follow the on-screen instructions to interact with the chatbot.

## Notes

-   Ensure you have an active OpenAI API key.
-   The model used is `gpt-3.5-turbo-0125`; you can change it based on availability and requirements.
-   Adjust `temperature` and `max_tokens` as needed to fine-tune the responses.
