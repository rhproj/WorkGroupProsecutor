using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class AppealRegisterRepository : IAppealRegisterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AppealRegisterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DistrictRegisterModel>> GetAllAppealRegisters()
        {
            //return await _dbContext.
            throw new NotImplementedException();
        }

        public Task<DistrictRegisterModel> GetAppealRegisterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAppealRegister(DistrictRegisterModel register)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAppealRegister(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAppealRegister(DistrictRegisterModel register)
        {
            throw new NotImplementedException();
        }
    }
}
