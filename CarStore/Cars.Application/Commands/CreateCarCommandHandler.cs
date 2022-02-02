using Cars.Domain.Models;
using Cars.Domain.Repos;
using CarStore.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cars.Application.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CommandResultBase<Guid>>
    {
        private readonly ICarRepo _repo;
        private readonly ILogger<CreateCarCommandHandler> _logger;

        public CreateCarCommandHandler(ICarRepo repo,
            ILogger<CreateCarCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<CommandResultBase<Guid>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var getByVin = await _repo.GetFirstOrDefaultAsync(car => car.Vin == request.Vin, cancellationToken);

            if (getByVin != null)
            {
                _logger.LogWarning("Trying to save car with existing vin.");
                return new CommandResultBase<Guid>(default, CommandResultType.AlreadyExists);
            }

            var car = new Car
            {
                Type = request.Type,
                Vin = request.Vin,
            };

            var createdCarId = await _repo.CreateAsync(car);

            _logger.LogInformation("Car created successfully.");
            return new CommandResultBase<Guid>(createdCarId);
        }
    }
}
