using PlaneBookingWebApp.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Interface
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<List<Booking>> GetAllWithChildrenEntities();
        Task<List<BookingDetails>> GetBookingDetailsList();
    }
}
