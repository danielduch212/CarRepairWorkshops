namespace CarRepairWorkshops.Domain.Entities;

public class MechanicalService
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public int RepairId { get; set; }

}
