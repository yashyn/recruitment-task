using Cars.Domain.Models;
using CarStore.Core;
using MediatR;

namespace Cars.Application.Commands
{
    public class UpdateCarCommand : IRequest<CommandResultBase>
    {
        public UpdateCarCommand(Guid id, string vin, CarType type)
        {
            Id = id;
            Vin = vin;
            Type = type;
        }

        public Guid Id { get; }
        public string Vin { get; }
        public CarType Type { get; }
    }
}
