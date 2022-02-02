using Cars.Domain.Models;
using CarStore.Core;
using MediatR;

namespace Cars.Application.Commands
{
    public class CreateCarCommand : IRequest<CommandResultBase<Guid>>
    {
        public CreateCarCommand(string vin, CarType type)
        {
            Vin = vin;
            Type = type;
        }

        public string Vin { get; }
        public CarType Type { get; }
    }
}
