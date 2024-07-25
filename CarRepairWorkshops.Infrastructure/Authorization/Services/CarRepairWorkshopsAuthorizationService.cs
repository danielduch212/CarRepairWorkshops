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

        return false;
    }
}
