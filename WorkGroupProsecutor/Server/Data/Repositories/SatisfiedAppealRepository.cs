using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class SatisfiedAppealRepository : ISatisfiedAppealRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public SatisfiedAppealRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedAppeals(string district, string period, int year)
        {
            var appeals = await _dbContext.SatisfiedAppeal.Include(a => a.Department) //"AppealClassification"
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<SatisfiedAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<SatisfiedAppealModelDTO>> GetAllSatisfiedAppealsForDepartment(string district, string department, string period, int year)
        {
            var appeals = await _dbContext.SatisfiedAppeal.Include(a => a.Department) //"AppealClassification"
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.District == district)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).ToListAsync();

            return _mapper.Map<IEnumerable<SatisfiedAppealModelDTO>>(appeals);
        }

        public async Task<IEnumerable<string>> GetSatisfiedAppealsByDistricts(string period, int year)
        {
            return await _dbContext.SatisfiedAppeal
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetSatisfiedAppealsByDistrictsForDepartment(string department, string period, int year)
        {
            return await _dbContext.SatisfiedAppeal
                .Where(a => a.Department.DepartmentIndex == department)
                .Where(a => a.PeriodInfo == period)
                .Where(a => a.YearInfo == year).Select(a => a.District).Distinct().ToListAsync();
        }

        public async Task<SatisfiedAppealModelDTO> GetSatisfiedAppealById(int id)
        {
            var appeal = await _dbContext.SatisfiedAppeal.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<SatisfiedAppealModelDTO>(appeal);
        }

        public async Task AddSatisfiedAppeal(SatisfiedAppealModelDTO appealDto)
        {
            var appeal = _mapper.Map<SatisfiedAppealModel>(appealDto);

            await _dbContext.SatisfiedAppeal.AddAsync(appeal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSatisfiedAppeal(SatisfiedAppealModelDTO appealDto)
        {
            var appealToEdit = await _dbContext.SatisfiedAppeal.FirstOrDefaultAsync(d => d.Id == appealDto.Id);

            appealToEdit.District = appealDto.District;
            appealToEdit.PeriodInfo = appealDto.PeriodInfo;
            appealToEdit.YearInfo = appealDto.YearInfo;

            appealToEdit.RegistrationNumber = appealDto.RegistrationNumber;
            appealToEdit.NadzorHyperlink = appealDto.NadzorHyperlink;

            appealToEdit.ApplicantFullName = appealDto.ApplicantFullName;

            appealToEdit.DepartmentId = appealDto.DepartmentId;
            appealToEdit.DepartmentAssessment = appealDto.DepartmentAssessment;

            appealToEdit.ProsecutorAction = appealDto.ProsecutorAction;
            appealToEdit.InvestigationResults = appealDto.InvestigationResults;
            appealToEdit.RightsRestoration = appealDto.RightsRestoration;
            appealToEdit.ApplicantNotification = appealDto.ApplicantNotification;

            _dbContext.SatisfiedAppeal.Update(appealToEdit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSatisfiedAppeal(int id)
        {
            var appeal = await _dbContext.SatisfiedAppeal.FirstOrDefaultAsync(a => a.Id == id);
            _dbContext.SatisfiedAppeal.Remove(appeal);
            await _dbContext.SaveChangesAsync();
        }

    }
}
