using PlaneBookingWebApp.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Interface
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        Task<List<Flight>> GetAllWithChildrenEntities();
        Task<Flight> GetByCode(string code);
        Task<List<FlightDetails>> GetFlightDetailsList();
    }
}
