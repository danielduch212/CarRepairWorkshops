using CarRepairWorkshops.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop
{
    public class CreateWorkshopCommand : IRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }

        public IEnumerable<Car>? RepairCars { get; set; } = new List<Car>();
    }
}
