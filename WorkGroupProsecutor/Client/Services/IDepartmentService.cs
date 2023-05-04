using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Client.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}
