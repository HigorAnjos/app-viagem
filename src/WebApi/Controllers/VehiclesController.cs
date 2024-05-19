using Domain.UseCase.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IGetVehiclesAsync _getVehiclesAsync;
        private readonly IDeleteVehiclesAsync _deleteVehiclesAsync;
        private readonly ISaveVehiclesAsync _saveVehiclesAsync;

        public VehiclesController(IGetVehiclesAsync getVehiclesAsync, IDeleteVehiclesAsync deleteVehiclesAsync, ISaveVehiclesAsync saveVehiclesAsync)
        {
            _getVehiclesAsync = getVehiclesAsync;
            _deleteVehiclesAsync = deleteVehiclesAsync;
            _saveVehiclesAsync = saveVehiclesAsync;
        }

        // GET api/vehicles/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleByIdAsync(int id)
        {
            var result = await _getVehiclesAsync.GetVehiclesAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/vehicles
        [HttpPost]
        public async Task<IActionResult> SaveVehicleAsync([FromBody] Domain.Entities.Vehicles vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }
            var result = await _saveVehiclesAsync.SaveVehiclesAsync(vehicle);
            return CreatedAtAction(nameof(GetVehicleByIdAsync), new { id = result.Id }, result);
        }

        // DELETE api/vehicles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleByIdAsync(int id)
        {
            var success = await _deleteVehiclesAsync.DeleteVehiclesAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
