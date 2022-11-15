using WorkGroupProsecutor.Shared.Models.Appeal;

namespace WorkGroupProsecutor.Client.Services
{
    public interface IRedirectedAppealDataService
    {
        Task<IEnumerable<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year);
        Task<IEnumerable<string>> GetRedirectedAppealPeriods(string district, int year);
        Task<RedirectedAppealModel> GetRedirectedAppealById(int id);
        Task AddRedirectedAppeal(RedirectedAppealModel appeal);
        Task UpdateRedirectedAppeal(RedirectedAppealModel appeal);
        Task DeleteRedirectedAppeal(int id);
    }
}
