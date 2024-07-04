using CarRepairWorkshops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Domain.Repositories
{
    public interface ICarsRepository
    {
        Task<Car> GetByIdAsync(int carId);
        Task CreateCar(Car entity);
        Task DeleteCar(Car entity);
        Task SaveDbAsync();
    }
}
