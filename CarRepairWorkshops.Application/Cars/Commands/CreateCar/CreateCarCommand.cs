using CarRepairWorkshops.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommand : IRequest
    {
        public string CarRegistrationNumber { get; set; } = default!;
        public string CarBrand { get; set; } = default!;
        public string CarName { get; set; } = default!;
        public int ProductionYear { get; set; } = default!;
        public string Engine { get; set; } = default!;
        public string OwnerTelephoneNumber { get; set; } = default!;
        public IEnumerable<Repair>? Repairs { get; set; } = new List<Repair>();


        public int CarRepairWorkshopId { get; set; } = default!;
    }
}
