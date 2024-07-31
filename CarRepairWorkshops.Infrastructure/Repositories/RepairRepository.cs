using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarRepairWorkshops.Infrastructure.Repositories;

internal class RepairRepository(CarRepairWorkshopsDbContext dbContext) : IRepairRepository
{
    public async Task<int> CreateRepair(Repair repair)
    {
        await dbContext.Repairs.AddAsync(repair);
        await dbContext.SaveChangesAsync();
        return repair.Id;
    }

    public async Task<Repair> GetRepairByIdAsync(int id)
    {
        var repair = await dbContext.Repairs
            .Include(r => r.MechanicalServices)
            .Include(r=>r.ReplacedCarParts)
            .FirstOrDefaultAsync(r => r.Id == id);
        return repair;
    }

    public async Task DeleteEntity(Repair entity)
    {
        dbContext.Repairs.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveDbAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    
}
