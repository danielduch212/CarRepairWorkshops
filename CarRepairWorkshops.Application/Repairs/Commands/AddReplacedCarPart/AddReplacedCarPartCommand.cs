using MediatR;

namespace CarRepairWorkshops.Application.Repairs.Commands.AddReplacedCarPart;

public class AddReplacedCarPartCommand : IRequest
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public int RepairId { get; set; }
}
