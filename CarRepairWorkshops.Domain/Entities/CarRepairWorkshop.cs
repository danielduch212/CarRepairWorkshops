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
    public Address Address { get; set; } = default!;

    public IEnumerable<Car>? RepairCars { get; set; } = new List<Car>();
    public IEnumerable<User>? Mechanics { get; set; } = new List<User>();


    public User Owner { get; set; } = default!;
    public string OwnerId { get; set; } = default!;
    public string? WorkshopLogo { get; set; }
    


}
