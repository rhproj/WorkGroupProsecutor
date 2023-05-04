using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class NoSolutionReturnsAppealRepository : INoSolutionReturnsAppealRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public NoSolutionReturnsAppealRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region PERIODS
        public async Task<IEnumerable<string>> GetAllNoSolutionReturnsPeriods(int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(p => p.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync();
        }
        public async Task<IEnumerable<string>> GetNoSolutionReturnsPeriodsByDistrict(string district, int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(a => a.District == district)
                .Where(a => a.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsPeriodsForDepartment(string department, int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.YearInfo == year).Select(p => p.PeriodInfo).Distinct().ToListAsync();
        }
        #endregion


        public async Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppeals(string district, string period, int year)
        {
            var appeals = await _dbContext.NoSolutionAppeal.Include(a => a.Department)
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<NoSolutionReturnsAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppealsByDepartment(string district, string department, string period, int year)
        {
            var appeals = await _dbContext.NoSolutionAppeal.Include(a => a.Department)
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<NoSolutionReturnsAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistricts(string period, int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetNoSolutionReturnsAppelsByDistrictsForDepartment(string department, string period, int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        #region UNANSWERED
        public async Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsUnansweredForDepartment(string department, string period, int year)
        {
            var appeals = await _dbContext.NoSolutionAppeal.Include(a => a.Department)
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year)
                .Where(a => a.DepartmentAssessment == null)
                .ToListAsync();

            return _mapper.Map<IEnumerable<NoSolutionReturnsAppealModelDTO>>(appeals);
        }

        public async Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)
        {
            return await _dbContext.NoSolutionAppeal.Include(a => a.Department)
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year)
                .Where(a => a.DepartmentAssessment == null)
                .CountAsync();
        }
        #endregion

        public async Task<NoSolutionReturnsAppealModelDTO> GetNoSolutionReturnsAppealById(int id)
        {
            var appeal = await _dbContext.NoSolutionAppeal.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<NoSolutionReturnsAppealModelDTO>(appeal);
        }

        public async Task AddNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appealDto)
        {
            var appeal = _mapper.Map<NoSolutionAppealModel>(appealDto);

            await _dbContext.NoSolutionAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appealDto)
        {
            var appealToEdit = await _dbContext.NoSolutionAppeal.FirstOrDefaultAsync(d => d.Id == appealDto.Id);
            if (appealToEdit != null)
            {
                appealToEdit.District = appealDto.District;
                appealToEdit.PeriodInfo = appealDto.PeriodInfo;
                appealToEdit.YearInfo = appealDto.YearInfo;

                appealToEdit.RegistrationNumber = appealDto.RegistrationNumber;
                appealToEdit.NadzorHyperlink = appealDto.NadzorHyperlink;

                appealToEdit.ApplicantFullName = appealDto.ApplicantFullName;

                appealToEdit.DepartmentId = appealDto.DepartmentId;
                appealToEdit.DepartmentAssessment = appealDto.DepartmentAssessment;

                appealToEdit.DepartmentResolution = appealDto.DepartmentResolution;
                appealToEdit.DecisionBasis = appealDto.DecisionBasis;

                _dbContext.NoSolutionAppeal.Update(appealToEdit);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteNoSolutionReturnsAppeal(int id)
        {
            var appeal = await _dbContext.NoSolutionAppeal.FirstOrDefaultAsync(a => a.Id == id);
            if (appeal != null)
            {
                _dbContext.NoSolutionAppeal.Remove(appeal);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
