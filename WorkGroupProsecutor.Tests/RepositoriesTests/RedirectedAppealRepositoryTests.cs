using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.RepositoriesTests
{
    public class RedirectedAppealRepositoryTests : RedirectedAppealRepositoryTestBase
    {
        private int _testYear = 2030;

        [Fact]
        public async Task GetAllRedirectedPeriods_ShouldReturnExpectedPeriods()
        {
            var expectedPeriods = new string[] { "period1", "period2", "period3" };

            var result = await _sutRedirectedAppealRepository.GetAllRedirectedPeriods(_testYear);

            Assert.Equal(expectedPeriods, result);
        }

        [Fact]
        public async Task GetRedirectedPeriodsByDistrict_ShouldReturnExpectedPeriods()
        {
            var testDistrict = "district3";

            var expectedPeriods = new string[] { "period1", "period3" };

            var result = await _sutRedirectedAppealRepository.GetRedirectedPeriodsByDistrict(testDistrict, _testYear);

            Assert.Equal(expectedPeriods, result);
        }

        [Fact]
        public async Task GetRedirectedPeriodsForDepartment_ShouldReturnExpectedPeriods()
        {
            var testDepartmentIdx = "D01";

            var expectedPeriods = new string[] { "period1", "period2" };

            var result = await _sutRedirectedAppealRepository.GetRedirectedPeriodsForDepartment(testDepartmentIdx, _testYear);

            Assert.Equal(expectedPeriods, result);
        }

        [Fact]
        public async Task GetAllRedirectedAppeals_ShouldReturnExpectedAppeals()
        {
            var testPeriod = "period1";
            var testDistrict = "district3";

            var result = await _sutRedirectedAppealRepository.GetAllRedirectedAppeals(testDistrict, testPeriod, _testYear);

            Assert.Equal(4, result.Count());
            Assert.Collection(result,
                a => { Assert.Equal("D01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal("K01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal("D01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal("K01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); });
        }

        [Fact]
        public async Task GetAllRedirectedAppealsByDepartment_ShouldReturnExpectedAppeals()
        {
            var testPeriod = "period1";
            var testDistrict = "district3";
            var department = "D01";

            var result = await _sutRedirectedAppealRepository.GetAllRedirectedAppealsByDepartment(testDistrict, department, testPeriod, _testYear);
            
            Assert.Equal(2, result.Count());
            Assert.Collection(result,
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); });
        }

        [Fact]
        public async Task GetAllRedirectedUnansweredForDepartment_ShouldReturnExpectedAppeals()
        {
            var testPeriod = "period1";
            var department = "K01";

            var result = await _sutRedirectedAppealRepository.GetAllRedirectedUnansweredForDepartment(department, testPeriod, _testYear);

            Assert.Equal(2, result.Count());
            Assert.Collection(result,
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo);},
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo);});
        }

        [Fact]
        public async Task GetUnansweredNumberForDepartment_ShouldReturnExpectedNumber()
        {
            var testPeriod = "period1";
            var department = "K01";

            var result = await _sutRedirectedAppealRepository.GetUnansweredNumberForDepartment(department, testPeriod, _testYear);

            Assert.Equal(2, result);
        }
                        
        [Fact]
        public async Task GetRedirectedAppealsByDistricts_ShouldReturnExpectedDistricts()
        {
            var testPeriod = "period1";
            var expectedDistricts = new string[] { "district3", "district2" };

            var result = await _sutRedirectedAppealRepository.GetRedirectedAppealsByDistricts(testPeriod, _testYear);

            Assert.Equal(expectedDistricts, result);
        }

        [Fact]
        public async Task GetRedirectedAppelsByDistrictsForDepartment_ShouldReturnExpectedDistricts()
        {
            var testPeriod = "period1";
            var department = "K01";
            var expectedDistricts = new string[] { "district3" };

            var result = await _sutRedirectedAppealRepository.GetRedirectedAppelsByDistrictsForDepartment(department, testPeriod, _testYear);

            Assert.Equal(expectedDistricts, result);
        }

        [Fact]
        public async Task GetRedirectedAppealById_ShouldReturnExpectedAppeal()
        {
            var id = 10;                   
            var expectedAppeal = new RedirectedAppealModelDTO { Id = 10, YearInfo = 2030, PeriodInfo = "period1", District = "district3"}; //_mapper.Map<RedirectedAppealModelDTO>(appealToAdd);

            var result = await _sutRedirectedAppealRepository.GetRedirectedAppealById(id);

            Assert.Equal(expectedAppeal.Id, result.Id);
            Assert.Equal(expectedAppeal.YearInfo, result.YearInfo);
            Assert.Equal(expectedAppeal.PeriodInfo, result.PeriodInfo);
            Assert.Equal(expectedAppeal.District, result.District);
        }

        [Fact]
        public async Task AddRedirectedAppeal_ShouldAdd_1Appeal()
        {
            var appealToAdd = new RedirectedAppealModelDTO
            {
                Id = 11,
                YearInfo = _testYear,
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                RegistrationNumber = GetRandom.String(),
                DecisionBasis = GetRandom.String(),
                DepartmentAssessment = GetRandom.String(),
                RecipientAgency = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                DepartmentId = GetRandom.Byte()
            };

            await _sutRedirectedAppealRepository.AddRedirectedAppeal(appealToAdd);

            Assert.Equal(11,_dbContext.RedirectedAppeal.Count());
            Assert.Contains(_dbContext.RedirectedAppeal, a => a.Id == 11);
        }

        [Fact]
        public async Task UpdateRedirectedAppeal_ShouldUpdate_1Appeal()
        {
            int targetId = 5;

            var expectedAppeal = new RedirectedAppealModelDTO
            {
                Id = targetId,
                YearInfo = _testYear,
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                RegistrationNumber = GetRandom.String(),
                DecisionBasis = GetRandom.String(),
                DepartmentAssessment = GetRandom.String(),
                RecipientAgency = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                DepartmentId = GetRandom.Byte()
            };
            await _sutRedirectedAppealRepository.UpdateRedirectedAppeal(expectedAppeal);

            var result = await _sutRedirectedAppealRepository.GetRedirectedAppealById(targetId);

            Assert.Equal(10, _dbContext.RedirectedAppeal.Count());

            Assert.Equal(expectedAppeal.Id, result.Id);
            Assert.Equal(expectedAppeal.YearInfo, result.YearInfo);
            Assert.Equal(expectedAppeal.PeriodInfo, result.PeriodInfo);
            Assert.Equal(expectedAppeal.District, result.District);
            Assert.Equal(expectedAppeal.ApplicantFullName, result.ApplicantFullName);
            Assert.Equal(expectedAppeal.RegistrationNumber, result.RegistrationNumber);
            Assert.Equal(expectedAppeal.DecisionBasis, result.DecisionBasis);
            Assert.Equal(expectedAppeal.DepartmentAssessment, result.DepartmentAssessment);
            Assert.Equal(expectedAppeal.RecipientAgency, result.RecipientAgency);
            Assert.Equal(expectedAppeal.NadzorHyperlink, result.NadzorHyperlink);
            Assert.Equal(expectedAppeal.DepartmentId, result.DepartmentId);
        }

        [Fact]
        public async Task DeleteRedirectedAppeal_ShouldDelete_1Appeal()
        {
            await _sutRedirectedAppealRepository.DeleteRedirectedAppeal(10);

            Assert.Equal(9, _dbContext.RedirectedAppeal.Count());
            Assert.DoesNotContain(_dbContext.RedirectedAppeal, a => a.Id == 10);
        }
    }
}