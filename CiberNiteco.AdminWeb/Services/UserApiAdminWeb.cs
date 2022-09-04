using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CiberNiteco.Entities.Models.Users;
using Newtonsoft.Json;

namespace CiberNiteco.AdminWeb.Services
{
    public class UserApiAdminWeb : IUserApiAdminWeb
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserApiAdminWeb(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/users/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}