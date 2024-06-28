using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BaseInterface
{
    public interface IBaseDeleteService
    {
        Task<bool> Delete(int Id);
    }
}
