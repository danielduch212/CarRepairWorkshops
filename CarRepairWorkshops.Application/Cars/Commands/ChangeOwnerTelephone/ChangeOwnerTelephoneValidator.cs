using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Cars.Commands.ChangeOwnerTelephone
{
    public class ChangeOwnerTelephoneValidator : AbstractValidator<ChangeOwnerTelephoneCommand>
    {
        public ChangeOwnerTelephoneValidator() 
        {
            RuleFor(t => t.NewTelephoneNumber)
                .NotEmpty().WithMessage("Telephone number property can't be null");
            RuleFor(t => t.CarId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Owner Id must be greater than 0");
                
        }
    }
}
