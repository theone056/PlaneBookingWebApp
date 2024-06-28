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
    public class FlightGetByIdService : IFlightGetByIdService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightGetByIdService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FlightUpsertDTO> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.Flights.GetById(id);
                var FlightModel = _mapper.Map<FlightUpsertDTO>(result);
                return FlightModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
