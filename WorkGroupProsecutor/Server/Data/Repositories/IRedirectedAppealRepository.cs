using WorkGroupProsecutor.Shared.Models;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface IRedirectedAppealRepository
    {
        //Task<List<RedirectedAppealModel>> GetAllRedirectedAppeals();
        Task<IEnumerable<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year);
        Task<IEnumerable<string>> GetRedirectedAppealPeriods(string district, int year);
        Task<RedirectedAppealModel> GetRedirectedAppealById(int id);
        Task AddRedirectedAppeal(RedirectedAppealModel appeal);//, Department department);
        Task UpdateRedirectedAppeal(RedirectedAppealModel appeal);
        Task DeleteRedirectedAppeal(int id);

        //Task AddDepartment(Department department); //temp
    }
}
