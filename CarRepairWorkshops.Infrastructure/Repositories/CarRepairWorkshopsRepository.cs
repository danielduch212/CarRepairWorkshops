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



    }
}
