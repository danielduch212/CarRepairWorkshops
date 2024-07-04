using MediatR;

namespace CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;

public class CreateRepairCommand : IRequest<int>
{
    public DateOnly DateOfFinalization { get; set; }
    public int CarId { get; set; }
}
