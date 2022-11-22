using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Services
{
    public class RedirectedAppealDataService : IRedirectedAppealDataService
    {
        private readonly HttpClient _httpClient;
        public RedirectedAppealDataService(HttpClient httpClient)
        {
            _httpClient= httpClient;
        }
        //public async Task<IEnumerable<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year)
        //{
        //    return await JsonSerializer.DeserializeAsync<IEnumerable<RedirectedAppealModel>>
        //        (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //}
        public async Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppeals(string district, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<RedirectedAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetRedirectedAppealPeriods(string district, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/RedirectedAppeal", appealJson); //var response = 
        }

        //public async Task<Employee> AddEmployee(Employee employee)
        //{
        //    var employeeJson =
        //        new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync("api/employee", employeeJson);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
        //    }

        //    return null;
        //}


        public async Task<RedirectedAppealModelDTO> GetRedirectedAppealById(int id)
        {
            return await JsonSerializer.DeserializeAsync<RedirectedAppealModelDTO>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task UpdateRedirectedAppeal(RedirectedAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/RedirectedAppeal", appealJson);
        }

        public async Task DeleteRedirectedAppeal(int id)
        {
            await _httpClient.DeleteAsync($"api/RedirectedAppeal/{id}");
        }
    }
}
