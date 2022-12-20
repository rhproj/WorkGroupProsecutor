using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface ISatisfiedAppealRepository
    {
        Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedAppeals(string district, string period, int year);
        Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedAppealsForDepartment(string district, string department, string period, int year);
        Task<IEnumerable<string>> GetSatisfiedAppealsByDistricts(string period, int year);
        Task<IEnumerable<string>> GetSatisfiedAppealsByDistrictsForDepartment(string department, string period, int year);
        Task<SatisfiedAppealModelDTO> GetSatisfiedAppealById(int id);
        Task AddSatisfiedAppeal(SatisfiedAppealModelDTO appeal);
        Task UpdateSatisfiedAppeal(SatisfiedAppealModelDTO appeal);
        Task DeleteSatisfiedAppeal(int id);
    }
}
