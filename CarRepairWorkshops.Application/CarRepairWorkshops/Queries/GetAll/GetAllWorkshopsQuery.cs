using CarRepairWorkshops.Domain.Entities;
using MediatR;
using CarRepairWorkshops.Application.Common;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;

public class GetAllWorkshopsQuery : IRequest<PagedResult<CarRepairWorkshop>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

}
