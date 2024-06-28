using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
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
    public class BookingUpdateService : IBookingUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingUpdateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Update(BookingUpsertDTO BookingDTO)
        {
            try
            {
                var BookingModel = _mapper.Map<Booking>(BookingDTO);
                _unitOfWork.Bookings.Update(BookingModel);
                await _unitOfWork.Save();
            }
            catch (Exception ex) 
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
