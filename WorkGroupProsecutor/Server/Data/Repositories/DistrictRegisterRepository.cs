using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class DistrictRegisterRepository : IDistrictRegisterRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DistrictRegisterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<DistrictRegisterModel>> GetAllDistrictRegistry()
        {
            throw new NotImplementedException();
            //return await _dbContext.DistrictRegister.Where(a=>a.Dis = District.Mamadysh).ToListAsync();
        }

        public async Task<DistrictRegisterModel> GetDistrictRegisterById(int id)
        {
            throw new NotImplementedException();
            // return await _dbContext.DistrictRegister.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddDistrictRegister(DistrictRegisterModel register)
        {
            throw new NotImplementedException();
            //ArgumentNullException.ThrowIfNull(register);
            //await _dbContext.DistrictRegister.AddAsync(register);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDistrictRegister(DistrictRegisterModel register)
        {
            //ArgumentNullException.ThrowIfNull(register);
            var regiterToUpdate = await _dbContext.DistrictRegister.FirstOrDefaultAsync(r => r.Id == register.Id);
            ArgumentNullException.ThrowIfNull(regiterToUpdate);
            regiterToUpdate.YearInfo = register.YearInfo;
            regiterToUpdate.QuarterInfo = register.QuarterInfo;
            regiterToUpdate.EntryDate = register.EntryDate;

            _dbContext.Update(regiterToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDistrictRegister(int id)
        {
            var regiterToDelete = await _dbContext.DistrictRegister.FirstOrDefaultAsync(r => r.Id == id);
            ArgumentNullException.ThrowIfNull(regiterToDelete);
            _dbContext.DistrictRegister.Remove(regiterToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
