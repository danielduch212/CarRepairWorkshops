namespace CarRepairWorkshops.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string CarRegistrationNumber { get; set; } = default!;
    public string CarBrand { get; set; } = default!;
    public string CarName { get; set; } = default!;
    public int ProductionYear { get; set; } = default!;
    public string Engine { get; set; } = default!;
    public string OwnerTelephoneNumber { get; set; } = default!;
    public IEnumerable<Repair>? Repairs { get; set; }


    public int CarRepairWorkshopId { get; set; } = default!;
    public string CarRepairWorkshopName { get; set; } = default!;

}
