using CarStore.Api.Dtos.Cars;
using FluentValidation;

namespace CarStore.Api.Validators.Cars
{
    public class CreateCarRequestDtoValidator : AbstractValidator<CreateCarRequestDto>
    {
        public CreateCarRequestDtoValidator()
        {
            RuleFor(x => x.Vin).NotNull().NotEmpty().MinimumLength(CarRuleConstants.MinVinLength).MaximumLength(CarRuleConstants.MaxVinLength);
            RuleFor(x => x.Type).NotNull().IsInEnum();
        }
    }
}
