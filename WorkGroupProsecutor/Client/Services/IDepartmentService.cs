using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Client.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task AddDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
    }
}
