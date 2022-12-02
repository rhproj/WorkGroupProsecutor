using System.Net.Http;
using System.Text.Json;
using System.Text;
using WorkGroupProsecutor.Shared.Authentication;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using System.Net.Http.Json;

namespace WorkGroupProsecutor.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AuthenticateUser(LoginRequest loginRequest)
        {
            return await _httpClient.PostAsJsonAsync<LoginRequest>("/api/Account/Login", loginRequest);//_httpClient.PostAsync<LoginRequest>("/api/Account/Login", loginRequest);
        }

        public async Task<string> GetUserDescription(string userName)
        {
            return await _httpClient.GetStringAsync($"api/Account/getUserDescription/{userName}");

            //return await JsonSerializer.DeserializeAsync<string>
            //    (await _httpClient.GetStreamAsync($"api/Account/getUserDescription/{userName}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
