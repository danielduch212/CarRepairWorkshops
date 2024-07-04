using MediatR;
using CarRepairWorkshops.Domain.Entities;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Domain.Exceptions;

namespace CarRepairWorkshops.Application.Repairs.Queries.GetAllForCar;

public class GetAllForCarQueryHandler(ILogger<GetAllForCarQueryHandler> logger,
    ICarRepairWorkshopsRepository workshopsRepository,
    ICarsRepository carsRepository)
    : IRequestHandler<GetAllForCarQuery, IEnumerable<Repair>>
{
    public async Task<IEnumerable<Repair>> Handle(GetAllForCarQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all repairs for car id");
        var workshop = await workshopsRepository.GetById(request.WorkshopId);
        if (workshop == null) throw new NotFoundException(nameof(CarRepairWorkshop), request.WorkshopId.ToString());

        var car = workshop.RepairCars.FirstOrDefault(c => c.Id == request.CarId);
        if (workshop == null) throw new NotFoundException(nameof(Car), request.WorkshopId.ToString());

        var resultCar = await carsRepository.GetByIdAsync(request.CarId);

        return resultCar.Repairs;

    }
}
