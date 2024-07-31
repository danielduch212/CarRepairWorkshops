using AutoMapper;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Interfaces;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.Cars.Commands.ChangeOwnerTelephone;

public class ChangeOwnerTelephoneCommandHandler(ILogger<ChangeOwnerTelephoneCommandHandler> logger,
ICarRepairWorkshopsRepository workshopsRepository, ICarsRepository carRepository,
IMapper mapper, ICarRepairWorkshopsAuthorizationService authorizationService) : IRequestHandler<ChangeOwnerTelephoneCommand>
{
    public async Task Handle(ChangeOwnerTelephoneCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Changing owner number to given car id: {carId}", request.CarId);
        var car = await carRepository.GetByIdAsync(request.CarId);
        if (car == null) throw new NotFoundException(nameof(Car), request.CarId.ToString());

        if (!authorizationService.Authorize(await workshopsRepository.GetById(car.CarRepairWorkshopId), Domain.Constants.ResourceOperation.Update)) throw new ForbidException();


        car.OwnerTelephoneNumber = request.NewTelephoneNumber;
        await carRepository.SaveDbAsync();
    }
}
