using MediatR;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.UploadWorkshopLogo;

public class UploadWorkshopLogoCommand : IRequest
{
    public int WorkshopId { get; set; }
    public string Filename { get; set; } = default!;
    public Stream File { get; set; } = default!;

}
    