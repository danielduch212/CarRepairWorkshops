using MediatR;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;

public class GetAllForWorkshopQuery(int id) : IRequest<IEnumerable<Car>>
{
    public int Id { get; } = id;


}
