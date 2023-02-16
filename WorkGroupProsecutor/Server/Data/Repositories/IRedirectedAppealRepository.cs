using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface IRedirectedAppealRepository
    {
        ////Task<List<RedirectedAppealModel>> GetAllRedirectedAppeals();
        ///
        //Task<IEnumerable<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year);
        Task<IEnumerable<string>> GetAllRedirectedPeriods(int year);

        Task<IEnumerable<string>> GetRedirectedPeriodsByDistrict(string district, int year);

        Task<IEnumerable<string>> GetRedirectedPeriodsForDepartment(string department, int year); //n  int departmentId

        Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppeals(string district, string period, int year);

        Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedUnansweredForDepartment(string department, string period, int year);
        Task<int> GetUnansweredNumberForDepartment(string department, string period, int year);

        Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppealsByDepartment(string district, string department, string period, int year);

        Task<IEnumerable<string>> GetRedirectedAppealsByDistricts(string period, int year);

        Task<IEnumerable<string>> GetRedirectedAppelsByDistrictsForDepartment(string department, string period, int year); //n

        Task<RedirectedAppealModelDTO> GetRedirectedAppealById(int id);

        //Task AddRedirectedAppeal(RedirectedAppealModel appeal);        
        Task AddRedirectedAppeal(RedirectedAppealModelDTO appeal);

        Task UpdateRedirectedAppeal(RedirectedAppealModelDTO appeal);
        Task DeleteRedirectedAppeal(int id);


        //Task AddDepartment(Department department); //temp
    }
}
