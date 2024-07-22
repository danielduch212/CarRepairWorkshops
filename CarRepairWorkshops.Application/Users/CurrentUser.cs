namespace CarRepairWorkshops.Application.Users;

public class CurrentUser(string Id, 
    string Email, IEnumerable<string> Roles,
    string? Nationality,
DateOnly? DateOfBirth)
{
    public string Id { get; } = Id;
    public string Email { get; } = Email;
    
    public IEnumerable<string> Roles { get; } = Roles;
    public string? Nationality { get; } = Nationality;
    public DateOnly? DateOfBirth { get; } = DateOfBirth;

    public bool IsInRole(string role) => Roles.Contains(role);
}
