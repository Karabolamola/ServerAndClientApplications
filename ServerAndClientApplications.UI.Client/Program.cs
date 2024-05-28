// See https://aka.ms/new-console-template for more information

namespace ServerAndClientApplications.UI.Client;

class Program
{
    static async Task Main(string[] args)
    {
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync("http://localhost:5255/api/values");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"Error code: {response.StatusCode}");
            }
        }
        Console.ReadLine();
    }
}