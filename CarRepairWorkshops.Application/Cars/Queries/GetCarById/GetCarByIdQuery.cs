using CarRepairWorkshops.Domain.Entities;
using MediatR;

namespace CarRepairWorkshops.Application.Cars.Queries.GetCarById;

public class GetCarByIdQuery(int id) : IRequest<Car>
{
    public int CarId { get; } = id;
}
