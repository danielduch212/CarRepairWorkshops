using AutoMapper;
using CarRepairWorkshops.Application.Cars.Commands.CreateCar;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Application.Cars.DTOs;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CreateCarCommand, Car>();
    }
}
