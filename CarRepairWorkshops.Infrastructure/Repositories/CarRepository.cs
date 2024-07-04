using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Infrastructure.Persistence;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace CarRepairWorkshops.Infrastructure.Repositories;

internal class CarRepository(CarRepairWorkshopsDbContext dbContext) : ICarsRepository
{
    public async Task<Car> GetByIdAsync(int carId)
    {
        var car = dbContext.Cars
            .Include(c => c.Repairs)
                .ThenInclude(r=>r.MechanicalServices)
            .Include(c=> c.Repairs)
                .ThenInclude(r=>r.ReplacedCarParts)
            .FirstOrDefault(c=>c.Id == carId);
        return car;
    }

    public async Task CreateCar(Car entity)
    {
        await dbContext.Cars.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCar(Car entity)
    {
        dbContext.Cars.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
    public async Task SaveDbAsync()
    {
        await dbContext.SaveChangesAsync();
    }

}
