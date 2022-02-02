using Cars.UnitTests.Controllers.Mocks;
using CarStore.Controllers.Cars;
using CarStore.Core;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cars.UnitTests.Controllers
{
    public class CreateTests
    {
        [Fact(DisplayName = "CreateTests TestCreatedSuccessufully")]
        public async Task TestCreatedSuccessufully()
        {
            var createdId = Guid.NewGuid();
            var mediatorMock = new MediatorMock().MockCreate(
                new CommandResultBase<Guid>(createdId, CommandResultType.Success));

            var controller = new CarController(mediatorMock.Object);
            var dto = new CarStore.Api.Dtos.Cars.CreateCarRequestDto
            {
                Type = Domain.Models.CarType.Wagon,
                Vin = "123456789091235"
            };


            var result = await controller.CreateAsync(dto, CancellationToken.None);

            var okResult = result.Should().BeOfType<OkObjectResult>();
            okResult.Subject.Value.Should().Be(createdId);
        }

        [Fact(DisplayName = "CreateTests TestVinAlreadyExists")]
        public async Task TestVinAlreadyExists()
        {
            var createdId = Guid.NewGuid();
            var mediatorMock = new MediatorMock().MockCreate(
                new CommandResultBase<Guid>(createdId, CommandResultType.AlreadyExists));

            var controller = new CarController(mediatorMock.Object);
            var dto = new CarStore.Api.Dtos.Cars.CreateCarRequestDto
            {
                Type = Domain.Models.CarType.Wagon,
                Vin = "123456789091235"
            };


            var result = await controller.CreateAsync(dto, CancellationToken.None);

            var okResult = result.Should().BeOfType<ConflictObjectResult>();
            okResult.Subject.Value.Should().Be(dto.Vin);
        }

        [Fact(DisplayName = "CreateTests TestUndefinedResult")]
        public async Task TestUndefinedResult()
        {
            var createdId = Guid.NewGuid();
            var mediatorMock = new MediatorMock().MockCreate(
                new CommandResultBase<Guid>(createdId, CommandResultType.InternalError));

            var controller = new CarController(mediatorMock.Object);
            var dto = new CarStore.Api.Dtos.Cars.CreateCarRequestDto
            {
                Type = Domain.Models.CarType.Wagon,
                Vin = "123456789091235"
            };


            var result = await controller.CreateAsync(dto, CancellationToken.None);

            var okResult = result.Should().BeOfType<StatusCodeResult>();
            okResult.Subject.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}