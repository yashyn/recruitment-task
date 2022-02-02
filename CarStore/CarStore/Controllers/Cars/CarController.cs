using Cars.Domain.Models;
using CarStore.Api.Dtos.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers.Cars
{
    /// <summary>
    /// TODO add docs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        /// <summary>
        /// TODO add docs
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCarRequestDto dto, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Car car, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}
