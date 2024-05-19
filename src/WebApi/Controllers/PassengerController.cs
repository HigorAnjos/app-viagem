using System.Threading.Tasks;
using Domain.UseCase.Passenger;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly IDeletePassengerAsync _deletePassengerAsync;
        private readonly IGetPassengerAsync _getPassengerAsync;
        private readonly ISavePassengerAsync _savePassengerAsync;

        public PassengerController(IDeletePassengerAsync deletePassengerAsync, IGetPassengerAsync getPassengerAsync, ISavePassengerAsync savePassengerAsync)
        {
            _deletePassengerAsync = deletePassengerAsync;
            _getPassengerAsync = getPassengerAsync;
            _savePassengerAsync = savePassengerAsync;
        }

        // GET api/passenger/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassengerByIdAsync(int id)
        {
            var result = await _getPassengerAsync.GetPassengerAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/passenger
        [HttpPost]
        public async Task<IActionResult> SavePassengerAsync([FromBody] Domain.Entities.Passenger passenger)
        {
            if (passenger == null)
            {
                return BadRequest();
            }
            var result = await _savePassengerAsync.SavePassengerAsync(passenger);
            return CreatedAtAction(nameof(GetPassengerByIdAsync), new { id = result.Id }, result);
        }

        // DELETE api/passenger/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassengerByIdAsync(int id)
        {
            var success = await _deletePassengerAsync.DeletePassengerAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
