using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Cars.Commands.CreateCar
{
    internal class CreateCarValdiator :AbstractValidator<CreateCarCommand>
    {
        CreateCarValdiator()
        {
            RuleFor(c => c.CarRegistrationNumber)
                .NotEmpty().WithMessage("CarRegistrationNumber property can't be empty");
            RuleFor(c => c.CarBrand)
                .NotEmpty().WithMessage("Car brand property can't be empty");
            RuleFor(c => c.CarName)
                .NotEmpty().WithMessage("Car name can't be empty");
            RuleFor(c => c.ProductionYear)
                .GreaterThanOrEqualTo(0).WithMessage("Production Year must be greater than 0")
                .NotEmpty().WithMessage("Can't be empty");
            RuleFor(c => c.Engine)
                .NotEmpty().WithMessage("Engine property can't be empty");
            RuleFor(c => c.OwnerTelephoneNumber)
                .NotEmpty().WithMessage("OwnerTelephoneNumber Can't be empty");
            RuleFor(c => c.CarRepairWorkshopId)
                .GreaterThanOrEqualTo(0).WithMessage("Workshop Id must be greater than 0");


        }
    }
}
