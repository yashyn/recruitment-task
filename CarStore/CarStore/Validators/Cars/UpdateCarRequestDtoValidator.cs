using CarStore.Api.Dtos.Cars;
using FluentValidation;

namespace CarStore.Api.Validators.Cars
{
    public class UpdateCarRequestDtoValidator : AbstractValidator<UpdateCarRequestDto>
    {
        public UpdateCarRequestDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(x => x.Vin).NotNull().NotEmpty().MinimumLength(CarRuleConstants.MinVinLength).MaximumLength(CarRuleConstants.MaxVinLength);
            RuleFor(x => x.Type).NotNull().IsInEnum();
        }
    }
}
