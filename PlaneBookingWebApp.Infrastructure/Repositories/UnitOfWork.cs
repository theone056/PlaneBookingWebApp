using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PlaneBookingDbContext _context;
        public IAirportRepository Airports { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IFlightRepository Flights { get; private set; }
        public IPlaneRepository Planes { get; private set; }

        public UnitOfWork(PlaneBookingDbContext context)
        {
            _context = context;
            Airports = new AirportRepository(_context);
            Bookings = new BookingRepository(_context);
            Flights = new FlightRepository(_context);
            Planes = new PlaneRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
