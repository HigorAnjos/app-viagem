using Domain.UseCase.Driver;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IGetDriverByIdAsync _getDriverByIdAsync;
        private readonly ISaveDriverAsync _saveDriverByIdAsync;
        private readonly IDeleteDriverByIdAsync _deleteDriverByIdAsync;

        public DriverController(IGetDriverByIdAsync getDriverByIdAsync, ISaveDriverAsync saveDriverByIdAsync, IDeleteDriverByIdAsync deleteDriverByIdAsync)
        {
            _getDriverByIdAsync = getDriverByIdAsync;
            _saveDriverByIdAsync = saveDriverByIdAsync;
            _deleteDriverByIdAsync = deleteDriverByIdAsync;
        }

        // GET api/driver/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverByIdAsync(int id)
        {
            var result = await _getDriverByIdAsync.GetDriverByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/driver
        [HttpPost]
        public async Task<IActionResult> SaveDriverAsync([FromBody] Domain.Entities.Driver driver)
        {
            if (driver == null)
            {
                return BadRequest();
            }

            var result = await _saveDriverByIdAsync.SaveDriverAsync(driver);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the driver.");
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        // DELETE api/driver/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverByIdAsync(int id)
        {
            var success = await _deleteDriverByIdAsync.DeleteDriverByIdAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
