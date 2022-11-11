using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class RedirectedAppealRepository : IRedirectedAppealRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RedirectedAppealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<List<RedirectedAppealModel>> GetAllRedirectedAppeals()
        //{
        //    return await _dbContext.RedirectedAppeal
        //        .Where(a => a.District == "Mamadysh")
        //        .Where(a => a.PeriodInfo == "17.10")
        //        .Where(a => a.YearInfo == 2022).ToListAsync();
        //}

        public async Task<List<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();
        }

        public Task<RedirectedAppealModel> GetRedirectedAppealById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModel appeal)
        {
            await _dbContext.RedirectedAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();
        }
        public Task UpdateRedirectedAppeal(RedirectedAppealModel appeal)
        {
            throw new NotImplementedException();
        }
        public Task DeleteRedirectedAppeal(int id)
        {
            throw new NotImplementedException();
        }

    }
}
