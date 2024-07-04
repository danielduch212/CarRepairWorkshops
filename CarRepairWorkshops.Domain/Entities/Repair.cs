using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Domain.Entities;

public class Repair
{
    public int Id { get; set; }    
    public DateOnly DateOfFinalization {  get; set; }
    public decimal? TotalPrice { get; set; }
    public IEnumerable<CarPart>? ReplacedCarParts { get; set; } = new List<CarPart>();
    public IEnumerable<MechanicalService>? MechanicalServices { get; set; } = new List<MechanicalService>();

        
    public int CarId { get; set; }


    public void ComputeTotalPrice()
    {
        decimal sum = 0;
        if (ReplacedCarParts.Any())
        {
            foreach (var item in ReplacedCarParts)
            {
                sum += item.Price;
            }
        }
        if (MechanicalServices.Any())
        {
            foreach (var item in MechanicalServices)
            {
                sum += item.Price;
            }
        }
        TotalPrice = sum; 
        

    }


}
