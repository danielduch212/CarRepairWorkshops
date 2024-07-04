using FluentValidation;

namespace CarRepairWorkshops.Application.Repairs.Commands.AddService
{
    public class AddServiceToRepairValidator : AbstractValidator<AddServiceToRepairCommand>
    {
        public AddServiceToRepairValidator()
        {
            RuleFor(s => s.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than 0");
            
        }
    }
}
