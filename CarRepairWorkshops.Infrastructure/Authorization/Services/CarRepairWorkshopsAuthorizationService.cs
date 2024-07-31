using CarRepairWorkshops.Application.Users;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Infrastructure.Authorization.Services;

public class CarRepairWorkshopsAuthorizationService(ILogger<CarRepairWorkshopsAuthorizationService> logger,
    IUserContext userContext) : ICarRepairWorkshopsAuthorizationService
{
    public bool Authorize(CarRepairWorkshop workshop, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Authorizing user: {UserEmail}, to {Operation} for workshop: {WorkshopName}",
            user.Email,
            resourceOperation,
            workshop.Name);

        if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
        {
            logger.LogInformation("Read Operation - succesful authorization");
            return true;
        }
        if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user - delete opeation - authorization succesful");
            return true;
        }
        if (resourceOperation == ResourceOperation.Update || resourceOperation == ResourceOperation.Delete
            && workshop.OwnerId == user.Id)
        {
            logger.LogInformation("Workshop owner - succesful authorization");
            return true;
        }
        if (resourceOperation == ResourceOperation.Create && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user - create operation - succesful authorization");

            return true;
        }
        if (resourceOperation == ResourceOperation.ReadCredential && workshop.OwnerId == user.Id || user.IsInRole(UserRoles.Admin))
        {
            return true;
        }

        return false;
    }

    public bool AuthorizeMechanic(CarRepairWorkshop workshop)
    {
        var user = userContext.GetCurrentUser();

        var userToFind = workshop.Mechanics.FirstOrDefault(m => m.Id == user.Id);
        if (userToFind == null) return false;
        if (workshop.OwnerId == user.Id) return true;
        return true;
    }

    public bool AuthorizeCarOwner(Car car)
    {
        var user = userContext.GetCurrentUser();
        if (car.CarOwnerId.ToString() == user.Id) return true;
        return false;
    }
}
