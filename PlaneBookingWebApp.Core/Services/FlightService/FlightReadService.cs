using AutoMapper;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.FlightService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.FlightService
{
    public class FlightReadService : IFlightReadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightReadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<FlightListDTO>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.Flights.GetAll();
                var newFlightModel = _mapper.Map<List<FlightListDTO>>(result);

                return newFlightModel;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<FlightListDTO>> GetAllWithChildrenEntitites()
        {
            try
            {
                var result = await _unitOfWork.Flights.GetFlightDetailsList();
                var newFlightModel = _mapper.Map<List<FlightListDTO>>(result);
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
