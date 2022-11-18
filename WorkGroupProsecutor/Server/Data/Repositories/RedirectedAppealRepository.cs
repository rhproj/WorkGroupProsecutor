using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<RedirectedAppealModel>> GetAllRedirectedAppeals(string district, string period, int year)
        {
            return await _dbContext.RedirectedAppeal.Include(a=>a.AppealClassification) //"AppealClassification"
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRedirectedAppealPeriods(string district, int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.District == district)
                .Where(a => a.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync(); ; //.ToListAsync();
        }

        public Task<RedirectedAppealModel> GetRedirectedAppealById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModel appeal)
        {
            await _dbContext.RedirectedAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();

            //await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Department ON;");
            //await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Department OFF;");
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
