using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WorkGroupProsecutor.Shared.Models.Appeal;

namespace WorkGroupProsecutor.Client.Services
{
    public class RedirectedAppealDataService : IRedirectedAppealDataService
    {
        private readonly HttpClient _httpClient;
        public RedirectedAppealDataService(HttpClient httpClient)
        {
            _httpClient= httpClient;
        }
        public async Task<IEnumerable<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<RedirectedAppealModel>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetRedirectedAppealPeriods(string district, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModel appeal)
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


        public Task<RedirectedAppealModel> GetRedirectedAppealById(int id)
        {
            throw new NotImplementedException();
            //return await JsonSerializer.DeserializeAsync<IEnumerable<RedirectedAppealModel>>
            //    (await _httpClient.GetStreamAsync($"api/RedirectedAppeal"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }



        public Task UpdateRedirectedAppeal(RedirectedAppealModel appeal)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRedirectedAppeal(int id)
        {
            throw new NotImplementedException();
        }
    }
}
