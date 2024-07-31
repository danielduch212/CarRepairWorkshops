using MediatR;
using CarRepairWorkshops.Domain.Entities;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using CarRepairWorkshops.Domain.Interfaces;

namespace CarRepairWorkshops.Application.Repairs.Queries.GetAllForCar;

public class GetAllForCarQueryHandler(ILogger<GetAllForCarQueryHandler> logger,
    ICarRepairWorkshopsRepository workshopsRepository,
    ICarsRepository carsRepository,
    ICarRepairWorkshopsAuthorizationService authorizationService)
    : IRequestHandler<GetAllForCarQuery, IEnumerable<Repair>>
{
    public async Task<IEnumerable<Repair>> Handle(GetAllForCarQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all repairs for car id");
        var workshop = await workshopsRepository.GetById(request.WorkshopId);
        if (workshop == null) throw new NotFoundException(nameof(CarRepairWorkshop), request.WorkshopId.ToString());
        

        var car = workshop.RepairCars.FirstOrDefault(c => c.Id == request.CarId);
        if (workshop == null) throw new NotFoundException(nameof(Car), request.WorkshopId.ToString());


        if (!authorizationService.AuthorizeMechanic(workshop) && !authorizationService.AuthorizeCarOwner(car)) throw new ForbidException();

        return car.Repairs;

    }
}
