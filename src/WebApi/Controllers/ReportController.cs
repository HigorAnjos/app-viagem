using Domain.UseCase.Trip;
using Domain.UseCase.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IGetTop20RevenuesAsync _getTop20RevenuesAsync;
        private readonly IGetMonthlyAverageTripsByGenderAsync _getMonthlyAverageTripsByGenderAsync;

        public ReportController(IGetTop20RevenuesAsync getTop20RevenuesAsync, IGetMonthlyAverageTripsByGenderAsync getMonthlyAverageTripsByGenderAsync)
        {
            _getTop20RevenuesAsync = getTop20RevenuesAsync;
            _getMonthlyAverageTripsByGenderAsync = getMonthlyAverageTripsByGenderAsync;
        }

        // GET api/trip/top-revenues?month=2024-05
        [HttpGet("top-revenues")]
        [ProducesResponseType(typeof(IEnumerable<RevenuesDto>), 200)]
        public async Task<IActionResult> GetTop20RevenuesAsync([FromQuery] DateTime month)
        {
            var result = await _getTop20RevenuesAsync.GetTopRevenuesAsync(month);
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result.ToList());
        }

        // GET api/report/monthly-average-trips-by-gender?year=2024
        [HttpGet("monthly-average-trips-by-gender")]
        [ProducesResponseType(typeof(IEnumerable<MonthlyAverageTripsByGenderDto>), 200)]
        public async Task<IActionResult> GetMonthlyAverageTripsByGenderAsync()
        {
            var result = await _getMonthlyAverageTripsByGenderAsync.GetMonthlyAverageTrips();
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result.ToList());
        }
    }
}
