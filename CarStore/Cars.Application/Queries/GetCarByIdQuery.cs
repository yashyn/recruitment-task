using Cars.Domain.Models;
using CarStore.Core;
using MediatR;

namespace Cars.Application.Queries
{
    public class GetCarByIdQuery : IRequest<CommandResultBase<Car>>
    {
        public GetCarByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
