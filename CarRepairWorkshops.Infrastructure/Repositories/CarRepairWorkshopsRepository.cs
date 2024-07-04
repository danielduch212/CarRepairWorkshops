using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
