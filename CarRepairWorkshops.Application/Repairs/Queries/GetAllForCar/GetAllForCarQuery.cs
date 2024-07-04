using MediatR;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Application.Repairs.Queries.GetAllForCar;

public class GetAllForCarQuery(int workshopId, int carId) : IRequest<IEnumerable<Repair>>
{
    public int WorkshopId { get; } = workshopId;
    public int CarId { get; } = carId;
}
