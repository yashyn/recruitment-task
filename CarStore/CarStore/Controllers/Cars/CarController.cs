using Cars.Application.Commands;
using Cars.Application.Queries;
using CarStore.Api.Dtos.Cars;
using CarStore.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Controllers.Cars
{
    /// <summary>
    /// TODO add docs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets car by id.
        /// </summary>
        /// <param name="id">Id of the car to be found.</param>
        /// <param name="cancellationToken">Token used for the request cancellation.</param>
        /// <returns>Found car.</returns>
        [HttpGet("{id}/{format?}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetCarByIdQuery(id);
            var result = await _mediator.Send(command, cancellationToken);

            return result.Type switch
            {
                CommandResultType.Success => Ok(),
                CommandResultType.NotFound => NotFound(),
                _ => StatusCode(StatusCodes.Status500InternalServerError),
            };
        }

        /// <summary>
        /// Create new car.
        /// </summary>
        /// <param name="dto">Model describing properties of the car to be created.</param>
        /// <param name="cancellationToken">Token used for the request cancellation.</param>
        /// <returns>Id of the created Car in Guid format.</returns>
        [HttpPost("{format?}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        //todo add swagger examples
        public async Task<IActionResult> CreateAsync([FromBody] CreateCarRequestDto dto, CancellationToken cancellationToken)
        {
            var command = new CreateCarCommand(dto.Vin, dto.Type);
            var result = await _mediator.Send(command, cancellationToken);

            return result.Type switch
            {
                CommandResultType.Success => Ok(result.Data),
                CommandResultType.AlreadyExists => Conflict(dto.Vin),
                _ => StatusCode(StatusCodes.Status500InternalServerError),
            };
        }

        /// <summary>
        /// Update existing car.
        /// </summary>
        /// <param name="dto">Model describing the car to be updated.</param>
        /// <param name="cancellationToken">Token used for the request cancellation.</param>
        [HttpPut("{format?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCarRequestDto dto, CancellationToken cancellationToken)
        {
            var command = new UpdateCarCommand(dto.Id, dto.Vin, dto.Type);
            var result = await _mediator.Send(command, cancellationToken);

            return result.Type switch
            {
                CommandResultType.Success => Ok(),
                CommandResultType.NotFound => NotFound(),
                CommandResultType.AlreadyExists => Conflict(dto.Vin),
                _ => StatusCode(StatusCodes.Status500InternalServerError),
            };
        }

        /// <summary>
        /// Deletes car by Id.
        /// </summary>
        /// <param name="id">Id of the car to be deleted.</param>
        /// <param name="cancellationToken">Token used for the request cancellation.</param>
        [HttpDelete("{id}/{format?}")]
        public async Task<IActionResult> DeleteAsync([FromRoute, Required] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCarCommand(id);
            var result = await _mediator.Send(command, cancellationToken);

            return result.Type switch
            {
                CommandResultType.Success => Ok(),
                CommandResultType.NotFound => NotFound(),
                _ => StatusCode(StatusCodes.Status500InternalServerError),
            };
        }
    }
}
