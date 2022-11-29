using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Services
{
    public interface IRedirectedAppealDataService
    {
        Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppeals(string district, string period, int year);
        Task<IEnumerable<string>> GetAllRedirectedPeriods(int year); 
        Task<IEnumerable<string>> GetRedirectedPeriodsByDistrict(string district, int year);
        Task<IEnumerable<string>> GetRedirectedAppealsByDistricts(string period, int year);
        Task<RedirectedAppealModelDTO> GetRedirectedAppealById(int id);
        Task AddRedirectedAppeal(RedirectedAppealModelDTO appeal);
        Task UpdateRedirectedAppeal(RedirectedAppealModelDTO appeal);
        Task DeleteRedirectedAppeal(int id);
    }
}
