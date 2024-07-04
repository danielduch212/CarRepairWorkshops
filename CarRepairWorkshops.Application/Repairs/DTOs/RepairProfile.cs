using AutoMapper;
using CarRepairWorkshops.Application.Repairs.Commands.AddReplacedCarPart;
using CarRepairWorkshops.Application.Repairs.Commands.AddService;
using CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Application.Repairs.DTOs;

public class RepairProfile : Profile

{
    public RepairProfile()
    {
        CreateMap<CreateRepairCommand, Repair>();
        CreateMap<AddReplacedCarPartCommand, CarPart>();
        CreateMap<AddServiceToRepairCommand, MechanicalService>();
        

    }

}
