using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Models;
using PlaneBookingWebApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Mapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<AirportListDTO, Airport>().ReverseMap();
            CreateMap<AirportUpsertDTO,Airport>().ReverseMap();
            CreateMap<PlaneListDTO, Plane>().ReverseMap();
            CreateMap<PlaneUpsertDTO, Plane>().ReverseMap();
            CreateMap<Flight, FlightListDTO>()
                .ForMember(dest=>dest.PlaneName, src=>src.MapFrom(x=>x.Plane.Airline))
                .ForMember(dest=>dest.AirportName, src=>src.MapFrom(x=>x.Airport.Name))
                .ReverseMap();
            CreateMap<FlightListDTO, FlightDetails>().ReverseMap();
            CreateMap<BookingListDTO, BookingDetails>().ReverseMap();
            CreateMap<FlightUpsertDTO, Flight>().ReverseMap();
            CreateMap<Booking, BookingListDTO>()
                .ForMember(dest=>dest.FlightCode, src=>src.MapFrom(x=>x.Flight.FlightCode)).ReverseMap();
            CreateMap<BookingUpsertDTO, Booking>().ReverseMap();    
        }
    }
}
