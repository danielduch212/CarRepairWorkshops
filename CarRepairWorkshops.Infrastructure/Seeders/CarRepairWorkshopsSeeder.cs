using CarRepairWorkshops.Infrastructure.Persistence;
using CarRepairWorkshops.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using CarRepairWorkshops.Domain.Constants;
using Microsoft.EntityFrameworkCore;

namespace CarRepairWorkshops.Infrastructure.Seeders;

internal class CarRepairWorkshopsSeeder(CarRepairWorkshopsDbContext dbContext) : ICarRepairWorkshopsSeeder
{


    public async Task Seed()
    {

        //if (dbContext.Database.GetPendingMigrations().Any())
        //{
        //    await dbContext.Database.MigrateAsync();
        //}

        if(await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.CarRepairWorkshops.Any())
            {
                var workshops = GetWorkshops();
                dbContext.CarRepairWorkshops.AddRange(workshops);
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.Roles.Any()) 
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            
            
            }


            
            
        }
    }


    private IEnumerable<CarRepairWorkshop> GetWorkshops()
    {
        User owner = new User()
        {
            Email = "seed-user@test.com"

        };
        List<CarRepairWorkshop> workshops = [

            new()
            {
                Owner = owner,
                Name = "Golden wheel",
                Description = "We specialize in everything that car need",
                Address = new Address{
                    City = "Warsaw",
                    Street = "Main Street 1",
                    PostalCode = "00-001"
                },
                RepairCars = new List<Car>{
                    new(){
                        CarRegistrationNumber = "SB5372H",
                        CarBrand = "FORD",
                        CarName = "MONDEO",
                        ProductionYear = 2018,
                        Engine = "1.4 Diesel",
                        OwnerTelephoneNumber = "577239145",
                        Repairs = new List<Repair>{
                            new()
                            {
                                DateOfFinalization = new DateOnly(2020, 5, 24),
                                TotalPrice = 200.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Brake Pads",
                                        Price = 80m,
                                    },
                                    new CarPart
                                    {
                                        Name = "Engine oil + filters",
                                        Price = 100m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Change brake pads",
                                        Price = 50m,
                                    },
                                    new MechanicalService{
                                        Name = "Change oil + filters",
                                        Price = 50m,
                                    }

                                }

                            },
                            new(){
                                DateOfFinalization = new DateOnly(2021, 5, 24),
                                TotalPrice = 200.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Timing Belt",
                                        Price = 150m,
                                    },
                                    new CarPart
                                    {
                                        Name = "Water Pump",
                                        Price = 100m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Replace timing belt",
                                        Price = 50m,
                                    },
                                    new MechanicalService{
                                        Name = "Replace water pump",
                                        Price = 100m,
                                    }

                                }

                            }
                        }
                    },
                    new(){
                        CarRegistrationNumber = "GB5324H",
                        CarBrand = "AUDI",
                        CarName = "A4",
                        ProductionYear = 2005,
                        Engine = "2.0 TDI Diesel",
                        OwnerTelephoneNumber = "984726435",
                        Repairs =new List<Repair>{
                            new()
                            {
                                DateOfFinalization = new DateOnly(2020, 7, 16),
                                TotalPrice = 2600.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Engine parts",
                                        Price = 1500m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Engine Regeneration",
                                        Price = 1100m,
                                    },

                                }

                            },
                            new(){
                                DateOfFinalization = new DateOnly(2022, 5, 27),
                                TotalPrice = 200.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Timing Belt",
                                        Price = 150m,
                                    },
                                    new CarPart
                                    {
                                        Name = "Water Pump",
                                        Price = 100m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Replace timing belt",
                                        Price = 50m,
                                    },
                                    new MechanicalService{
                                        Name = "Replace water pump",
                                        Price = 100m,
                                    }

                                }

                            }
                        }
                    }
                }
            },
            new()
            {
                Owner = owner,
                Name = "Silver Wheel",
                Description = "We provide comprehensive car repair services",
                Address = new Address{
                    City = "Poznan",
                    Street = "Liberty Avenue 45",
                    PostalCode = "61-707"
                },
                RepairCars = new List<Car>{
                    new(){
                        CarRegistrationNumber = "PO1234B",
                        CarBrand = "TOYOTA",
                        CarName = "COROLLA",
                        ProductionYear = 2017,
                        Engine = "1.8 Hybrid",
                        OwnerTelephoneNumber = "600123456",
                        Repairs = new List<Repair>{
                            new()
                            {
                                DateOfFinalization = new DateOnly(2021, 8, 10),
                                TotalPrice = 300.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Air Filter",
                                        Price = 50m,
                                    },
                                    new CarPart
                                    {
                                        Name = "Brake Discs",
                                        Price = 120m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Replace air filter",
                                        Price = 30m,
                                    },
                                    new MechanicalService{
                                        Name = "Replace brake discs",
                                        Price = 100m,
                                    }

                                }

                            },
                            new(){
                                DateOfFinalization = new DateOnly(2022, 10, 15),
                                TotalPrice = 450.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Battery",
                                        Price = 250m,
                                    },
                                    new CarPart
                                    {
                                        Name = "Spark Plugs",
                                        Price = 80m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Replace battery",
                                        Price = 50m,
                                    },
                                    new MechanicalService{
                                        Name = "Replace spark plugs",
                                        Price = 70m,
                                    }

                                }

                            }
                        }
                    },
                    new(){
                        CarRegistrationNumber = "GD5678C",
                        CarBrand = "BMW",
                        CarName = "320d",
                        ProductionYear = 2016,
                        Engine = "2.0 Diesel",
                        OwnerTelephoneNumber = "601234567",
                        Repairs = new List<Repair>{
                            new()
                            {
                                DateOfFinalization = new DateOnly(2021, 12, 5),
                                TotalPrice = 800.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Turbocharger",
                                        Price = 500m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Turbocharger Replacement",
                                        Price = 300m,
                                    },

                                }

                            },
                            new(){
                                DateOfFinalization = new DateOnly(2023, 3, 20),
                                TotalPrice = 500.00m,
                                ReplacedCarParts = new List<CarPart>{
                                    new CarPart
                                    {
                                        Name = "Front Suspension",
                                        Price = 300m,
                                    },
                                    new CarPart
                                    {
                                        Name = "Rear Suspension",
                                        Price = 150m,
                                    },

                                },
                                MechanicalServices = new List<MechanicalService>{
                                    new MechanicalService{
                                        Name = "Replace front suspension",
                                        Price = 100m,
                                    },
                                    new MechanicalService{
                                        Name = "Replace rear suspension",
                                        Price = 150m,
                                    }

                                }

                            }
                        }
                    }
                }
                    }

            ];
        return workshops;

    }
    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new (UserRoles.Mechanic)
                {
                    NormalizedName = UserRoles.Mechanic.ToUpper(),
                },
                new (UserRoles.Admin)
                {
                    NormalizedName = UserRoles.WorkshopOwner.ToUpper(),
                },
                new (UserRoles.WorkshopOwner)
                {
                    NormalizedName = UserRoles.Admin.ToUpper(),
                },
            ];
        return roles;
    }







}
