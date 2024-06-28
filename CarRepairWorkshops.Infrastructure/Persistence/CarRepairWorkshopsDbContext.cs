using Microsoft.EntityFrameworkCore;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Infrastructure.Persistence;

internal class CarRepairWorkshopsDbContext(DbContextOptions<CarRepairWorkshopsDbContext> options) : DbContext(options)
{
    internal DbSet<CarRepairWorkshop> CarRepairWorkshops { get; set; }
    internal DbSet<Car> Cars { get; set; }
    internal DbSet<Repair> Repairs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarRepairWorkshop>()
            .OwnsOne(w => w.Address);

        modelBuilder.Entity<CarRepairWorkshop>()
            .HasMany(w => w.RepairCars)
            .WithOne()
            .HasForeignKey(c => c.CarRepairWorkshopId);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.Repairs)
            .WithOne()
            .HasForeignKey(r => r.CarId);
            
    }
}
