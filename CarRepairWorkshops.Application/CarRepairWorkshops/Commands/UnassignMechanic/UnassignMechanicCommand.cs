using MediatR;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.UnassignMechanic;

public class UnassignMechanicCommand : IRequest
{
    public int WorkshopId { get; set; }
    public string UserEmail { get; set; } = default!;
}
