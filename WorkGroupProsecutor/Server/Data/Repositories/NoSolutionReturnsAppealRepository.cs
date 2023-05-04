using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
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

        public Task AddNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNoSolutionReturnsAppeal(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppeals(string district, string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsAppealsByDepartment(string district, string department, string period, int year)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<NoSolutionReturnsAppealModelDTO>> GetAllNoSolutionReturnsUnansweredForDepartment(string department, string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task<NoSolutionReturnsAppealModelDTO> GetNoSolutionReturnsAppealById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetNoSolutionReturnsAppealsByDistricts(string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetNoSolutionReturnsAppelsByDistrictsForDepartment(string department, string period, int year)
        {
            throw new NotImplementedException();
        }



        public Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNoSolutionReturnsAppeal(NoSolutionReturnsAppealModelDTO appeal)
        {
            throw new NotImplementedException();
        }
    }
}
