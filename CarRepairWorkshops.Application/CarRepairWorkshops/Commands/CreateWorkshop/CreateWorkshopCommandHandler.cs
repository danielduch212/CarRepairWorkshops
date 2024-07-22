using AutoMapper;
using CarRepairWorkshops.Application.Users;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;

public class CreateWorkshopCommandHandler(ILogger<CreateWorkshopCommandHandler> logger,
ICarRepairWorkshopsRepository workshopsRepository, IMapper mapper,
IUserContext userContext) : IRequestHandler<CreateWorkshopCommand>
{
    public Task Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("{UserName} , user Id: {UserId} is creating Workshop Command: {request}",
            currentUser.Email,
            currentUser.Id,
            request);

        var workshop = mapper.Map<CarRepairWorkshop>(request);
        workshop.OwnerId = currentUser.Id;

        workshopsRepository.CreateWorkshop(workshop);
        return Task.CompletedTask;
    }
}
