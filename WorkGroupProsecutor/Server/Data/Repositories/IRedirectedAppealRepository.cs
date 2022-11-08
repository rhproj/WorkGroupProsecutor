using WorkGroupProsecutor.Shared.Models;
using WorkGroupProsecutor.Shared.Models.Appeal;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface IRedirectedAppealRepository
    {
        Task<IList<RedirectedAppealModel>> GetAllRedirectedAppeals();
        Task<RedirectedAppealModel> GetRedirectedAppealById(int id);
        Task AddRedirectedAppeal(RedirectedAppealModel appeal);
        Task UpdateRedirectedAppeal(RedirectedAppealModel appeal);
        Task DeleteRedirectedAppeal(int id);
    }
}
