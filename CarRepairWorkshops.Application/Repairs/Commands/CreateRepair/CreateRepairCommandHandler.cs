using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Entities;
using AutoMapper;

namespace CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;

internal class CreateRepairCommandHandler(ILogger<CreateRepairCommandHandler> logger,
    ICarsRepository carsRepository, IMapper mapper, IRepairRepository repairRepository)
    : IRequestHandler<CreateRepairCommand, int>
{
    public Task<int> Handle(CreateRepairCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new repair to given car id: {carId}", request.CarId);
        var car = carsRepository.GetByIdAsync(request.CarId);
        if (car == null) throw new NotFoundException(nameof(Car), request.CarId.ToString());

        var repair = mapper.Map<Repair>(request);
        repair.ComputeTotalPrice();
        var repairId = repairRepository.CreateRepair(repair);
        return repairId;

    }
}
