using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;

public class GetAllWorkshopsQueryHandler(ILogger<GetAllWorkshopsQueryHandler> logger,
    ICarRepairWorkshopsRepository workshopsRepository) : IRequestHandler<GetAllWorkshopsQuery, IEnumerable<CarRepairWorkshop>>
{
    public async Task<IEnumerable<CarRepairWorkshop>> Handle(GetAllWorkshopsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all workshops");
        var workshops = await workshopsRepository.GetAllWorkshopsAsync();
        return workshops;
    }
}
