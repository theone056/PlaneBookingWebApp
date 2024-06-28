using PlaneBookingWebApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BaseInterface
{
    public interface IBaseUpdateService<T> where T : class
    {
        Task Update(T DTO);
    }
}
