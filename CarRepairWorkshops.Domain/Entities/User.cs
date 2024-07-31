using Microsoft.AspNetCore.Identity;


namespace CarRepairWorkshops.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }

    public IEnumerable<CarRepairWorkshop> OwnedWorkshops { get; set; } = new List<CarRepairWorkshop>();
    public int? CurrentWorkshopId { get; set; } //for mechanics

}
