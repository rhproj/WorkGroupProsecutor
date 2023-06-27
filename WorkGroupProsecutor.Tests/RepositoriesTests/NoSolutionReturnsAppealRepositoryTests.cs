using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.RepositoriesTests
{
    public class NoSolutionReturnsAppealRepositoryTests : NoSolutionReturnsAppealRepositoryTestBase
    {
        private int _testYear = 2030;



        [Fact]
        public async Task GetAllNoSolutionReturnsPeriods_ShouldReturnExpectedPeriods()
        {
            var expectedPeriods = new string[] { "period1", "period2", "period3" };

            var result = await _sutNoSolutionReturnsAppealRepository.GetAllNoSolutionReturnsPeriods(_testYear);

            Assert.Equal(expectedPeriods, result);
        }

        [Fact]
        public async Task GetNoSolutionReturnsPeriodsByDistrict_ShouldReturnExpectedPeriods()
        {
            var testDistrict = "district3";

            var expectedPeriods = new string[] { "period1", "period3" };

            var result = await _sutNoSolutionReturnsAppealRepository.GetNoSolutionReturnsPeriodsByDistrict(testDistrict, _testYear);

            Assert.Equal(expectedPeriods, result);
        }

        [Fact]
        public async Task GetNoSolutionReturnsPeriodsForDepartment_ShouldReturnExpectedPeriods()
        {
            var testDepartmentIdx = "D01";

            var expectedPeriods = new string[] { "period1", "period2" };

            var result = await _sutNoSolutionReturnsAppealRepository.GetNoSolutionReturnsPeriodsForDepartment(testDepartmentIdx, _testYear);

            Assert.Equal(expectedPeriods, result);
        }

        [Fact]
        public async Task GetAllNoSolutionReturnsAppeals_ShouldReturnExpectedAppeals()
        {
            var testPeriod = "period1";
            var testDistrict = "district3";

            var result = await _sutNoSolutionReturnsAppealRepository.GetAllNoSolutionReturnsAppeals(testDistrict, testPeriod, _testYear);

            Assert.Equal(4, result.Count());
            Assert.Collection(result,
                a => { Assert.Equal("D01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal("K01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal("D01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal("K01", a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); });
        }

        [Fact]
        public async Task GetAllNoSolutionReturnsAppealsByDepartment_ShouldReturnExpectedAppeals()
        {
            var testPeriod = "period1";
            var testDistrict = "district3";
            var department = "D01";

            var result = await _sutNoSolutionReturnsAppealRepository.GetAllNoSolutionReturnsAppealsByDepartment(testDistrict, department, testPeriod, _testYear);

            Assert.Equal(2, result.Count());
            Assert.Collection(result,
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); },
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); Assert.Equal(testDistrict, a.District); });
        }

        [Fact]
        public async Task GetAllNoSolutionReturnsUnansweredForDepartment_ShouldReturnExpectedAppeals()
        {
            var testPeriod = "period1";
            var department = "K01";

            var result = await _sutNoSolutionReturnsAppealRepository.GetAllNoSolutionReturnsUnansweredForDepartment(department, testPeriod, _testYear);

            Assert.Equal(2, result.Count());
            Assert.Collection(result,
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); },
                a => { Assert.Equal(department, a.Department.DepartmentIndex); Assert.Equal(_testYear, a.YearInfo); Assert.Equal(testPeriod, a.PeriodInfo); });
        }

        [Fact]
        public async Task GetUnansweredNumberForDepartment_ShouldReturnExpectedNumber()
        {
            var testPeriod = "period1";
            var department = "K01";

            var result = await _sutNoSolutionReturnsAppealRepository.GetUnansweredNumberForDepartment(department, testPeriod, _testYear);

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetNoSolutionReturnsAppealsByDistricts_ShouldReturnExpectedDistricts()
        {
            var testPeriod = "period1";
            var expectedDistricts = new string[] { "district3", "district2" };

            var result = await _sutNoSolutionReturnsAppealRepository.GetNoSolutionReturnsAppealsByDistricts(testPeriod, _testYear);

            Assert.Equal(expectedDistricts, result);
        }

        [Fact]
        public async Task GetNoSolutionReturnsAppelsByDistrictsForDepartment_ShouldReturnExpectedDistricts()
        {
            var testPeriod = "period1";
            var department = "K01";
            var expectedDistricts = new string[] { "district3" };

            var result = await _sutNoSolutionReturnsAppealRepository.GetNoSolutionReturnsAppelsByDistrictsForDepartment(department, testPeriod, _testYear);

            Assert.Equal(expectedDistricts, result);
        }

        [Fact]
        public async Task GetNoSolutionReturnsAppealById_ShouldReturnExpectedAppeal()
        {
            var id = 10;
            var expectedAppeal = new RedirectedAppealModelDTO { Id = 10, YearInfo = 2030, PeriodInfo = "period1", District = "district3" }; //_mapper.Map<RedirectedAppealModelDTO>(appealToAdd);

            var result = await _sutNoSolutionReturnsAppealRepository.GetNoSolutionReturnsAppealById(id);

            Assert.Equal(expectedAppeal.Id, result.Id);
            Assert.Equal(expectedAppeal.YearInfo, result.YearInfo);
            Assert.Equal(expectedAppeal.PeriodInfo, result.PeriodInfo);
            Assert.Equal(expectedAppeal.District, result.District);
        }

        [Fact]
        public async Task AddNoSolutionReturnsAppeal_ShouldAdd_1Appeal()
        {
            var appealToAdd = new NoSolutionReturnsAppealModelDTO
            {
                Id = 11,
                YearInfo = _testYear,
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                RegistrationNumber = GetRandom.String(),
                DepartmentResolution = GetRandom.String(),
                DecisionBasis = GetRandom.String(),
                DepartmentAssessment = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                DepartmentId = GetRandom.Byte()
            };

            await _sutNoSolutionReturnsAppealRepository.AddNoSolutionReturnsAppeal(appealToAdd);

            Assert.Equal(11, _dbContext.NoSolutionAppeal.Count());
            Assert.Contains(_dbContext.NoSolutionAppeal, a => a.Id == 11);
        }

        [Fact]
        public async Task UpdateRedirectedAppeal_ShouldUpdate_1Appeal()
        {
            int targetId = 5;

            var expectedAppeal = new NoSolutionReturnsAppealModelDTO
            {
                Id = targetId,
                YearInfo = _testYear,
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                RegistrationNumber = GetRandom.String(),
                DecisionBasis = GetRandom.String(),
                DepartmentAssessment = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                DepartmentId = GetRandom.Byte(),
                DepartmentResolution= GetRandom.String()
            };
            await _sutNoSolutionReturnsAppealRepository.UpdateNoSolutionReturnsAppeal(expectedAppeal);

            var result = await _sutNoSolutionReturnsAppealRepository.GetNoSolutionReturnsAppealById(targetId);

            Assert.Equal(10, _dbContext.NoSolutionAppeal.Count());

            Assert.Equal(expectedAppeal.Id, result.Id);
            Assert.Equal(expectedAppeal.YearInfo, result.YearInfo);
            Assert.Equal(expectedAppeal.PeriodInfo, result.PeriodInfo);
            Assert.Equal(expectedAppeal.District, result.District);
            Assert.Equal(expectedAppeal.ApplicantFullName, result.ApplicantFullName);
            Assert.Equal(expectedAppeal.RegistrationNumber, result.RegistrationNumber);
            Assert.Equal(expectedAppeal.DecisionBasis, result.DecisionBasis);
            Assert.Equal(expectedAppeal.DepartmentAssessment, result.DepartmentAssessment);
            Assert.Equal(expectedAppeal.DepartmentResolution, result.DepartmentResolution);
            Assert.Equal(expectedAppeal.NadzorHyperlink, result.NadzorHyperlink);
            Assert.Equal(expectedAppeal.DepartmentId, result.DepartmentId);
        }

        [Fact]
        public async Task DeleteNoSolutionReturnsAppeal_ShouldDelete_1Appeal()
        {
            await _sutNoSolutionReturnsAppealRepository.DeleteNoSolutionReturnsAppeal(10);

            Assert.Equal(9, _dbContext.NoSolutionAppeal.Count());
            Assert.DoesNotContain(_dbContext.NoSolutionAppeal, a => a.Id == 10);
        }

    }
}
