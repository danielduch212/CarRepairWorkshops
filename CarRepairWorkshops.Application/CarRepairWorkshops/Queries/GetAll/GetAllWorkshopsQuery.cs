using CarRepairWorkshops.Domain.Entities;
using MediatR;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;

public class GetAllWorkshopsQuery : IRequest<IEnumerable<CarRepairWorkshop>>
{

}
