using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.Services.BookingService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BookingService
{
    public class BookingDeleteService : IBookingDeleteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingDeleteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                var result = await _unitOfWork.Bookings.Delete(Id);
                if (result)
                {
                    await _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex) 
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
