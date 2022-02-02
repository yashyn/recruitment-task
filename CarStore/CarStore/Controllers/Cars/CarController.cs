using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}
