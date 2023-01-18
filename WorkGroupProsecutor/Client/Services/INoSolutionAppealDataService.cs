using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Client.Services
{
    public interface INoSolutionAppealDataService
    {
        Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionAppeals(string district, string period, int year);
        Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionAppealsForDepartment(string district, string department, string period, int year);
        Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionUnansweredForDepartment(string department, string period, int year);
        Task<int> GetUnansweredNumberForDepartment(string department, string period, int year);
        Task<IEnumerable<string>> GetNoSolutionAppealsByDistricts(string period, int year);
        Task<IEnumerable<string>> GetNoSolutionAppealsByDistrictsForDepartment(string department, string period, int year);
        Task<NoSolutionAppealModelDTO> GetNoSolutionAppealById(int id);
        Task AddNoSolutionAppeal(NoSolutionAppealModelDTO appeal);
        Task UpdateNoSolutionAppeal(NoSolutionAppealModelDTO appeal);
        Task DeleteNoSolutionAppeal(int id);
    }
}
