using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Domain.Entities;

public class Repair
{
    public int Id { get; set; }    
    public DateOnly DateOfFinalization {  get; set; }
    public decimal TotalPrice { get; set; }
    public IEnumerable<CarPart>? ReplacedCarParts { get; set; } 
    public IEnumerable<MechanicalService>? MechanicalServices { get; set; }


    public int CarId { get; set; }
    public string CarRegistrationNumber { get; set; } = default!;


}
