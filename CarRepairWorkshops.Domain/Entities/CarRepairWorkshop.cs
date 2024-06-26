using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Domain.Entities;

public class CarRepairWorkshop
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public IEnumerable<Car> RepairCars { get; set; }


}
