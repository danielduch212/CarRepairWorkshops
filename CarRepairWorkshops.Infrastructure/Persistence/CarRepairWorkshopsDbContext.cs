using Microsoft.EntityFrameworkCore;
using CarRepairWorkshops.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarRepairWorkshops.Infrastructure.Persistence;

internal class CarRepairWorkshopsDbContext(DbContextOptions<CarRepairWorkshopsDbContext> options) : IdentityDbContext<User>(options)
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
            .HasMany(w => w.Mechanics)
            .WithOne()
            .HasForeignKey(m => m.CurrentWorkshopId);

        modelBuilder.Entity<CarRepairWorkshop>()
            .HasMany(w => w.RepairCars)
            .WithOne()
            .HasForeignKey(c => c.CarRepairWorkshopId);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.Repairs)
            .WithOne()
            .HasForeignKey(r => r.CarId);

        modelBuilder.Entity<Repair>()
            .HasMany(r => r.MechanicalServices)
            .WithOne()
            .HasForeignKey(s => s.RepairId);

        modelBuilder.Entity<Repair>()
            .HasMany(r => r.ReplacedCarParts)
            .WithOne()
            .HasForeignKey(c=>c.RepairId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.OwnedWorkshops)
            .WithOne(w => w.Owner)
            .HasForeignKey(w => w.OwnerId);



    }
}
