using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Domain.Interfaces;

public interface ICarRepairWorkshopsAuthorizationService
{
    bool Authorize(CarRepairWorkshop workshop, ResourceOperation resourceOperation);
    bool AuthorizeMechanic(CarRepairWorkshop workshop);
    public bool AuthorizeCarOwner(Car car);
}