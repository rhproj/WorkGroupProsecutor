using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;


namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoSolutionAppealController : ControllerBase
    {
        private readonly INoSolutionAppealRepository _appealRepository;
        public NoSolutionAppealController(INoSolutionAppealRepository appealRepository)
        {
            _appealRepository = appealRepository;
        }

        /// <summary>
        /// Возвращает все обращения района за отч.период
        /// </summary>
        /// <param name="district">Район</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("{district}/{period}/{year}")]
        public async Task<IActionResult> GetAppeals(string district, string period, int year)
        {
            var appeals = await _appealRepository.GetAllNoSolutionAppeals(district, period, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }

        #region for Dep-ts and w/o auth-n
        /// <summary>
        /// Возвращает все обращения района за отч.период, для определенного отдела
        /// </summary>
        /// <param name="district">Район</param>
        /// <param name="department">Отдел</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getAllForDepartment/{district}/{department}/{period}/{year}")]
        public async Task<IActionResult> GetAllForDepartment(string district, string department, string period, int year)
        {
            var appeals = await _appealRepository.GetAllNoSolutionAppealsForDepartment(district, department, period, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }

        /// <summary>
        /// Возвращает все нерассмотренные обращения района за отч.период, для определенного отдела
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getAllUnansweredForDepartment/{department}/{period}/{year}")]
        public async Task<IActionResult> GetAllUnansweredForDepartment(string department, string period, int year)
        {
            var appeals = await _appealRepository.GetAllNoSolutionUnansweredForDepartment(department, period, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }

        [HttpGet("getUnansweredNumberForDepartment/{department}/{period}/{year}")]
        public async Task<IActionResult> GetUnansweredNumber(string department, string period, int year)
        {
            return Ok(await _appealRepository.GetUnansweredNumberForDepartment(department, period, year));
        }

        /// <summary>
        /// Cписок районнов имеющих обращения в указанный период
        /// </summary>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        /// <returns></returns>
        [HttpGet("getByDistricts/{period}/{year}")]
        public async Task<IActionResult> GetByDistricts(string period, int year)
        {
            var appeals = await _appealRepository.GetNoSolutiondAppealsByDistricts(period, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
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
            var appeals = await _appealRepository.GetNoSolutionAppealsByDistrictsForDepartment(department, period, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }
        #endregion

        /// <summary>
        /// Возвращает обращение по заданному id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppeal(int id)
        {
            var appeal = await _appealRepository.GetNoSolutionAppealById(id);
            if (appeal == null)
            {
                return NotFound();
            }
            return Ok(appeal);
        }

        /// <summary>
        /// Cоздает новое обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPost]
        public async Task<IActionResult> Post(NoSolutionAppealModelDTO appealDto)
        {
            await _appealRepository.AddNoSolutionAppeal(appealDto);
            return Ok("Обращение добавлено");
        }

        /// <summary>
        /// Обновляет обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPut]   //("{id}")]
        public async Task<IActionResult> Put(NoSolutionAppealModelDTO appealDto)
        {
            await _appealRepository.UpdateNoSolutionAppeal(appealDto);
            return Ok("Обращение обнавлено");
        }

        /// <summary>
        /// Удаляет обращение по заданному id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appealRepository.DeleteNoSolutionAppeal(id);
            return Ok("Обращение удалено");
        }
    }
}
