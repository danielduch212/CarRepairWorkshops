using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Domain.Repositories;

public interface IRepairRepository
{
    Task<int> CreateRepair(Repair repair);
    Task<Repair> GetRepairByIdAsync(int id);
    Task SaveDbAsync();
    Task DeleteEntity(Repair entity);
}
