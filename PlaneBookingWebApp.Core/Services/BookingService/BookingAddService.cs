using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.BookingService.Interface;

namespace PlaneBookingWebApp.Core.Services.BookingService
{
    public class BookingAddService : IBookingAddService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingAddService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Add(BookingUpsertDTO BookingDTO)
        {
            if (BookingDTO is null) { throw new ArgumentNullException(nameof(BookingDTO)); }
            try
            {
                var BookingModel = _mapper.Map<Booking>(BookingDTO);
                await _unitOfWork.Bookings.Add(BookingModel);
                await _unitOfWork.Save();
                return true;
            }
            catch(Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
