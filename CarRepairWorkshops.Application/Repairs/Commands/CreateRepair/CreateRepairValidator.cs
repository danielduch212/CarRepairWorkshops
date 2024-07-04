using FluentValidation;

namespace CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;

public class CreateRepairValidator : AbstractValidator<CreateRepairCommand>
{
    public CreateRepairValidator()
    {
        RuleFor(r => r.CarId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("CarId must be greater than 0");




    }
}
