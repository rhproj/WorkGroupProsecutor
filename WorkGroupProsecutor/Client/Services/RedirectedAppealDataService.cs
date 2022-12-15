using System.Text;
using System.Text.Json;
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

        public async Task<IEnumerable<string>> GetAllRedirectedPeriods(int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/getPeriods/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetRedirectedPeriodsByDistrict(string district, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetRedirectedPeriodsForDepartment(string department, int year) //n
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/getForDepartment/{department}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppeals(string district, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<RedirectedAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        
        public async Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppealsByDepartment(string district, string department, string period, int year) //m
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<RedirectedAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/getAllByDepartment/{district}/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetRedirectedAppealsByDistricts(string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/getByDistricts/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetRedirectedAppealsByDistrictsForDepartment(string department, string period, int year) //n
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/RedirectedAppeal/getByDistrictsForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/RedirectedAppeal", appealJson); //var response = 
        }

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
