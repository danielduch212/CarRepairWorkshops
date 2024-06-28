

namespace CarRepairWorkshops.Domain.Entities;

public class CarPart
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

}
