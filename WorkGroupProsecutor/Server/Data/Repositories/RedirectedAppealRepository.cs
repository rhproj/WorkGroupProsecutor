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
                .Where(a => a.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync(); //.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRedirectedByDistricts(string period, int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<RedirectedAppealModelDTO> GetRedirectedAppealById(int id)
        {
            var appeal = await _dbContext.RedirectedAppeal.FirstOrDefaultAsync(a=>a.Id == id);
            return _mapper.Map<RedirectedAppealModelDTO>(appeal);
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


        public async Task UpdateRedirectedAppeal(RedirectedAppealModelDTO appealDto)
        {
            //var appeal = _mapper.Map<RedirectedAppealModel>(appealDto);

            var appealToEdit = await _dbContext.RedirectedAppeal.FirstOrDefaultAsync(d => d.Id == appealDto.Id);

            appealToEdit.RegistrationNumber = appealDto.RegistrationNumber;
            appealToEdit.DecisionBasis = appealDto.DecisionBasis;

            appealToEdit.District = appealDto.District;
            appealToEdit.ApplicantFullName = appealDto.ApplicantFullName;

            appealToEdit.DepartmentId = appealDto.DepartmentId;
            appealToEdit.DepartmentAssessment = appealDto.DepartmentAssessment;

            appealToEdit.PeriodInfo = appealDto.PeriodInfo;
            appealToEdit.YearInfo = appealDto.YearInfo;

            appealToEdit.RecipientAgency = appealDto.RecipientAgency;

            _dbContext.RedirectedAppeal.Update(appealToEdit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRedirectedAppeal(int id)
        {
            var appeal = await _dbContext.RedirectedAppeal.FirstOrDefaultAsync(a => a.Id == id);
            _dbContext.RedirectedAppeal.Remove(appeal);
            await _dbContext.SaveChangesAsync();
        }
    }
}
