using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisfiedAppealController : ControllerBase
    {
        private readonly ISatisfiedAppealRepository _appealRepository;
        public SatisfiedAppealController(ISatisfiedAppealRepository appealRepository)
        {
            _appealRepository = appealRepository;
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
            return Ok(await _appealRepository.GetAllSatisfiedAppeals(district, period, year));
        }

        /// <summary>
        /// Возвращает все обращения района за отч.период, для определенного отдела предполагаемые к переадресации в иные органы
        /// </summary>
        /// <param name="district">Район</param>
        /// <param name="district">Отдел</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getAllForDepartment/{district}/{department}/{period}/{year}")]
        public async Task<IActionResult> GetAllForDepartment(string district, string department, string period, int year)  //m
        {
            return Ok(await _appealRepository.GetAllSatisfiedAppealsForDepartment(district, department, period, year));
        }

        #region for Dep-ts and w/o auth-n
        /// <summary>
        /// Cписок районнов имеющих обращения в указанный период
        /// </summary>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        /// <returns></returns>
        [HttpGet("getByDistricts/{period}/{year}")]
        public async Task<IActionResult> GetByDistricts(string period, int year)
        {
            return Ok(await _appealRepository.GetSatisfiedAppealsByDistricts(period, year));
        }

        /// <summary>
        /// Cписок районнов имеющих обращения в указанный период отфильтрованных для данного отдела
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        /// <returns></returns>
        [HttpGet("getByDistrictsForDepartment/{department}/{period}/{year}")]
        public async Task<IActionResult> GetByDistrictsForDepartment(string department, string period, int year) //n
        {
            return Ok(await _appealRepository.GetSatisfiedAppealsByDistrictsForDepartment(department, period, year));
        }
        #endregion

        /// <summary>
        /// Возвращает обращение по заданному id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _appealRepository.GetSatisfiedAppealById(id));
        }

        /// <summary>
        /// Cоздает новое обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPost]
        public async Task<IActionResult> Post(SatisfiedAppealModelDTO appealDto)
        {
            await _appealRepository.AddSatisfiedAppeal(appealDto);
            return Ok("Обращение добавлено");
        }

        /// <summary>
        /// Обновляет обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPut]   //("{id}")]
        public async Task<IActionResult> Put(SatisfiedAppealModelDTO appealDto)
        {
            await _appealRepository.UpdateSatisfiedAppeal(appealDto);
            return Ok("Обращение обнавлено");
        }

        /// <summary>
        /// Удаляет обращение по заданному id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appealRepository.DeleteSatisfiedAppeal(id);
            return Ok("Обращение удалено");
        }
    }
}
