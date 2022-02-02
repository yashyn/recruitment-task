using Cars.Domain.Repos;
using CarStore.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cars.Application.Commands
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CommandResultBase>
    {
        private readonly ICarRepo _repo;
        private readonly ILogger<CreateCarCommandHandler> _logger;

        public UpdateCarCommandHandler(ICarRepo repo,
            ILogger<CreateCarCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<CommandResultBase> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var findExisting = await _repo.GetFirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);

            if (findExisting == null)
            {
                _logger.LogWarning($"Car with id {request.Id} not found.");
                return new CommandResultBase<Guid>(default, CommandResultType.NotFound);
            }

            var findByVin = await _repo.GetWhereAsync(car => car.Vin == request.Vin, cancellationToken);

            if (findByVin.Any(car => car.Id != request.Id))
            {
                _logger.LogWarning("Trying to save car with existing vin.");
                return new CommandResultBase<Guid>(default, CommandResultType.AlreadyExists);
            }

            findExisting.Vin = request.Vin;
            findExisting.Type = request.Type;

            await _repo.UpdateAsync(findExisting, cancellationToken);

            return new CommandResultBase();
        }
    }
}
