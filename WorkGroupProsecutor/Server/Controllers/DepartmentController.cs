using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Participants;


namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllDepartments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetDepartmentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            await _repository.AddDepartment(department);
            return Ok("Новый отдел успешно добавлен");
        }
    }
}
