using Cars.Domain.Models;
using CarStore.Core;
using MediatR;

namespace Cars.Application.Commands
{
    public class CreateCarCommand : IRequest<CommandResultBase<Guid>>
    {
        public CreateCarCommand(Car car)
        {
            Car = car;
        }

        public Car Car { get; }
    }
}
