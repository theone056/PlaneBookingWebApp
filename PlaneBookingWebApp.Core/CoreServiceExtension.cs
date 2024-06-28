using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PlaneBookingWebApp.Core.Mapper;
using PlaneBookingWebApp.Core.Services.AirportService;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using PlaneBookingWebApp.Core.Services.BookingService;
using PlaneBookingWebApp.Core.Services.BookingService.Interface;
using PlaneBookingWebApp.Core.Services.FlightService;
using PlaneBookingWebApp.Core.Services.FlightService.Interface;
using PlaneBookingWebApp.Core.Services.PlaneService;
using PlaneBookingWebApp.Core.Services.PlaneService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core
{
    public static class CoreServiceExtension
    {
        public static void ConfigureExtension(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<ApplicationMappingProfile>();
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddTransient<IAirportAddService,AirportAddService>();
            services.AddTransient<IAirportReadService,AirportReadService>();
            services.AddTransient<IAirportDeleteService,AirportDeleteService>();
            services.AddTransient<IAirportUpdateService,AirportUpdateService>();
            services.AddTransient<IAirportGetByIdService,AirportGetByIdService>();
            services.AddTransient<IBookingAddService, BookingAddService>();
            services.AddTransient<IBookingDeleteService,BookingDeleteService>();
            services.AddTransient<IBookingReadService,BookingReadService>();
            services.AddTransient<IBookingUpdateService,BookingUpdateService>();
            services.AddTransient<IBookingGetByIdService,BookingGetByIdService>();
            services.AddTransient<IFlightAddService,FlightAddService>();
            services.AddTransient<IFlightDeleteService,FlightDeleteService>();
            services.AddTransient<IFlightReadService,FlightReadService>();
            services.AddTransient<IFlightUpdateService,FlightUpdateService>();
            services.AddTransient<IFlightGetByIdService,FlightGetByIdService>();
            services.AddTransient<IPlaneAddService,PlaneAddService>();
            services.AddTransient<IPlaneDeleteService,PlaneDeleteService>();
            services.AddTransient<IPlaneReadService,PlaneReadService>();
            services.AddTransient<IPlaneUpdateService,PlaneUpdateService>();
            services.AddTransient<IPlaneGetByIdService, PlaneGetByIdService>();
        }
    }
}
