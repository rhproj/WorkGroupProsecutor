using System.Text;
using System.Text.Json;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Services
{ 
    public class SatisfiedAppealDataService : ISatisfiedAppealDataService
    {
        private readonly HttpClient _httpClient;
        public SatisfiedAppealDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedAppeals(string district, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<SatisfiedAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedAppealsForDepartment(string district, string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<SatisfiedAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/getAllForDepartment/{district}/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedUnansweredForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<SatisfiedAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/getAllUnansweredForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<int>(await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/getUnansweredNumberForDepartment/{department}/{period}/{year}"));
        }

        public async Task<IEnumerable<string>> GetSatisfiedAppealsByDistricts(string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/getByDistricts/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<IEnumerable<string>> GetSatisfiedAppealsByDistrictsForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/getByDistrictsForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<SatisfiedAppealModelDTO> GetSatisfiedAppealById(int id)
        {
            return await JsonSerializer.DeserializeAsync<SatisfiedAppealModelDTO>
                (await _httpClient.GetStreamAsync($"api/SatisfiedAppeal/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddSatisfiedAppeal(SatisfiedAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/SatisfiedAppeal", appealJson);
        }

        public async Task UpdateSatisfiedAppeal(SatisfiedAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/SatisfiedAppeal", appealJson);
        }

        public async Task DeleteSatisfiedAppeal(int id)
        {
            await _httpClient.DeleteAsync($"api/SatisfiedAppeal/{id}");
        }

    }
}
