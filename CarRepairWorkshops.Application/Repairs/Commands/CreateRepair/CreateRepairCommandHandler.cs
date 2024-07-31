using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Entities;
using AutoMapper;
using CarRepairWorkshops.Domain.Interfaces;

namespace CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;

internal class CreateRepairCommandHandler(ILogger<CreateRepairCommandHandler> logger,
    ICarsRepository carsRepository, IMapper mapper, IRepairRepository repairRepository,
    ICarRepairWorkshopsAuthorizationService authorizationService,
    ICarRepairWorkshopsRepository workshopsRepository)
    : IRequestHandler<CreateRepairCommand>
{
    public async Task Handle(CreateRepairCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new repair to given car id: {carId}", request.CarId);
        var car = await carsRepository.GetByIdAsync(request.CarId);
        if (car == null) throw new NotFoundException(nameof(Car), request.CarId.ToString());

        var workshop = await workshopsRepository.GetById(car.CarRepairWorkshopId);

        if (!authorizationService.AuthorizeMechanic(workshop)) throw new ForbidException();

        var repair = mapper.Map<Repair>(request);
        repair.ComputeTotalPrice();
        var repairId = repairRepository.CreateRepair(repair);

    }
}
