using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;

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
    }
}
