using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoSolutionReturnsAppealController : ControllerBase
    {
        private readonly INoSolutionReturnsAppealRepository _appealRepository;

        public NoSolutionReturnsAppealController(INoSolutionReturnsAppealRepository appealRepository)
        {
            _appealRepository = appealRepository;
        }

        #region PERIODS
        /// <summary>
        /// Возвращает все отчетные периоды
        /// </summary>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getPeriods/{year}")]
        public async Task<IActionResult> GetPeriods(int year)
        {
            var periods = await _appealRepository.GetAllNoSolutionReturnsPeriods(year);
            if (periods == null)
            {
                return NotFound();
            }
            return Ok(periods);
        }

        /// <summary>
        /// Возвращает все отчетные периоды, заполненные заданным районом
        /// </summary>
        /// <param name="district">Район (УЗ пользователя)</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("{district}/{year}")]
        public async Task<IActionResult> GetPeriodsByDistrict(string district, int year)
        {
            var appeals = await _appealRepository.GetNoSolutionReturnsPeriodsByDistrict(district, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }

        /// <summary>
        /// Возвращает все отчетные периоды, для заданного отдела
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getForDepartment/{department}/{year}")]
        public async Task<IActionResult> GetForDepartment(string department, int year)
        {
            var appeals = await _appealRepository.GetNoSolutionReturnsPeriodsForDepartment(department, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }
        #endregion

        /// <summary>
        /// Возвращает все обращения района за отч.период, предполагаемые к переадресации в иные органы
        /// </summary>
        /// <param name="district">Район</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("{district}/{period}/{year}")]
        public async Task<IActionResult> GetAppeals(string district, string period, int year)
        {
            var appeals = await _appealRepository.GetAllNoSolutionReturnsAppeals(district, period, year);
            if (appeals == null)
            {
                return NotFound();
            }
            return Ok(appeals);
        }


        #region for Dep-ts and w/o auth-n
        /// <summary>
        /// Возвращает все обращения района за отч.период, для определенного отдела предполагаемые к переадресации в иные органы
        /// </summary>
        /// <param name="district">Район</param>
        /// <param name="district">Отдел</param>
        /// <param name="period">Отчетный период</param>
        /// <param name="year">Отчетный год</param>
        [HttpGet("getAllByDepartment/{district}/{department}/{period}/{year}")]
        public async Task<IActionResult> GetAppealsByDepartment(string district, string department, string period, int year)
        {
            var appeals = await _appealRepository.GetAllNoSolutionReturnsAppealsByDepartment(district, department, period, year);
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
            var appeals = await _appealRepository.GetAllNoSolutionReturnsUnansweredForDepartment(department, period, year);
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
            var appeals = await _appealRepository.GetNoSolutionReturnsAppealsByDistricts(period, year);
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
        public async Task<IActionResult> GetByDistrictsForDepartment(string department, string period, int year)
        {
            var appeals = await _appealRepository.GetNoSolutionReturnsAppelsByDistrictsForDepartment(department, period, year);
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
            var appeal = await _appealRepository.GetNoSolutionReturnsAppealById(id);
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
        public async Task<IActionResult> Post(NoSolutionReturnsAppealModelDTO appealDto)
        {
            await _appealRepository.AddNoSolutionReturnsAppeal(appealDto);
            return Ok("Обращение добавлено");
        }

        /// <summary>
        /// Обновляет обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPut]   //("{id}")]
        public async Task<IActionResult> Put(NoSolutionReturnsAppealModelDTO appealDto)
        {
            await _appealRepository.UpdateNoSolutionReturnsAppeal(appealDto);
            return Ok("Обращение обнавлено");
        }

        /// <summary>
        /// Удаляет обращение по заданному id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appealRepository.DeleteNoSolutionReturnsAppeal(id);
            return Ok("Обращение удалено");
        }
    }
}
