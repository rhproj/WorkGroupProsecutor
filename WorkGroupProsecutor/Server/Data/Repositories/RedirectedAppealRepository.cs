using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class RedirectedAppealRepository : IRedirectedAppealRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RedirectedAppealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModel appeal)
        {
            await _dbContext.RedirectedAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteRedirectedAppeal(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<RedirectedAppealModel>> GetAllRedirectedAppeals()
        {
            return await _dbContext.RedirectedAppeal.ToListAsync();
        }

        public Task<RedirectedAppealModel> GetRedirectedAppealById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRedirectedAppeal(RedirectedAppealModel appeal)
        {
            throw new NotImplementedException();
        }
    }
}
