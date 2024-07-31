using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CarRepairWorkshops.Application.Common;
using Microsoft.Extensions.Azure;

namespace CarRepairWorkshops.Infrastructure.Repositories
{
    internal class CarRepairWorkshopsRepository(CarRepairWorkshopsDbContext dbContext)
        : ICarRepairWorkshopsRepository
    {
        public async Task<IEnumerable<CarRepairWorkshop>> GetAllWorkshopsAsync()
        {
            var workshops = await dbContext.CarRepairWorkshops.ToListAsync();
            return workshops;
        }

        public async Task<(IEnumerable<CarRepairWorkshop>, int)> GetAllMatchingAsync(string? searchPhrase, int pageNumber,
            int pageSize)
        {
            var searchPhraseToLower = searchPhrase?.ToLower();

            var baseQuery = dbContext.CarRepairWorkshops
                .Where(w => searchPhraseToLower == null || (w.Name.ToLower().Contains(searchPhraseToLower)
                        || w.Description.ToLower().Contains(searchPhraseToLower)));

            var totalCounts = await baseQuery.CountAsync();


            var workshops = await baseQuery
                .Skip(pageSize *(pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
                
            return (workshops, totalCounts);
        }

        public async Task<CarRepairWorkshop> GetById(int id)
        {
            var workshop = await dbContext.CarRepairWorkshops
                .Include(w => w.RepairCars)
                .FirstOrDefaultAsync(workshop => workshop.Id == id);
            return workshop;
                                        
        }

        public async Task CreateWorkshop(CarRepairWorkshop entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWorkshop(CarRepairWorkshop entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task AddMechanic(int workshopId, User user)
        {
            var workshop = dbContext.CarRepairWorkshops.FirstOrDefault(w => w.Id == workshopId);
            var list = workshop.Mechanics.ToList();
            list.Add(user);
            workshop.Mechanics = list;
            await dbContext.SaveChangesAsync();
        }

    }
}
