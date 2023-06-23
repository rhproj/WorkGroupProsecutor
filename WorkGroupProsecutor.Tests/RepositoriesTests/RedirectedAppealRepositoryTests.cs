using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Server.Controllers;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.RepositoriesTests
{
    public class RedirectedAppealRepositoryTests : IDisposable
    {
        private RedirectedAppealRepository _sutRedirectedAppealRepository;
        private readonly ApplicationDbContext _dbContext;
        private Mock<IMapper> _mapperMock;
        public RedirectedAppealRepositoryTests()
        {
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: GetRandom.String()).Options;   // GetRandom.String()

            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();

            //if (dbContext.RedirectedAppeal.Count() < 0)
            //{
            //    dbContext.RedirectedAppeal.AddRange(expectedAppeals);
            //}
            //Seed(dbContext);
        }

        [Fact]
        public async Task GetAllRedirectedPeriods_ShouldReturnExpectedPeriods()
        {
            var expectedAppeals = GetTestRedirectedAppealModel(10);  //GetTestRedirectedAppealModel(10);
            //var expectedAppealDTOs = GetRandomAppeal.GetTestRedirectedAppealModelDTOs(10);

            //_mapperMock.Setup(x => x.Map<IEnumerable<RedirectedAppealModelDTO>>(expectedAppeals)).Returns(expectedAppealDTOs);
            _dbContext.RedirectedAppeal.AddRange(expectedAppeals);
            var r = _dbContext.SaveChanges(); //r just

            _sutRedirectedAppealRepository = new RedirectedAppealRepository(_dbContext, _mapperMock.Object);

            var result = await _sutRedirectedAppealRepository.GetAllRedirectedPeriods(2030);

            Assert.Equal(10, result.Count());
        }

        private IEnumerable<RedirectedAppealModel> RedirectedAppealModelTestCollection()
        {
            var resultList = new RedirectedAppealModel[]
            {
                GenerateAppealModel(2020, "period1", "district1", 1, null),
                GenerateAppealModel(2020, "period1", "district1", 1, "a"),

                GenerateAppealModel(2020, "period2", "district2", 2, null),
                GenerateAppealModel(2030, "period1", "district3", 1, "a"),

                GenerateAppealModel(2030, "period1", "district1", 2, null),
                GenerateAppealModel(2030, "period2", "district2", 1, null),
                
                GenerateAppealModel(2030, "period1", "district2", 2, "a"),
                GenerateAppealModel(2030, "period2", "district3", 3, null)
            };
            return resultList;
        }

        public RedirectedAppealModel GenerateAppealModel(int year, string period, string district, int departmentId, string? assessment)
        {
            return new RedirectedAppealModel()
            {
                Id = GetRandom.Id(),
                RegistrationNumber = GetRandom.String(),
                NadzorHyperlink = GetRandom.String(),
                ApplicantFullName = GetRandom.String(),
                DepartmentId = departmentId,
                DepartmentAssessment = assessment,
                YearInfo = year,
                PeriodInfo = period,
                District = district,
                RecipientAgency = GetRandom.String(),
                DecisionBasis = GetRandom.String()
            };
        }

        [Fact]
        public async Task GetAllRedirectedAppeals_ShouldReturn_ExpectedAppeals()
        {
            string district = GetRandom.String();
            string period = GetRandom.String();
            int year = GetRandom.Year();


            _sutRedirectedAppealRepository = new RedirectedAppealRepository(_dbContext, _mapperMock.Object);

            var result = await _sutRedirectedAppealRepository.GetAllRedirectedAppeals(district, period, year);

            Assert.Equal(10, result.Count());
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }


        //private void Seed(ApplicationDbContext dbContext)
        //{
        //    var expectedAppeals = GetRandomAppeal.GetTestRedirectedAppealModel(10);
        //    dbContext.RedirectedAppeal.AddRange(expectedAppeals);
        //    dbContext.SaveChanges();
        //}

        //public RedirectedAppealRepositoryTests()
        //{
        //    _sutRedirectedAppealRepository = new();
        //}
        //[Fact]
        //public async Task GetAllRedirectedPeriods_Should()
        //{
        //    //1
        //    var connection = new SqliteConnection
        //}

    }
}
