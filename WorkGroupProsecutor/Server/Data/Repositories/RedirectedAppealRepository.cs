using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

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
            var appeals = await _dbContext.RedirectedAppeal.Include(a=>a.Department)
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<RedirectedAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedAppealsByDepartment(string district, string department, string period, int year)  //m
        {
            var appeals = await _dbContext.RedirectedAppeal.Include(a => a.Department)
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<RedirectedAppealModelDTO>>(appeals);
        }

        #region UNANSWERED
        public async Task<IEnumerable<RedirectedAppealModelDTO>> GetAllRedirectedUnansweredForDepartment(string department, string period, int year)
        {
            var appeals = await _dbContext.RedirectedAppeal.Include(a => a.Department)
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year)
                .Where(a => a.DepartmentAssessment == null)
                .ToListAsync();

                return _mapper.Map<IEnumerable<RedirectedAppealModelDTO>>(appeals);
        }

        public async Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)
        {
            return await _dbContext.RedirectedAppeal.Include(a => a.Department)
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year)
                .Where(a => a.DepartmentAssessment == null)
                .CountAsync();
        }
        #endregion


        #region PERIODS
        public async Task<IEnumerable<string>> GetAllRedirectedPeriods(int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(p => p.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRedirectedPeriodsByDistrict(string district, int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.District == district)
                .Where(a => a.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRedirectedPeriodsForDepartment(string department, int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync();
        } 
        #endregion

        public async Task<IEnumerable<string>> GetRedirectedAppealsByDistricts(string period, int year)
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }


        public async Task<IEnumerable<string>> GetRedirectedAppelsByDistrictsForDepartment(string department,string period, int year) //n
        {
            return await _dbContext.RedirectedAppeal
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<RedirectedAppealModelDTO> GetRedirectedAppealById(int id)
        {
            var appeal = await _dbContext.RedirectedAppeal.FirstOrDefaultAsync(a=>a.Id == id);
            return _mapper.Map<RedirectedAppealModelDTO>(appeal);
        }

        public async Task AddRedirectedAppeal(RedirectedAppealModelDTO appealDto)
        {
            var appeal = _mapper.Map<RedirectedAppealModel>(appealDto);

            await _dbContext.RedirectedAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateRedirectedAppeal(RedirectedAppealModelDTO appealDto)
        {
            var appealToEdit = await _dbContext.RedirectedAppeal.FirstOrDefaultAsync(d => d.Id == appealDto.Id);
            if (appealToEdit != null)
            {
                appealToEdit.District = appealDto.District;
                appealToEdit.PeriodInfo = appealDto.PeriodInfo;
                appealToEdit.YearInfo = appealDto.YearInfo;

                appealToEdit.RegistrationNumber = appealDto.RegistrationNumber;
                appealToEdit.NadzorHyperlink = appealDto.NadzorHyperlink;

                appealToEdit.ApplicantFullName = appealDto.ApplicantFullName;
                appealToEdit.RecipientAgency = appealDto.RecipientAgency;
                appealToEdit.DecisionBasis = appealDto.DecisionBasis;

                appealToEdit.DepartmentId = appealDto.DepartmentId;
                appealToEdit.DepartmentAssessment = appealDto.DepartmentAssessment;

                _dbContext.RedirectedAppeal.Update(appealToEdit);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRedirectedAppeal(int id)
        {
            var appeal = await _dbContext.RedirectedAppeal.FirstOrDefaultAsync(a => a.Id == id);
            if (appeal != null)
            {
                _dbContext.RedirectedAppeal.Remove(appeal);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
