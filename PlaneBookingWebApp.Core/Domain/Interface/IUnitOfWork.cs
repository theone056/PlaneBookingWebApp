using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAirportRepository Airports { get; }
        IBookingRepository Bookings { get; }
        IFlightRepository Flights{ get; }
        IPlaneRepository Planes { get; }
        Task Save();
    }
}
