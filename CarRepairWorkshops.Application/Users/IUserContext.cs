namespace CarRepairWorkshops.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}