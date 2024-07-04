using AutoMapper;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;

internal class CreateWorkshopCommandHandler(ILogger<CreateWorkshopCommandHandler> logger,
ICarRepairWorkshopsRepository workshopsRepository, IMapper mapper) : IRequestHandler<CreateWorkshopCommand>
{
    public Task Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"CreateWorkshop Command: {request}");
        var workshop = mapper.Map<CarRepairWorkshop>(request);

        workshopsRepository.CreateWorkshop(workshop);
        return Task.CompletedTask;
    }
}
