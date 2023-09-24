using Conselho;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace NotasFiscaisEmitidasAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            using (var writer = new StreamWriter("C:\\Users\\Ryan\\Desktop\\c#\\conselhos.csv"))
            for (int i = 1; i <= 5; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 225);
                var response = await client.GetAsync($"https://api.adviceslip.com/advice/{randomNumber}");
                var content = await response.Content.ReadAsStringAsync();
                var conselhos = JsonConvert.DeserializeObject<User>(content);
               
                writer.WriteLine(conselhos.Slip.Advice);

            }
  

        }
    }
}




