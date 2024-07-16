using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Application.Common;
using AutoMapper;


namespace CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;

public class GetAllWorkshopsQueryHandler(ILogger<GetAllWorkshopsQueryHandler> logger,
    ICarRepairWorkshopsRepository workshopsRepository) : IRequestHandler<GetAllWorkshopsQuery, PagedResult<CarRepairWorkshop>>
{
    public async Task<PagedResult<CarRepairWorkshop>> Handle(GetAllWorkshopsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all workshops");
        var (workshops, totalCount) = await workshopsRepository.GetAllMatchingAsync(request.SearchPhrase, request.PageNumber, request.PageSize);


        var result = new PagedResult<CarRepairWorkshop>(workshops.ToList(), totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
