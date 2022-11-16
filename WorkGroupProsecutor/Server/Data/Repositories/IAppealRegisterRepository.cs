using WorkGroupProsecutor.Shared.Models;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    /// <summary>
    /// Registers appeals by date or quarter based on model
    /// </summary>
    public interface IAppealRegisterRepository //NOT USED YET
    {
        Task<IEnumerable<DistrictRegisterModel>> GetAllAppealRegisters();
        Task<DistrictRegisterModel> GetAppealRegisterById(int id);
        Task AddAppealRegister(DistrictRegisterModel register);
        Task UpdateAppealRegister(DistrictRegisterModel register); //Guid id, 
        Task DeleteAppealRegister(int id);
    }
}
