using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BaseInterface
{
    public interface IBaseGetByIdService<T> where T : class
    {
        Task<T> GetById(int id);
    }
}
