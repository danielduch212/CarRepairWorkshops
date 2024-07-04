using MediatR;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;
using CarRepairWorkshops.Domain.Repositories;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Exceptions;

namespace CarRepairWorkshops.Application.Cars.Queries.GetCarById
{
    internal class GetCarByIdQueryHandler(ILogger<GetAllForWorkshopQueryHandler> logger,
    ICarsRepository carRepository)
        : IRequestHandler<GetCarByIdQuery, Car>
    {
        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all cars for workshop");
            var car = await carRepository.GetByIdAsync(request.CarId);
            if (car == null) throw new NotFoundException(nameof(Car), request.CarId.ToString());

            return car;
        }
    }
}
