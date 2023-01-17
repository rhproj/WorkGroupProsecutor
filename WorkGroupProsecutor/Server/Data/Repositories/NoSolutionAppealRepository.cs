using AutoMapper;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Shared.Models.Appeal;
using Microsoft.EntityFrameworkCore;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class NoSolutionAppealRepository : INoSolutionAppealRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public NoSolutionAppealRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionAppeals(string district, string period, int year)
        {
            var appeals = await _dbContext.NoSolutionAppeal.Include(a => a.Department) //"AppealClassification"
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<NoSolutionAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionAppealsForDepartment(string district, string department, string period, int year)
        {
            var appeals = await _dbContext.NoSolutionAppeal.Include(a => a.Department) //"AppealClassification"
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<NoSolutionAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<NoSolutionAppealModelDTO>> GetAllNoSolutionUnansweredForDepartment(string department, string period, int year)
        {
            var appeals = await _dbContext.NoSolutionAppeal.Include(a => a.Department) 
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year)
                .Where(a=>a.DepartmentAssessment == null)
                .ToListAsync();

            return _mapper.Map<IEnumerable<NoSolutionAppealModelDTO>>(appeals);
        }

        //public async Task<int> GetUnansweredNumberForDepartment(string department, string period, int year)


        public async Task<IEnumerable<string>> GetNoSolutiondAppealsByDistricts(string period, int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetNoSolutionAppealsByDistrictsForDepartment(string department, string period, int year)
        {
            return await _dbContext.NoSolutionAppeal
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<NoSolutionAppealModelDTO> GetNoSolutionAppealById(int id)
        {
            var appeal = await _dbContext.NoSolutionAppeal.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<NoSolutionAppealModelDTO>(appeal);
        }

        public async Task AddNoSolutionAppeal(NoSolutionAppealModelDTO appealDto)
        {
            var appeal = _mapper.Map<NoSolutionAppealModel>(appealDto);

            await _dbContext.NoSolutionAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNoSolutionAppeal(NoSolutionAppealModelDTO appealDto)
        {
            var appealToEdit = await _dbContext.NoSolutionAppeal.FirstOrDefaultAsync(d => d.Id == appealDto.Id);

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

        public async Task DeleteNoSolutionAppeal(int id)
        {
            var appeal = await _dbContext.NoSolutionAppeal.FirstOrDefaultAsync(a => a.Id == id);
            _dbContext.NoSolutionAppeal.Remove(appeal);
            await _dbContext.SaveChangesAsync();
        }
    }
}
