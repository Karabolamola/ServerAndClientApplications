// See https://aka.ms/new-console-template for more information

namespace ServerAndClientApplications.Console.Client;

class Program
{
    static async Task Main(string[] args)
    {
        
        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadLine();
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync("http://localhost:5255/api/values");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(message);
            }
            else
            {
                System.Console.WriteLine($"Error code: {response.StatusCode}");
            }
        }
        System.Console.ReadLine();
    }
}