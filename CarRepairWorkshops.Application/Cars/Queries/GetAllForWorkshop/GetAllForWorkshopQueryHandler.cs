using MediatR;
using CarRepairWorkshops.Domain.Entities;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Domain.Exceptions;

namespace CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;

internal class GetAllForWorkshopQueryHandler(ILogger<GetAllForWorkshopQueryHandler> logger,
    ICarRepairWorkshopsRepository workshopsRepository) : IRequestHandler<GetAllForWorkshopQuery, IEnumerable<Car>>
{
    public async Task<IEnumerable<Car>> Handle(GetAllForWorkshopQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all cars for workshop");
        var workshop = await workshopsRepository.GetById(request.Id);
        if (workshop == null) throw new NotFoundException(nameof(CarRepairWorkshop), request.Id.ToString());

        var results = workshop.RepairCars;
        return results;
    }
}
