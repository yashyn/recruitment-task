using Cars.Application.Commands;
using CarStore.Core;
using MediatR;
using Moq;
using System;
using System.Threading;

namespace Cars.UnitTests.Controllers.Mocks
{
    internal class MediatorMock : Mock<IMediator>
    {
        internal MediatorMock MockCreate(CommandResultBase<Guid> mediatorResult)
        {
            Setup(x => x.Send(It.IsAny<CreateCarCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mediatorResult);

            return this;
        }
    }
}
