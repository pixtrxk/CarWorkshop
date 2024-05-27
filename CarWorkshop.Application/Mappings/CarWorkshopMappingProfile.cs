using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(s => new CarWorkshopContactDetails()
                {
                    PhoneNumber = s.PhoneNumber,
                    Street = s.Street,
                    City = s.City,
                    PostalCode = s.PostalCode,
                }));
            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(s => s.ContactDetails.PhoneNumber))
                .ForMember(e => e.Street, opt => opt.MapFrom(s => s.ContactDetails.Street))
                .ForMember(e => e.City, opt => opt.MapFrom(s => s.ContactDetails.City))
                .ForMember(e => e.City, opt => opt.MapFrom(s => s.ContactDetails.City));

		}
    }
}
