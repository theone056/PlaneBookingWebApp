using AutoMapper;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.BookingService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.BookingService
{
    public class BookingReadService : IBookingReadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingReadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<BookingListDTO>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.Bookings.GetAll();
                var Bookings = _mapper.Map<List<BookingListDTO>>(result);
                return Bookings;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<BookingListDTO>> GetAllWithChildrenEntitites()
        {
            try
            {
                var result = await _unitOfWork.Bookings.GetBookingDetailsList();
                var newFlightModel = _mapper.Map<List<BookingListDTO>>(result);
                return newFlightModel;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
