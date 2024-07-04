using AutoMapper;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;
using CarRepairWorkshops.Domain.Entities;


namespace CarRepairWorkshops.Application.CarRepairWorkshops.DTOs
{
    public class CarRepairWorkshopProfile : Profile
    {
        public CarRepairWorkshopProfile() {

            CreateMap<CreateWorkshopCommand, CarRepairWorkshop>()
                .ForMember(w => w.Address, opt => opt.MapFrom(
                    src => new Address
                    {
                        City = src.City,
                        Street = src.Street,
                        PostalCode = src.PostalCode,

                    }));






        }

    }
}
