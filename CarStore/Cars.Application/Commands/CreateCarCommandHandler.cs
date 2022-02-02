using Cars.Domain.Models;
using Cars.Domain.Repos;
using CarStore.Core;
using MediatR;

namespace Cars.Application.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CommandResultBase<Guid>>
    {
        private readonly ICarRepo _repo;

        public CreateCarCommandHandler(ICarRepo repo)
        {
            _repo = repo;
        }

        public async Task<CommandResultBase<Guid>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var getByVin = await _repo.GetFirstOrDefaultAsync(car => car.Vin == request.Vin, cancellationToken);

            if (getByVin != null)
            {
                return new CommandResultBase<Guid>(default, CommandResultType.AlreadyExists);
            }

            var car = new Car
            {
                Type = request.Type,
                Vin = request.Vin,
            };

            var createdCarId = await _repo.CreateAsync(car);

            return new CommandResultBase<Guid>(createdCarId);
        }
    }
}
