using System.Text;
using System.Text.Json;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Department>>
                (await _httpClient.GetStreamAsync($"api/Department"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });            
        }
    }
}
