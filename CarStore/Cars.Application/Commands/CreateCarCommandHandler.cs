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
            throw new NotImplementedException();
        }
    }
}
