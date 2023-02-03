﻿using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Context;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _dbContext.Department.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _dbContext.Department.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddDepartment(Department department)
        {
            await _dbContext.Department.AddAsync(department);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

    }
}
