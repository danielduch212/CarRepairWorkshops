using MediatR;

namespace CarRepairWorkshops.Application.Repairs.Commands.AddService;

public class AddServiceToRepairCommand : IRequest
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public int RepairId { get; set; }
}
