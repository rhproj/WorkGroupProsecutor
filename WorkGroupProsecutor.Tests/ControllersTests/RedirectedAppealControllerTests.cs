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

            var periodsExpected = GetRandom.StringCollection(periodsCount, periodType);
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

            var periodsExpected = GetRandom.StringCollection(periodsCount, periodType);
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

            var periodsExpected = GetRandom.StringCollection(periodsCount, periodType);
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


        #region HOME
        [Fact]
        public async Task GetAllUnansweredForDepartment_ShouldPass_ExpectedRedirectedAppeals()
        {
            string department = GetRandom.String();
            string period = GetRandom.String();
            int year = GetRandom.Int16(2000, 3000);
            var expectedRedirectedAppeals = GetTestRedirectedAppealModelDTOs(10);

            _appealRepositoryMock.Setup(m => m.GetAllRedirectedUnansweredForDepartment(department, period, year)).ReturnsAsync(expectedRedirectedAppeals);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetAllUnansweredForDepartment(department, period, year);
            var resultRedirectedAppeals = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedRedirectedAppeals, resultRedirectedAppeals);
        }

        [Fact]
        public async Task GetUnansweredNumber_ShouldPass_ExpectedNumber()
        {
            int expectedNumber = 10;
            string department = GetRandom.String();
            string period = GetRandom.String();
            int year = GetRandom.Int16(2000, 3000);

            _appealRepositoryMock.Setup(m => m.GetUnansweredNumberForDepartment(department, period, year)).ReturnsAsync(expectedNumber);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetUnansweredNumber(department, period, year);
            var resultNumber = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedNumber, resultNumber);
        }


        [Fact]
        public async Task GetByDistricts_ShouldPass_ExpectedCollectionOfDistricts()
        {
            string period = GetRandom.String();
            int year = GetRandom.Int16(2000, 3000);
            var expectedDistricts = GetRandom.StringCollection(10, 7);

            _appealRepositoryMock.Setup(m => m.GetRedirectedAppealsByDistricts(period, year)).ReturnsAsync(expectedDistricts);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetByDistricts(period, year);
            var resultDistricts = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedDistricts, resultDistricts);
        }


        [Fact]
        public async Task GetByDistrictsForDepartment_ShouldPass_ExpectedCollectionOfDistricts()
        {
            string department = GetRandom.String();
            string period = GetRandom.String();
            int year = GetRandom.Int16(2000, 3000);
            var expectedDistricts = GetRandom.StringCollection(10, 7);

            _appealRepositoryMock.Setup(m => m.GetRedirectedAppelsByDistrictsForDepartment(department, period, year)).ReturnsAsync(expectedDistricts);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetByDistrictsForDepartment(department, period, year);
            var resultDistricts = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedDistricts, resultDistricts);
        }

        [Fact]
        public async Task GetAppealById_ShouldPass_ExpectedAppeal()
        {
            int appealId = GetRandom.Byte();
            var expectedAppeal = GenerateAppealModelDTO();

            _appealRepositoryMock.Setup(m => m.GetRedirectedAppealById(appealId)).ReturnsAsync(expectedAppeal);
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            var actionResult = await _appealController.GetAppeal(appealId);
            var resultAppeal = Assert.IsType<OkObjectResult>(actionResult).Value;

            Assert.Equal(expectedAppeal, resultAppeal);
        }

        [Fact]
        public async Task Post_ShouldCall_AddRedirectedAppeal()
        {
            var appeal = GenerateAppealModelDTO();

            _appealRepositoryMock.Setup(m => m.AddRedirectedAppeal(appeal));
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            await _appealController.Post(appeal);

            _appealRepositoryMock.Verify(m => m.AddRedirectedAppeal(appeal), Times.Once);
        }

        [Fact]
        public async Task Put_ShouldCall_UpdateRedirectedAppeal()
        {
            var appeal = GenerateAppealModelDTO();

            _appealRepositoryMock.Setup(m => m.UpdateRedirectedAppeal(appeal));
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            await _appealController.Put(appeal);

            _appealRepositoryMock.Verify(m => m.UpdateRedirectedAppeal(appeal), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldCall_DeleteRedirectedAppeal()
        {
            var appealId = GetRandom.Byte();

            _appealRepositoryMock.Setup(m => m.DeleteRedirectedAppeal(appealId));
            _appealController = new RedirectedAppealController(_appealRepositoryMock.Object);

            await _appealController.Delete(appealId);

            _appealRepositoryMock.Verify(m => m.DeleteRedirectedAppeal(appealId), Times.Once);
        }

        #endregion


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


        [Fact]
        public void GetTestRedirectedAppealModelDTOsTest() //DELETE
        {
            var result = GetRandom.StringCollection(10,5);
            Assert.Equal(10, result.Count());
        }
    }
}
