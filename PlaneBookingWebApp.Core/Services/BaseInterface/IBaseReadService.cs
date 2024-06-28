using PlaneBookingWebApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BaseInterface
{
    public interface IBaseReadService<T> where T : class
    {
        Task<List<T>> GetAll();
    }
}
