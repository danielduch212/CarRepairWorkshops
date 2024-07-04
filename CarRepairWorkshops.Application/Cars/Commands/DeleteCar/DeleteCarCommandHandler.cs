using AutoMapper;
using CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.Cars.Commands.DeleteCar;

public class DeleteCarCommandHandler(ILogger<DeleteCarCommandHandler> logger,
    ICarsRepository carRepository, IMapper mapper) : IRequestHandler<DeleteCarCommand>
{
    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting car by given id: {carId}", request.CarId);
        var car = await carRepository.GetByIdAsync(request.CarId);
        if (car == null) throw new NotFoundException(nameof(Repair), request.CarId.ToString());

        await carRepository.DeleteCar(car);
    }
}
