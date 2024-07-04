using AutoMapper;
using CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CarRepairWorkshops.Application.Repairs.Commands.AddService;

public class AddServiceToRepairCommandHandler(ILogger<AddServiceToRepairCommandHandler> logger,
    IMapper mapper, IRepairRepository repairRepository
    ) : IRequestHandler<AddServiceToRepairCommand>
{
    public async Task Handle(AddServiceToRepairCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding new mechanical service to given repair id: {repairId}", request.RepairId);
        var repair = await repairRepository.GetRepairByIdAsync(request.RepairId);
        if (repair == null) throw new NotFoundException(nameof(Repair), request.RepairId.ToString());

        var mechanicalService = mapper.Map<MechanicalService>(request);

        var mechanicalServices = repair.MechanicalServices.ToList();
        mechanicalServices.Add(mechanicalService);
        repair.MechanicalServices = mechanicalServices;
        repair.ComputeTotalPrice();
        await repairRepository.SaveDbAsync();


    }
}
    