using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Interface
{
    public interface IPlaneRepository : IGenericRepository<Plane>
    {
        Task<Plane> GetByCode(string code);
    }
}
