using System.Text.Json;
using System.Text;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Services
{
    public class NoSolutionAppealDataService : INoSolutionAppealDataService
    {
        private readonly HttpClient _httpClient;
        public NoSolutionAppealDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionAppeals(string district, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<NoSolutionAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionAppealsForDepartment(string district, string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<NoSolutionAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionAppeal/getAllForDepartment/{district}/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionUnansweredForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<NoSolutionAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionAppeal/getAllUnansweredForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetNoSolutionAppealsByDistricts(string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionAppeal/getByDistricts/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<IEnumerable<string>> GetNoSolutionAppealsByDistrictsForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionAppeal/getByDistrictsForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<NoSolutionAppealModelDTO> GetNoSolutionAppealById(int id)
        {
            return await JsonSerializer.DeserializeAsync<NoSolutionAppealModelDTO>
                (await _httpClient.GetStreamAsync($"api/NoSolutionAppeal/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddNoSolutionAppeal(NoSolutionAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/NoSolutionAppeal", appealJson);
        }

        public async Task UpdateNoSolutionAppeal(NoSolutionAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/NoSolutionAppeal", appealJson);
        }

        public async Task DeleteNoSolutionAppeal(int id)
        {
            await _httpClient.DeleteAsync($"api/NoSolutionAppeal/{id}");
        }
    }
}
