using AutoMapper;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.Repairs.Commands.AddReplacedCarPart
{
    public class AddReplacedCarPartCommandHandler(ILogger<AddReplacedCarPartCommandHandler> logger,
    IMapper mapper, IRepairRepository repairRepository)
        : IRequestHandler<AddReplacedCarPartCommand>
    {
        public async Task Handle(AddReplacedCarPartCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adding new replaced car part to given repair id: {repairId}", request.RepairId);
            var repair = await repairRepository.GetRepairByIdAsync(request.RepairId);
            if (repair == null) throw new NotFoundException(nameof(Repair), request.RepairId.ToString());

            var carPart = mapper.Map<CarPart>(request);

            var replacedCarParts = repair.ReplacedCarParts.ToList();
            replacedCarParts.Add(carPart);
            repair.ReplacedCarParts = replacedCarParts;
            repair.ComputeTotalPrice();
            await repairRepository.SaveDbAsync();


        }
    }
}
