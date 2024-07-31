using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.AssignMechanic;
using CarRepairWorkshops.Application.Users;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Interfaces;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.UnassignMechanic;

public class UnassignMechanicCommandHandler(ILogger<UnassignMechanicCommandHandler> logger,
ICarRepairWorkshopsRepository workshopsRepository,
IUserContext userContext,
ICarRepairWorkshopsAuthorizationService authorizationService,
UserManager<User> userManager,
RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignMechanicCommand>
{
    public async Task Handle(UnassignMechanicCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unssigning mechanic with given email: {Email} to workshop with id: {WorkshopId}", request.UserEmail, request.WorkshopId);
        var workshop = await workshopsRepository.GetById(request.WorkshopId);

        if (!authorizationService.Authorize(workshop, Domain.Constants.ResourceOperation.Update)) throw new ForbidException();

        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new NotFoundException(nameof(User), request.UserEmail);

        var user2 = workshop.Mechanics.FirstOrDefault(u => u.Email == request.UserEmail);
        if(user2==null) throw new ForbidException();

        var list = workshop.Mechanics.ToList();
        list.Remove(user);
        workshop.Mechanics = list;

        await userManager.RemoveFromRoleAsync(user, UserRoles.Mechanic);
        await workshopsRepository.SaveChangesAsync();
    }
}
