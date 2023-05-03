using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task AddDepartment(Department department);
    }
}
