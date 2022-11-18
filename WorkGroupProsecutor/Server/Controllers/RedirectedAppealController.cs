using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectedAppealController : ControllerBase
    {
        private readonly IRedirectedAppealRepository _appealRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public RedirectedAppealController(IRedirectedAppealRepository appealRepository, IDepartmentRepository departmentRepository)
        {
            _appealRepository = appealRepository;
            _departmentRepository = departmentRepository;
        }

        // GET: api/<RedirectedAppealController>
        //[HttpGet()]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _appealRepository.GetAllRedirectedAppeals("Mamadysh", "17.10", 2022)); //"Mamadysh", "17.10", 2022));
        //}


        [HttpGet("{district}/{period}/{year}")]
        public async Task<IActionResult> Get(string district, string period, int year)
        {
            return Ok(await _appealRepository.GetAllRedirectedAppeals(district, period, year));
        }

        [HttpGet("{district}/{year}")]
        public async Task<IActionResult> Get(string district, int year)
        {
            return Ok(await _appealRepository.GetRedirectedAppealPeriods(district, year));
        }

        // GET api/<RedirectedAppealController>/5
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<RedirectedAppealController>
        [HttpPost]
        public async Task<IActionResult> Post(RedirectedAppealModel redirectedAppealModel)
        {
            await _appealRepository.AddRedirectedAppeal(redirectedAppealModel);
            return Ok("Обращение добавлено");
        }

        [HttpPost]
        [Route("PostWithDep")]
        public async Task<IActionResult> PostWithDep(int depId, RedirectedAppealModel redirectedAppealModel) //, Department department)
        {
            if (redirectedAppealModel == null)
                return BadRequest();

            //if (redirectedAppealModel.RegistrationNumber == string.Empty || redirectedAppealModel.ApplicantFullName == string.Empty)
            //    ModelState.AddModelError("RegistrationNumber", "ApplicantFullName shouldn't be empty");
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);
            redirectedAppealModel.AppealClassification = await _departmentRepository.GetDepartmentById(depId);

            await _appealRepository.AddRedirectedAppeal(redirectedAppealModel); //, department);
            return Ok("Обращение добавлено");
        }

        // POST api/<RedirectedAppealController>
        //[HttpPost]
        //public async Task<IActionResult> Post(Department department)
        //{
        //    await _appealRepository.AddDepartment(department);
        //    return Ok("Department добавлен");
        //}

        // PUT api/<RedirectedAppealController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RedirectedAppealController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
