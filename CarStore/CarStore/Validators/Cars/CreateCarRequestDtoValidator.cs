using CarStore.Api.Dtos.Cars;
using FluentValidation;

namespace CarStore.Api.Validators.Cars
{
    public class CreateCarRequestDtoValidator : AbstractValidator<CreateCarRequestDto>
    {
        public CreateCarRequestDtoValidator()
        {
            RuleFor(x => x.Vin).NotNull().NotEmpty().MinimumLength(11).MaximumLength(17);
            RuleFor(x => x.Type).NotNull().IsInEnum();
        }
    }
}
