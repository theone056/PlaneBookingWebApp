using Microsoft.EntityFrameworkCore;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Infrastructure.Context;
using PlaneBookingWebApp.Infrastructure.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Infrastructure.Repositories
{
    public class AirportRepository : GenericRepository<Airport>, IAirportRepository
    {
        private readonly PlaneBookingDbContext _context;

        public AirportRepository(PlaneBookingDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Airport> GetByName(string name)
        {
            try
            {
                var result = await _context.Airports.FirstOrDefaultAsync(x=>x.Name == name);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
