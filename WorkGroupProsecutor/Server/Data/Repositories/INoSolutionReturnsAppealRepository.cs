using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface INoSolutionReturnsAppealRepository
    {
        Task<IEnumerable<string>> GetAllNoSolutionReturnsPeriods(int year);

        Task<IEnumerable<string>> GetNoSolutionReturnsPeriodsByDistrict(string district, int year);

        Task<IEnumerable<string>> GetNoSolutionReturnsPeriodsForDepartment(string department, int year);

        Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppeals(string district, string period, int year);

        Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsUnansweredForDepartment(string department, string period, int year);
        Task<int> GetUnansweredNumberForDepartment(string department, string period, int year);

        Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppealsByDepartment(string district, string department, string period, int year);

        Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistricts(string period, int year);

        Task<IEnumerable<string>> GetNoSolutionReturnsAppelsByDistrictsForDepartment(string department, string period, int year);

        Task<NoSolutionReturnsAppealModelDTO> GetNoSolutionReturnsAppealById(int id);


        Task AddNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal);

        Task UpdateNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal);
        Task DeleteNoSolutionReturnsAppeal(int id);
    }
}
