using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models;

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
            return await _dbContext.DistrictRegister.ToListAsync();
        }

        public async Task<DistrictRegisterModel> GetDistrictRegisterById(int id)
        {
            return await _dbContext.DistrictRegister.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddDistrictRegister(DistrictRegisterModel register)
        {
            ArgumentNullException.ThrowIfNull(register);
            await _dbContext.DistrictRegister.AddAsync(register);
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
