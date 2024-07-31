using MediatR;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;
using CarRepairWorkshops.Domain.Repositories;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Interfaces;

namespace CarRepairWorkshops.Application.Cars.Queries.GetCarById
{
    internal class GetCarByIdQueryHandler(ILogger<GetAllForWorkshopQueryHandler> logger,
    ICarsRepository carRepository, 
    ICarRepairWorkshopsRepository workshopsRepository,
    ICarRepairWorkshopsAuthorizationService authorizationService)
        : IRequestHandler<GetCarByIdQuery, Car>
    {
        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting car by id");

            var car = await carRepository.GetByIdAsync(request.CarId);
            if (car == null) throw new NotFoundException(nameof(Car), request.CarId.ToString());

            var workshop = await workshopsRepository.GetById(car.CarRepairWorkshopId);
            if (!authorizationService.AuthorizeMechanic(workshop)) throw new ForbidException();
            return car;
        }
    }
}
