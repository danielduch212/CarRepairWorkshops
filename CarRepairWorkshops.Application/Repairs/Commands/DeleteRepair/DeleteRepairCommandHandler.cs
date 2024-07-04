using AutoMapper;
using CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Repairs.Commands.DeleteRepair
{
    internal class DeleteRepairCommandHandler(ILogger<CreateRepairCommandHandler> logger,
    IMapper mapper, IRepairRepository repairRepository)
        : IRequestHandler<DeleteRepairCommand>
    {
        public async Task Handle(DeleteRepairCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting repair by given id: {repairId}", request.RepairId);
            var repair = await repairRepository.GetRepairByIdAsync(request.RepairId);
            if(repair == null) throw new NotFoundException(nameof(Repair), request.RepairId.ToString());

            await repairRepository.DeleteEntity(repair);
        }
    }
}
