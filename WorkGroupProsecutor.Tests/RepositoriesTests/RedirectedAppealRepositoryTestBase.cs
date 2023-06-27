using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Server.Mapper;
using WorkGroupProsecutor.Tests.Services;

namespace WorkGroupProsecutor.Tests.RepositoriesTests
{
    public class RedirectedAppealRepositoryTestBase : IDisposable
    {
        protected RedirectedAppealRepository _sutRedirectedAppealRepository;
        protected readonly ApplicationDbContext _dbContext;

        public RedirectedAppealRepositoryTestBase()
        {
            var mapperСonfig = new MapperConfiguration(с => с.AddProfile(new MappingProfile()));
            var mapper = mapperСonfig.CreateMapper();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: GetRandom.String()).Options;

            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();

            if (!_dbContext.RedirectedAppeal.Any())
            {
                SeedTestData(_dbContext);
            }

            _sutRedirectedAppealRepository = new RedirectedAppealRepository(_dbContext, mapper);
        }

        private void SeedTestData(ApplicationDbContext dbContext)
        {
            var testAppeals = RedirectedAppealTestProvider.RedirectedAppealModelTestCollection();
            dbContext.RedirectedAppeal.AddRange(testAppeals);
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}