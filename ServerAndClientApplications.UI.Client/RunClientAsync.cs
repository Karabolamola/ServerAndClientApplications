namespace ServerAndClientApplications.UI.Client;

public class RunClientAsync
{
    public async Task RunAsync()
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