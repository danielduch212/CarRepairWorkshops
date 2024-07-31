using AutoMapper;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;
using CarRepairWorkshops.Application.Users;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Interfaces;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.AssignMechanic;

public class AssignMechanicCommandHandler(ILogger<AssignMechanicCommandHandler> logger,
ICarRepairWorkshopsRepository workshopsRepository, 
IUserContext userContext,
ICarRepairWorkshopsAuthorizationService authorizationService,
UserManager<User> userManager,
RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignMechanicCommand>
{
    public async Task Handle(AssignMechanicCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning mechanic with given email: {Email} to workshop with id: {WorkshopId}", request.UserEmail, request.WorkshopId);
        var workshop = await workshopsRepository.GetById(request.WorkshopId);

        if (!authorizationService.Authorize(workshop, Domain.Constants.ResourceOperation.Update)) throw new ForbidException();

        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new NotFoundException(nameof(User), request.UserEmail);

        if (user.CurrentWorkshopId != null) throw new ForbidException();

        var list = workshop.Mechanics.ToList();
        list.Add(user);
        workshop.Mechanics = list;

        await userManager.AddToRoleAsync(user, UserRoles.Mechanic);
        await workshopsRepository.SaveChangesAsync();


    }
}
