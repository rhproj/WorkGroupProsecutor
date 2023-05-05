using System.Text;
using System.Text.Json;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Services
{
    public class NoSolutionReturnsAppealDataService : INoSolutionReturnsAppealDataService
    {
        private readonly HttpClient _httpClient;
        public NoSolutionReturnsAppealDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region PERIODS
        public async Task<IEnumerable<string>> GetAllNoSolutionReturnsPeriods(int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getPeriods/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsPeriodsByDistrict(string district, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/{district}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsPeriodsForDepartment(string department, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getForDepartment/{department}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        #endregion

        public async Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppeals(string district, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<NoSolutionReturnsAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/{district}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppealsByDepartment(string district, string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<NoSolutionReturnsAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getAllByDepartment/{district}/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsUnansweredForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<NoSolutionReturnsAppealModelDTO>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getAllUnansweredForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<int>(await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getUnansweredNumberForDepartment/{department}/{period}/{year}"));
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistricts(string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getByDistricts/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistrictsForDepartment(string department, string period, int year)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/getByDistrictsForDepartment/{department}/{period}/{year}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<NoSolutionReturnsAppealModelDTO> GetNoSolutionReturnsAppealById(int id)
        {
            return await JsonSerializer.DeserializeAsync<NoSolutionReturnsAppealModelDTO>
                (await _httpClient.GetStreamAsync($"api/NoSolutionReturnsAppeal/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/NoSolutionReturnsAppeal", appealJson);
        }

        public async Task UpdateNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal)
        {
            var appealJson = new StringContent(JsonSerializer.Serialize(appeal), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/NoSolutionReturnsAppeal", appealJson);
        }

        public async Task DeleteNoSolutionReturnsAppeal(int id)
        {
            await _httpClient.DeleteAsync($"api/NoSolutionReturnsAppeal/{id}");
        }
    }
}
