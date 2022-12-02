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
        //private readonly IDepartmentRepository _departmentRepository; //OoO

        public RedirectedAppealController(IRedirectedAppealRepository appealRepository) //, IDepartmentRepository departmentRepository)
        {
            _appealRepository = appealRepository;
            //_departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Возвращает все отчетные периоды
        /// </summary>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getPeriods/{year}")]
        public async Task<IActionResult> GetPeriods(int year)
        {
            return Ok(await _appealRepository.GetAllRedirectedPeriods(year));
        }

        /// <summary>
        /// Возвращает все отчетные периоды, заполненные заданным районом
        /// </summary>
        /// <param name="district">Район (УЗ пользователя)</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("{district}/{year}")]
        public async Task<IActionResult> Get(string district, int year)
        {
            return Ok(await _appealRepository.GetRedirectedPeriodsByDistrict(district, year));
        }

        /// <summary>
        /// Возвращает все обращения района за отч.период, предполагаемые к переадресации в иные органы
        /// </summary>
        /// <param name="district">Район</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("{district}/{period}/{year}")]
        public async Task<IActionResult> Get(string district, string period, int year)
        {
            return Ok(await _appealRepository.GetAllRedirectedAppeals(district, period, year));
        }

        #region for Dep-ts and w/o auth-n
        /// <summary>
        /// Cписок районнов имеющих обращения в указанный период
        /// </summary>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        /// <returns></returns>
        [HttpGet("getByDistricts/{period}/{year}")]
        public async Task<IActionResult> GetByDistricts(string period, int year) //OoO
        {
            return Ok(await _appealRepository.GetRedirectedAppelsByDistricts(period, year));
        } 
        #endregion


        /// <summary>
        /// Возвращает обращение по заданному id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _appealRepository.GetRedirectedAppealById(id));
        }

        /// <summary>
        /// Cоздает новое обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPost]
        public async Task<IActionResult> Post(RedirectedAppealModelDTO appealDto)
        {
            await _appealRepository.AddRedirectedAppeal(appealDto);
            return Ok("Обращение добавлено");
        }

        /// <summary>
        /// Обновляет обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPut]   //("{id}")]
        public async Task<IActionResult> Put(RedirectedAppealModelDTO appealDto)
        {
            await _appealRepository.UpdateRedirectedAppeal(appealDto);
            return Ok("Обращение обнавлено");
        }

        /// <summary>
        /// Удаляет обращение по заданному id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appealRepository.DeleteRedirectedAppeal(id);
            return Ok("Обращение удалено");
        }
    }
}
