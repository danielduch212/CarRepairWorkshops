using MediatR;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.AssignMechanic;

public class AssignMechanicCommand : IRequest
{
    public int WorkshopId { get; set; }
    public string UserEmail { get; set; } = default!;
}
