using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
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
    public class FlightAddService : IFlightAddService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightAddService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Add(FlightUpsertDTO FlightDTO)
        {
            if (FlightDTO is null) { throw new ArgumentNullException(nameof(FlightDTO)); }
            try
            {
                var searchFlight = await _unitOfWork.Flights.GetByCode(FlightDTO.FlightCode);
                if (searchFlight == null)
                {
                    var FlightModel = _mapper.Map<Flight>(FlightDTO);
                    await _unitOfWork.Flights.Add(FlightModel);
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
