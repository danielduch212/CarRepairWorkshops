using CarRepairWorkshops.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Interfaces;


namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.UploadWorkshopLogo;

internal class UploadWorkshopLogoCommandHandler(ILogger<UploadWorkshopLogoCommandHandler> logger,
    ICarRepairWorkshopsRepository carRepairWorkshopsRepository,
    ICarRepairWorkshopsAuthorizationService authorizationService,
    IBlobStorageService blobStorageService) : IRequestHandler<UploadWorkshopLogoCommand>
{
    public async Task Handle(UploadWorkshopLogoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Uploading new workshop logo for id {WorkshopId}", request.WorkshopId);
        var workshop = await carRepairWorkshopsRepository.GetById(request.WorkshopId);
        if (workshop is null) throw new NotFoundException(nameof(CarRepairWorkshop), request.WorkshopId.ToString());

        if (!authorizationService.Authorize(workshop, Domain.Constants.ResourceOperation.Update)) throw new
                ForbidException();
        var logoUrl = await blobStorageService.UploadToBlobAsync(request.File, request.Filename);
        workshop.WorkshopLogo = logoUrl;

        await carRepairWorkshopsRepository.SaveChangesAsync();

    }
}
