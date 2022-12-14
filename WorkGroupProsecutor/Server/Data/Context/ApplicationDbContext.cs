using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Authentication;
using WorkGroupProsecutor.Shared.Authentication;
using WorkGroupProsecutor.Shared.Models;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<DistrictRegisterModel> DistrictRegister { get; set; }
        public DbSet<NoSolutionAppealModel> NoSolutionAppeal { get; set; }
        public DbSet<RedirectedAppealModel> RedirectedAppeal { get; set; }
        public DbSet<SatisfiedAppealModel> SatisfiedAppeal { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; } //auth

        //public DbSet<RecipientAgency> RecipientAgency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    Id = 1,
                    UserName = "azn",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Азнакаевский район"
                },
                new UserAccount
                {
                    Id = 2,
                    UserName = "5",
                    Password = "5",
                    Role = "Department",
                    UserDescription = "Надзор за исполнением федерального заканодательства"
                });

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    DepartmentIndex = "7",
                    DepartmentName = "7 Надзор за исполнением федерального заканодательства"
                });
        }
    }
}
