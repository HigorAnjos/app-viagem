using System.Threading.Tasks;
using Domain.UseCase.Trip;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly IDeleteTripAsync _deleteTripAsync;
        private readonly IGetTripAsync _getTripAsync;
        private readonly ISaveTripAsync _saveTripAsync;
        private readonly IJourneyReportAsync _journeyReportAsync;

        public TripController(IDeleteTripAsync deleteTripAsync, IGetTripAsync getTripAsync, ISaveTripAsync saveTripAsync, IJourneyReportAsync journeyReportAsync)
        {
            _deleteTripAsync = deleteTripAsync;
            _getTripAsync = getTripAsync;
            _saveTripAsync = saveTripAsync;
            _journeyReportAsync = journeyReportAsync;
        }

        // GET api/trip/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripByIdAsync(int id)
        {
            var result = await _getTripAsync.GetTripAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/trip
        [HttpPost]
        public async Task<IActionResult> SaveTripAsync([FromBody] Domain.Entities.Trip trip)
        {
            try
            {

                if (trip == null)
                {
                    return BadRequest();
                }
                var result = await _saveTripAsync.SaveTripAsync(trip);
                return CreatedAtAction(nameof(GetTripByIdAsync), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/trip/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripByIdAsync(int id)
        {
            var success = await _deleteTripAsync.DeleteTripAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET api/trip/report
        [HttpGet("report")]
        public async Task<IActionResult> GetJourneyReportAsync([FromQuery] string brand, [FromQuery] DateTime initDate, [FromQuery] DateTime endDate)
        {
            if (string.IsNullOrEmpty(brand) || initDate == default || endDate == default)
            {
                return BadRequest("Invalid input parameters.");
            }

            var result = await _journeyReportAsync.GetJourneyReportAsync(brand, initDate, endDate);
            return Ok(result);
        }

    }
}
