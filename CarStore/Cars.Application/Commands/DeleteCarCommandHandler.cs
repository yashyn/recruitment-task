using Cars.Domain.Repos;
using CarStore.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cars.Application.Commands
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, CommandResultBase>
    {
        private readonly ICarRepo _repo;
        private readonly ILogger<DeleteCarCommandHandler> _logger;

        public DeleteCarCommandHandler(ICarRepo repo,
            ILogger<DeleteCarCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<CommandResultBase> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var toBeDeletedCar = await _repo.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (toBeDeletedCar == null)
            {
                _logger.LogWarning($"Car with id {request.Id} not found.");
                return new CommandResultBase(CommandResultType.NotFound);
            }

            await _repo.DeleteAsync(request.Id, cancellationToken);
            return new CommandResultBase();
        }
    }
}
