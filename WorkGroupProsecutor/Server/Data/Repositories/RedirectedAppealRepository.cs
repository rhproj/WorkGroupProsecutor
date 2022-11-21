using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class RedirectedAppealRepository : IRedirectedAppealRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public RedirectedAppealRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppeals(string district, string period, int year)
        {
            var appeals = await _dbContext.RedirectedAppeal.Include(a=>a.Department) //"AppealClassification"
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<RedirectedAppealModelDTO>>(appeals);
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

        //public async Task AddRedirectedAppeal(RedirectedAppealModel appeal)
        //{
        //    await _dbContext.RedirectedAppeal.AddAsync(appeal);
        //    await _dbContext.SaveChangesAsync();

        //    //await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Department OFF;");
        //}
        public async Task AddRedirectedAppeal(RedirectedAppealModelDTO appealDto)
        {
            var appeal = _mapper.Map<RedirectedAppealModel>(appealDto);

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
