using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Server.Controllers;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Shared.Models.Participants;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.ControllersTests
{
    public class RedirectedAppealControllerTests
    {
        private RedirectedAppealController _appealController;
        private Mock<IRedirectedAppealRepository> _appealRepositoryMock;

        public RedirectedAppealControllerTests()
        {
            _appealRepositoryMock = new Mock<IRedirectedAppealRepository>();
        }

        [Fact]
        public async Task GetPeriods_ShouldPass_ExpectedListOfPeriods()
        {
            int periodsCount = 3;
            int periodType = 5;

            List<string> periodsExpected = GetTestPeriods(periodsCount, periodType);
            int year = GetRandom.Int32(2000,3000);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedPeriods(year)).ReturnsAsync(periodsExpected);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResutl = await _appealController.GetPeriods(year);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResutl).Value;

            Assert.Equal(periodsExpected, resultPeriods);
        }

        [Fact]
        public async Task GetPeriodsByDistrict_ShouldPass_ExpectedListOfPeriods_ForDistrict()
        {
            int periodsCount = 3;
            int periodType = 5;
            string district = GetRandom.String();

            List<string> periodsExpected = GetTestPeriods(periodsCount, periodType);
            int year = GetRandom.Int32(2000, 3000);

            _appealRepositoryMock.Setup(m => m.GetRedirectedPeriodsByDistrict(district, year)).ReturnsAsync(periodsExpected);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResutl = await _appealController.GetPeriodsByDistrict(district, year);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResutl).Value;

            Assert.Equal(periodsExpected, resultPeriods);
        }

        [Fact]
        public async Task GetForDepartment_ShouldPass_ExpectedListOfPeriods_ForDepartment()
        {
            int periodsCount = 3;
            int periodType = 5;
            string department = GetRandom.String();

            List<string> periodsExpected = GetTestPeriods(periodsCount, periodType);
            int year = GetRandom.Int16(2000, 3000);

            _appealRepositoryMock.Setup(m => m.GetRedirectedPeriodsForDepartment(department, year)).ReturnsAsync(periodsExpected);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetForDepartment(department, year);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(periodsExpected, resultPeriods);
        }

        [Fact]
        public async Task GetAppeals_ShouldPass_ExpectedRedirectedAppeals()
        {
            string district = GetRandom.String();
            string period = GetRandom.String();
            int year = GetRandom.Int16(2000, 3000);
            var expectedRedirectedAppeals = GetTestRedirectedAppealModelDTOs(10);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedAppeals(district,period, year)).ReturnsAsync(expectedRedirectedAppeals);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetAppeals(district, period, year);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedRedirectedAppeals, resultPeriods);
        }

        [Fact]
        public async Task GetAppealsByDepartment_ShouldPass_ExpectedRedirectedAppeals()
        {
            string district = GetRandom.String();
            string department = GetRandom.String();
            string period = GetRandom.String();
            int year = GetRandom.Int16(2000, 3000);
            var expectedRedirectedAppeals = GetTestRedirectedAppealModelDTOs(10);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedAppealsByDepartment(district, department, period, year)).ReturnsAsync(expectedRedirectedAppeals);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetAppealsByDepartment(district, department, period, year);
            var resultPeriods = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedRedirectedAppeals, resultPeriods);
        }


        private List<RedirectedAppealModelDTO> GetTestRedirectedAppealModelDTOs(int capacity)
        {
            List<RedirectedAppealModelDTO> resultList = new();
            for (int i = 0; i < capacity; i++)
            {
                resultList.Add(GenerateAppealModelDTO());
            }
            return resultList;
        }

        private RedirectedAppealModelDTO GenerateAppealModelDTO()
        {
            return new RedirectedAppealModelDTO()
            {
                Id = GetRandom.Id(),
                RegistrationNumber = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                DepartmentId = GetRandom.Byte(),
                DepartmentAssessment = GetRandom.String(),
                YearInfo = GetRandom.Byte(),
                PeriodInfo = GetRandom.String(),
                District = GetRandom.String(),
                RecipientAgency = GetRandom.String(),
                DecisionBasis = GetRandom.String()
            };
        }

        private List<string> GetTestPeriods(int capacity, int periodType)
        {
            var periodsList = new List<string>();
            for (int i = 0; i < capacity; i++)
            {
                periodsList.Add(GetRandom.String(periodType));
            }
            return periodsList;
        }

        [Fact]
        public void GetTestRedirectedAppealModelDTOsTest() //DELETE
        {
            var result = GetTestRedirectedAppealModelDTOs(10);
            Assert.Equal(10, result.Count());
        }
    }
}
