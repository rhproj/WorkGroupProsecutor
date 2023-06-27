using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkGroupProsecutor.Server.Controllers;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.ControllersTests
{
    public class RedirectedAppealControllerTests
    {
        private RedirectedAppealController _sutAppealController;
        private Mock<IRedirectedAppealRepository> _appealRepositoryMock;
        private int _testYear = 2030;

        public RedirectedAppealControllerTests()
        {
            _appealRepositoryMock = new Mock<IRedirectedAppealRepository>();
            _sutAppealController = new RedirectedAppealController(_appealRepositoryMock.Object);
        }

        [Fact]
        public async Task GetPeriods_ShouldPass_ExpectedListOfPeriods()
        {
            int periodsCount = 3;
            int periodType = 5;

            var periodsExpected = GetRandom.StringCollection(periodsCount, periodType);
            
            _appealRepositoryMock.Setup(m => m.GetAllRedirectedPeriods(_testYear)).ReturnsAsync(periodsExpected);

            var actionResutl = await _sutAppealController.GetPeriods(_testYear);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResutl).Value;

            Assert.Equal(periodsExpected, resultPeriods);
        }

        [Fact]
        public async Task GetPeriodsByDistrict_ShouldPass_ExpectedListOfPeriods_ForDistrict()
        {
            int periodsCount = 3;
            int periodType = 5;
            string district = GetRandom.String();

            var periodsExpected = GetRandom.StringCollection(periodsCount, periodType);
            
            _appealRepositoryMock.Setup(m => m.GetRedirectedPeriodsByDistrict(district, _testYear)).ReturnsAsync(periodsExpected);

            var actionResutl = await _sutAppealController.GetPeriodsByDistrict(district, _testYear);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResutl).Value;

            Assert.Equal(periodsExpected, resultPeriods);
        }

        [Fact]
        public async Task GetForDepartment_ShouldPass_ExpectedListOfPeriods_ForDepartment()
        {
            int periodsCount = 3;
            int periodType = 5;
            string department = GetRandom.String();

            var periodsExpected = GetRandom.StringCollection(periodsCount, periodType);
            
            _appealRepositoryMock.Setup(m => m.GetRedirectedPeriodsForDepartment(department, _testYear)).ReturnsAsync(periodsExpected);

            var actionResult = await _sutAppealController.GetForDepartment(department, _testYear);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(periodsExpected, resultPeriods);
        }

        [Fact]
        public async Task GetAppeals_ShouldPass_ExpectedRedirectedAppeals()
        {
            string district = GetRandom.String();
            string period = GetRandom.String();
            
            var expectedRedirectedAppeals = RedirectedAppealTestProvider.GetTestRedirectedAppealModelDTOs(10);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedAppeals(district,period, _testYear)).ReturnsAsync(expectedRedirectedAppeals);

            var actionResult = await _sutAppealController.GetAppeals(district, period, _testYear);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedRedirectedAppeals, resultPeriods);
        }

        [Fact]
        public async Task GetAppealsByDepartment_ShouldPass_ExpectedRedirectedAppeals()
        {
            string district = GetRandom.String();
            string department = GetRandom.String();
            string period = GetRandom.String();
           
            var expectedRedirectedAppeals = RedirectedAppealTestProvider.GetTestRedirectedAppealModelDTOs(10);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedAppealsByDepartment(district, department, period, _testYear)).ReturnsAsync(expectedRedirectedAppeals);

            var actionResult = await _sutAppealController.GetAppealsByDepartment(district, department, period, _testYear);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedRedirectedAppeals, resultPeriods);
        }

        [Fact]
        public async Task GetAllUnansweredForDepartment_ShouldPass_ExpectedRedirectedAppeals()
        {
            string department = GetRandom.String();
            string period = GetRandom.String();
            
            var expectedRedirectedAppeals = RedirectedAppealTestProvider.GetTestRedirectedAppealModelDTOs(10);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedUnansweredForDepartment(department, period, _testYear)).ReturnsAsync(expectedRedirectedAppeals);

            var actionResult = await _sutAppealController.GetAllUnansweredForDepartment(department, period, _testYear);
            var resultRedirectedAppeals = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedRedirectedAppeals, resultRedirectedAppeals);
        }

        [Fact]
        public async Task GetUnansweredNumber_ShouldPass_ExpectedNumber()
        {
            int expectedNumber = 10;
            string department = GetRandom.String();
            string period = GetRandom.String();
            
            _appealRepositoryMock.Setup(m => m.GetUnansweredNumberForDepartment(department, period, _testYear)).ReturnsAsync(expectedNumber);

            var actionResult = await _sutAppealController.GetUnansweredNumber(department, period, _testYear);
            var resultNumber = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedNumber, resultNumber);
        }

        [Fact]
        public async Task GetByDistricts_ShouldPass_ExpectedCollectionOfDistricts()
        {
            string period = GetRandom.String();
            
            var expectedDistricts = GetRandom.StringCollection(10, 7);

            _appealRepositoryMock.Setup(m => m.GetRedirectedAppealsByDistricts(period, _testYear)).ReturnsAsync(expectedDistricts);

            var actionResult = await _sutAppealController.GetByDistricts(period, _testYear);
            var resultDistricts = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedDistricts, resultDistricts);
        }

        [Fact]
        public async Task GetByDistrictsForDepartment_ShouldPass_ExpectedCollectionOfDistricts()
        {
            string department = GetRandom.String();
            string period = GetRandom.String();
            
            var expectedDistricts = GetRandom.StringCollection(10, 7);

            _appealRepositoryMock.Setup(m => m.GetRedirectedAppelsByDistrictsForDepartment(department, period, _testYear)).ReturnsAsync(expectedDistricts);

            var actionResult = await _sutAppealController.GetByDistrictsForDepartment(department, period, _testYear);
            var resultDistricts = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedDistricts, resultDistricts);
        }

        [Fact]
        public async Task GetAppealById_ShouldPass_ExpectedAppeal()
        {
            int appealId = GetRandom.Byte();
            var expectedAppeal = RedirectedAppealTestProvider.GenerateAppealModelDTO();

            _appealRepositoryMock.Setup(m => m.GetRedirectedAppealById(appealId)).ReturnsAsync(expectedAppeal);

            var actionResult = await _sutAppealController.GetAppeal(appealId);
            var resultAppeal = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedAppeal, resultAppeal);
        }

        [Fact]
        public async Task Post_ShouldCall_AddRedirectedAppeal()
        {
            var appeal = RedirectedAppealTestProvider.GenerateAppealModelDTO();

            _appealRepositoryMock.Setup(m => m.AddRedirectedAppeal(appeal));

            await _sutAppealController.Post(appeal);

            _appealRepositoryMock.Verify(m => m.AddRedirectedAppeal(appeal), Times.Once);
        }

        [Fact]
        public async Task Put_ShouldCall_UpdateRedirectedAppeal()
        {
            var appeal = RedirectedAppealTestProvider.GenerateAppealModelDTO();

            _appealRepositoryMock.Setup(m => m.UpdateRedirectedAppeal(appeal));

            await _sutAppealController.Put(appeal);

            _appealRepositoryMock.Verify(m => m.UpdateRedirectedAppeal(appeal), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldCall_DeleteRedirectedAppeal()
        {
            var appealId = GetRandom.Byte();

            _appealRepositoryMock.Setup(m => m.DeleteRedirectedAppeal(appealId));

            await _sutAppealController.Delete(appealId);

            _appealRepositoryMock.Verify(m => m.DeleteRedirectedAppeal(appealId), Times.Once);
        }
    }
}
