using Microsoft.AspNetCore.Mvc;
using WorkGroupProsecutor.Server.Data.Repositories;

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
    }
}
