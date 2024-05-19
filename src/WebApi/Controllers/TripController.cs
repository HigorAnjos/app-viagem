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

        public TripController(IDeleteTripAsync deleteTripAsync, IGetTripAsync getTripAsync, ISaveTripAsync saveTripAsync)
        {
            _deleteTripAsync = deleteTripAsync;
            _getTripAsync = getTripAsync;
            _saveTripAsync = saveTripAsync;
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
            if (trip == null)
            {
                return BadRequest();
            }
            var result = await _saveTripAsync.SaveTripAsync(trip);
            return CreatedAtAction(nameof(GetTripByIdAsync), new { id = result.Id }, result);
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
    }
}
