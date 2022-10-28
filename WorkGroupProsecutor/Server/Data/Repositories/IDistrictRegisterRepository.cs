using WorkGroupProsecutor.Shared.Models;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface IDistrictRegisterRepository
    {
        Task<IList<DistrictRegisterModel>> GetAllDistrictRegistry();
        Task<DistrictRegisterModel> GetDistrictRegisterById(int id);
        Task AddDistrictRegister(DistrictRegisterModel register);
        Task UpdateDistrictRegister(DistrictRegisterModel register); //Guid id, 
        Task DeleteDistrictRegister(int id);
    }
}
