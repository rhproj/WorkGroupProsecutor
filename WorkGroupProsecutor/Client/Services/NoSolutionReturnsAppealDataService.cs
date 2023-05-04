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


        public Task AddNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNoSolutionReturnsAppeal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppeals(string district, string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppealsByDepartment(string district, string department, string period, int year)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsUnansweredForDepartment(string department, string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task<NoSolutionReturnsAppealModelDTO> GetNoSolutionReturnsAppealById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistricts(string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistrictsForDepartment(string department, string period, int year)
        {
            throw new NotImplementedException();
        }



        public Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal)
        {
            throw new NotImplementedException();
        }
    }
}
