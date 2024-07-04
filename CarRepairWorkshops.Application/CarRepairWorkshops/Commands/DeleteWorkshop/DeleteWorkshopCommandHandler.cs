using AutoMapper;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.DeleteWorkshop
{
    internal class DeleteWorkshopCommandHandler(ILogger<CreateWorkshopCommandHandler> logger,
ICarRepairWorkshopsRepository workshopsRepository) : IRequestHandler<DeleteWorkshopCommand>
    {
        public async Task Handle(DeleteWorkshopCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting workshop with given Id: {WorkshopId}", request.WorkshopId);
            var workshop = await workshopsRepository.GetById(request.WorkshopId); 
            if (workshop == null) throw new NotFoundException(nameof(CarRepairWorkshop), request.WorkshopId.ToString());

            await workshopsRepository.DeleteWorkshop(workshop);
        }
    }
}
