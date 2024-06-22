using ChatbotIA.Model;
using System.Text;
using System.Text.Json;

while (true)
{
    Console.WriteLine("Digite sua pergunta:");
    var prompt = Console.ReadLine();

    if (prompt.ToLower() == "sair")
        break;

    await Pergunta(prompt);
}

async Task Pergunta(string prompt)
{
    if (String.IsNullOrWhiteSpace(prompt))
        return;

    string apiKey = "sk-proj-YVUxbVJmDP9ByWZ5WcL5T3BlbkFJDPKq2s6ARl1iGjsS5wCL";


    using (var client = new HttpClient())
    {
        try
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            var requestPayload = new
            {
                model = "gpt-3.5-turbo-0125",
                temperature = 1,
                max_tokens = 1024,
                messages = new List<object>() { new { role = "user", content = prompt } }
            };

            string jsonPayload = JsonSerializer.Serialize(requestPayload);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Resposta data = JsonSerializer.Deserialize<Resposta>(responseString);

                foreach (var choice in data.choices)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(choice.message.content);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Erro ao enviar a pergunta. Código de status: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exceção ao enviar a pergunta: " + ex.Message);
        }
    }
}