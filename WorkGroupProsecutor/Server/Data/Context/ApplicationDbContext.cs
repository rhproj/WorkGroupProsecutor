using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Shared.Models;
using WorkGroupProsecutor.Shared.Models.Recipients;

namespace WorkGroupProsecutor.Server.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DistrictRegisterModel> DistrictRegister { get; set; }
        public DbSet<NoSolutionAppealModel> NoSolutionAppeal { get; set; }
        public DbSet<RedirectedAppealModel> RedirectedAppeal { get; set; }
        public DbSet<SatisfiedAppealModel> SatisfiedAppeal { get; set; }
        public DbSet<Department> Department { get; set; }       
        
        //public DbSet<RecipientAgency> RecipientAgency { get; set; }
    }
}
