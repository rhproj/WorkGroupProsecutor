using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;


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
        public async Task<IActionResult> GetAppeals(string district, string period, int year)
        {
            var appeals = await _appealRepository.GetAllSatisfiedAppeals(district, period, year);
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
        [HttpGet("getAllForDepartment/{district}/{department}/{period}/{year}")]
        public async Task<IActionResult> GetAllForDepartment(string district, string department, string period, int year)  //m
        {
            var appeals = await _appealRepository.GetAllSatisfiedAppealsForDepartment(district, department, period, year);
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
            var appeals = await _appealRepository.GetAllSatisfiedUnansweredForDepartment(department, period, year);
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
            var appeals = await _appealRepository.GetSatisfiedAppealsByDistricts(period, year);
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
            var appeals = await _appealRepository.GetSatisfiedAppealsByDistrictsForDepartment(department, period, year);
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
            var appeal = await _appealRepository.GetSatisfiedAppealById(id);
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
        public async Task<IActionResult> PostAppeal(SatisfiedAppealModelDTO appealDto)
        {
            await _appealRepository.AddSatisfiedAppeal(appealDto);
            return Ok("Обращение добавлено");
        }

        /// <summary>
        /// Обновляет обращение
        /// </summary>
        /// <param name="appealDto">Модель обращения</param>
        [HttpPut]   //("{id}")]
        public async Task<IActionResult> PutAppeal(SatisfiedAppealModelDTO appealDto)
        {
            await _appealRepository.UpdateSatisfiedAppeal(appealDto);
            return Ok("Обращение обнавлено");
        }

        /// <summary>
        /// Удаляет обращение по заданному id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppeal(int id)
        {
            await _appealRepository.DeleteSatisfiedAppeal(id);
            return Ok("Обращение удалено");
        }
    }
}
