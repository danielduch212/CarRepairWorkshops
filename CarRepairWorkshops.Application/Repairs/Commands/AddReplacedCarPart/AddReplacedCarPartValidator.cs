using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Repairs.Commands.AddReplacedCarPart
{
    public class AddReplacedCarPartValidator : AbstractValidator<AddReplacedCarPartCommand>
    {
        public AddReplacedCarPartValidator() 
        {
            RuleFor(c=>c.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than 0");



        }

    }
}
