using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictRegisterController : ControllerBase
    {
        private readonly IDistrictRegisterRepository _registryRepository;
        public DistrictRegisterController(IDistrictRegisterRepository registryRepository)
        {
            _registryRepository = registryRepository;
        }
        // GET: api/<DistrictRegisterController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _registryRepository.GetAllDistrictRegistry());
        }

        // GET api/<DistrictRegisterController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var register = await _registryRepository.GetDistrictRegisterById(id);
            if (register == null)
            {
                return NotFound();
            }
            return Ok(register);
        }

        // POST api/<DistrictRegisterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DistrictRegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DistrictRegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
