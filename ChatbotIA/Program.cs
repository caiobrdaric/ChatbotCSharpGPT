using System.Text;
using System.Text.Json;

while (true)
{
    Console.WriteLine("Digite sua pergunta:");
    var prompt = Console.ReadLine();

    if (prompt.ToLower() == "sair")
        break;

    if (prompt.ToLower().StartsWith("imagem"))
        await imagem(prompt);
    else
        await pergunta(prompt);
}

async Task pergunta(string prompt)
{
    if (String.IsNullOrWhiteSpace(prompt))
        return;

    string apiKey = "sk-proj-YVUxbVJmDP9ByWZ5WcL5T3BlbkFJDPKq2s6ARl1iGjsS5wCL";


    using (var client = new HttpClient())
    {
        try
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            // Construa o objeto de payload usando classes C# e serialize para JSON
            var requestPayload = new
            {
                model = "gpt-3.5-turbo-0125",
                // prompt = prompt,
                temperature = 1,
                max_tokens = 1024,
                messages = new List <object>() { new { role = "user", content = prompt } }
            };

            string jsonPayload = JsonSerializer.Serialize(requestPayload);
            
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Resposta data = JsonSerializer.Deserialize<Resposta>(responseString);
                
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var choice in data.choices)
                {
                    Console.WriteLine(choice.message.content);   
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


async Task imagem(string prompt)
{
    if (String.IsNullOrWhiteSpace(prompt))
        return;

    string apiKey = "sk-proj-YVUxbVJmDP9ByWZ5WcL5T3BlbkFJDPKq2s6ARl1iGjsS5wCL";

    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
        var response = await client.PostAsync("https://api.openai.com/v1/images/generations",
        new StringContent("@{\r\n    \"model\": \"gpt-4o\",\r\n    \"messages\": [\r\n      {\r\n        \"role\": \"system\",\r\n        \"content\": \"You are a helpful assistant.\"\r\n      },\r\n      {\r\n        \"role\": \"user\",\r\n        \"content\": \"Hello!\"\r\n      }\r\n    ]\r\n  }", Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            string responseString = await response.Content.ReadAsStringAsync();
            Resposta resposta = JsonSerializer.Deserialize<Resposta>(responseString);
            Console.ForegroundColor = ConsoleColor.Red;

            Array.ForEach(resposta.data.ToArray(), (item) => Console.WriteLine(item.url.Replace("\n", "")));

            Console.ResetColor();

        }
        else
        {
            Console.WriteLine("Ocorreu um erro ao enviar a pergunta.");
        }
    }
}


class Resposta
{
    public List<Choice> choices { get; set; }
    public Data[] data { get; set; }
    public class Choice
    {
       public int index { get; set; }
       public string logoprobs { get; set; }
       public string finish_reason { get; set; }

        public message message { get; set; }
        public string description { get; set; }
    }

    public class message
    {
       public string role { get; set; }
       public string content { get; set; }
    }

    public class Data
    {
       public string url { get; set; }

    }
}