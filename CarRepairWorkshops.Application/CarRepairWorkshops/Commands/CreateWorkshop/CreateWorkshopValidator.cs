using FluentValidation;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;

public class CreateWorkshopValidator : AbstractValidator<CreateWorkshopCommand>
{
    public CreateWorkshopValidator() {

        RuleFor(w => w.Name)
            .NotEmpty().WithMessage("Car Workshop name can't be empty");
        RuleFor(w => w.Description)
            .NotEmpty().WithMessage("Description property can't be empty");


    }
}
