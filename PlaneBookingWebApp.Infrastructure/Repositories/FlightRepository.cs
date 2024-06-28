using Microsoft.EntityFrameworkCore;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.Domain.Models;
using PlaneBookingWebApp.Infrastructure.Context;
using PlaneBookingWebApp.Infrastructure.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Infrastructure.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        private readonly PlaneBookingDbContext _context;
        public FlightRepository(PlaneBookingDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllWithChildrenEntities()
        {
            return await _context.Flights.Include(x=>x.Plane).Include(x=>x.Airport).AsNoTracking().ToListAsync();
        }

        public async Task<Flight> GetByCode(string code)
        {
            try
            {
                var result = await _context.Flights.FirstOrDefaultAsync(x => x.FlightCode == code);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<FlightDetails>> GetFlightDetailsList()
        {
            try
            {
                return await _context.Flights.Select(x=>new FlightDetails()
                {
                    Id = x.Id,
                    AirportName = x.Airport.Name,
                    FlightCode = x.FlightCode,
                    PlaneName = x.Plane.Airline
                }).AsNoTracking().ToListAsync();
            }
            catch (Exception ex) 
            { 
                throw new Exception($"{ex.Message}", ex);   
            }
            
        }
    }
}
