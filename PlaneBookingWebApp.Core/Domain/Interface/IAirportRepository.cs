using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Interface
{
    public interface IAirportRepository : IGenericRepository<Airport>
    {
        Task<Airport> GetByName(string name);
    }
}
