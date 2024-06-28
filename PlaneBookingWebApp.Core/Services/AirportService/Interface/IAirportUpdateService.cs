using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.AirportService.Interface
{
    public interface IAirportUpdateService : IBaseUpdateService<AirportUpsertDTO>
    {

    }
}
