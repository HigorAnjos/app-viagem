using System.Threading.Tasks;
using Domain.UseCase.Owner;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IGetOwnerAsync _getOwnerAsync;
        private readonly ISaveOwnerAsync _saveOwnerAsync;
        private readonly IDeleteOwnerAsync _deleteOwnerAsync;

        public OwnerController(IGetOwnerAsync getOwnerAsync, ISaveOwnerAsync saveOwnerAsync, IDeleteOwnerAsync deleteOwnerAsync)
        {
            _getOwnerAsync = getOwnerAsync;
            _saveOwnerAsync = saveOwnerAsync;
            _deleteOwnerAsync = deleteOwnerAsync;
        }

        // GET api/owner/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerByIdAsync(int id)
        {
            var result = await _getOwnerAsync.GetOwnerAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/owner
        [HttpPost]
        public async Task<IActionResult> SaveOwnerAsync([FromBody] Domain.Entities.Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }
            var result = await _saveOwnerAsync.SaveOwnerAsync(owner);
            return CreatedAtAction(nameof(GetOwnerByIdAsync), new { id = result.Id }, result);
        }

        // DELETE api/owner/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerByIdAsync(int id)
        {
            var success = await _deleteOwnerAsync.DeleteOwnerAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
