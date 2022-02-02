using CarStore.Core;
using MediatR;

namespace Cars.Application.Commands
{
    public class DeleteCarCommand : IRequest<CommandResultBase>
    {
        public DeleteCarCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
