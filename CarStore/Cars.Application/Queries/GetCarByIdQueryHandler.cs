using Cars.Domain.Models;
using Cars.Domain.Repos;
using CarStore.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cars.Application.Queries
{
    public  class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CommandResultBase<Car>>
    {
        private readonly ICarRepo _repo;
        private readonly ILogger<GetCarByIdQueryHandler> _logger;

        public GetCarByIdQueryHandler(ICarRepo repo,
            ILogger<GetCarByIdQueryHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<CommandResultBase<Car>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var foundCar = await _repo.GetFirstOrDefaultAsync(x => x.Id == request.Id);

            if (foundCar == null)
            {
                _logger.LogWarning($"Car with id {request.Id} not found.");
                return new CommandResultBase<Car>(default, CommandResultType.NotFound);
            }

            return new CommandResultBase<Car>(foundCar);
        }
    }
}
