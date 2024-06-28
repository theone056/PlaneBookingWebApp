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
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly PlaneBookingDbContext _context;
        public BookingRepository(PlaneBookingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllWithChildrenEntities()
        {
            try
            {
                return await _context.Bookings.Include(x => x.Flight).AsNoTracking().ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        public async Task<List<BookingDetails>> GetBookingDetailsList()
        {
            try
            {
                return await _context.Bookings.Select(x => new BookingDetails()
                {
                    Id = x.Id,
                    FlightCode = x.Flight.FlightCode,
                    Name = x.Name,
                }).AsNoTracking().ToListAsync();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
