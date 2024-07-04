using CarRepairWorkshops.Domain.Repositories;
using CarRepairWorkshops.Infrastructure.Persistence;
using CarRepairWorkshops.Infrastructure.Repositories;
using CarRepairWorkshops.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRepairWorkshops.Infrastructure.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CarRepairWorkshopsDb");
        services.AddDbContext<CarRepairWorkshopsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<ICarRepairWorkshopsSeeder, CarRepairWorkshopsSeeder>();
        services.AddScoped<ICarRepairWorkshopsRepository, CarRepairWorkshopsRepository>();
        services.AddScoped<ICarsRepository, CarRepository>();    
        services.AddScoped<IRepairRepository, RepairRepository>();    

    }
}
