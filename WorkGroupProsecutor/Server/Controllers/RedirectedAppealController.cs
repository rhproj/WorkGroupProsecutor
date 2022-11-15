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
        private readonly IRedirectedAppealRepository _repository;

        public RedirectedAppealController(IRedirectedAppealRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<RedirectedAppealController>
        //[HttpGet()]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _repository.GetAllRedirectedAppeals("Mamadysh", "17.10", 2022)); //"Mamadysh", "17.10", 2022));
        //}


        [HttpGet("{district}/{period}/{year}")]
        public async Task<IActionResult> Get(string district, string period, int year)
        {
            return Ok(await _repository.GetAllRedirectedAppeals(district, period, year));
        }

        [HttpGet("{district}/{year}")]
        public async Task<IActionResult> Get(string district, int year)
        {
            return Ok(await _repository.GetRedirectedAppealPeriods(district, year));
        }

        // GET api/<RedirectedAppealController>/5
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<RedirectedAppealController>
        [HttpPost]
        public async Task<IActionResult> Post(RedirectedAppealModel appeal)
        {
            await _repository.AddRedirectedAppeal(appeal);
            return Ok("Обращение добавлено");
        }

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
