using CarRepairWorkshops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Domain.Repositories
{
    public interface ICarRepairWorkshopsRepository
    {
        Task<IEnumerable<CarRepairWorkshop>> GetAllWorkshopsAsync();
    }
}
