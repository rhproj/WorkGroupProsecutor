using Microsoft.EntityFrameworkCore;
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
    }
}
