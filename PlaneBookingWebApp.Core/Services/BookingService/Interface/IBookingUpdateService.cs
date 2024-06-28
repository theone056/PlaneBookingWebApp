using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BookingService.Interface
{
    public interface IBookingUpdateService : IBaseUpdateService<BookingUpsertDTO>
    {

    }
}
