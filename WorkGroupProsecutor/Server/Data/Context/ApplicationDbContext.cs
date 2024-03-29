﻿using Microsoft.EntityFrameworkCore;
using System.Data;
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
        public DbSet<NoSolutionAppealModel> NoSolutionAppeal { get; set; }
        public DbSet<RedirectedAppealModel> RedirectedAppeal { get; set; }
        public DbSet<SatisfiedAppealModel> SatisfiedAppeal { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}
