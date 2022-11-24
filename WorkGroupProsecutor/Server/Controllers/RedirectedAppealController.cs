using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;
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

        [HttpGet("getByDistricts/{period}/{year}")]
        public async Task<IActionResult> GetByDistricts(string period, int year)
        {
            return Ok(await _appealRepository.GetRedirectedByDistricts(period, year));
        }

        // GET api/<RedirectedAppealController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _appealRepository.GetRedirectedAppealById(id));
        }

        // POST api/<RedirectedAppealController>
        [HttpPost]
        public async Task<IActionResult> Post(RedirectedAppealModelDTO appealDto)
        {
            await _appealRepository.AddRedirectedAppeal(appealDto);
            return Ok("Обращение добавлено");
        }

        // PUT api/<RedirectedAppealController>/5
        [HttpPut]   //("{id}")]
        public async Task<IActionResult> Put(RedirectedAppealModelDTO appealDto)
        {
            await _appealRepository.UpdateRedirectedAppeal(appealDto);
            return Ok("Обращение обнавлено");
        }

        // DELETE api/<RedirectedAppealController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appealRepository.DeleteRedirectedAppeal(id);
            return Ok("Обращение удалено");
        }
    }
}
