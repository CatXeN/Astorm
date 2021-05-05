using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AstormServerTest
{
    public static class ClientHelper
    {
        public async static Task<string> GetAuthorization()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31227");
                var json = JsonConvert.SerializeObject(new LoginJson { Username = "maciek", Password = "demo123@" });
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/auth/authorization", data);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }

    public class LoginJson
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
