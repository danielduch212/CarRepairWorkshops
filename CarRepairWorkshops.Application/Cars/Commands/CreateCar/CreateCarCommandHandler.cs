using AutoMapper;
using CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Interfaces;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Cars.Commands.CreateCar
{
    internal class CreateCarCommandHandler(ILogger<GetAllForWorkshopQueryHandler> logger,
    ICarRepairWorkshopsRepository workshopsRepository, ICarsRepository carRepository,
    IMapper mapper, ICarRepairWorkshopsAuthorizationService authorizationService) : IRequestHandler<CreateCarCommand>
    {
        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new car to given id workshop: {WorkshopId}", request.CarRepairWorkshopId);
            var workshop = await workshopsRepository.GetById(request.CarRepairWorkshopId);
            if (workshop == null) throw new NotFoundException(nameof(workshop), request.CarRepairWorkshopId.ToString());

            if (!authorizationService.Authorize(workshop, Domain.Constants.ResourceOperation.Update)) throw new ForbidException();

            var car = mapper.Map<Car>(request);
            await carRepository.CreateCar(car);
        }
    }
}
