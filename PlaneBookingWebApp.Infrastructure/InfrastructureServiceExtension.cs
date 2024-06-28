using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Infrastructure.Context;
using PlaneBookingWebApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Infrastructure
{
    public static class InfrastructureServiceExtension
    {
        public static void ConfigureEntityFrameworkConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlaneBookingDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=PlaneBooking;Trusted_Connection=True;TrustServerCertificate=True");
            });
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.ConfigureEntityFrameworkConnection(configuration);
            services.ConfigureRepository();
        }
    }
}
