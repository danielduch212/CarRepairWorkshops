using MediatR;

namespace CarRepairWorkshops.Application.Cars.Commands.ChangeOwnerTelephone
{
    public class ChangeOwnerTelephoneCommand : IRequest
    {
        public int CarId { get; set; }
        public string NewTelephoneNumber { get; set; } = default!;
    }
}
