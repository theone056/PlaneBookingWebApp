using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;

namespace PlaneBookingWebApp.Core.Services.AirportService
{
    public class AirportAddService : IAirportAddService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AirportAddService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Add(AirportUpsertDTO AirportDTO)
        {
            if (AirportDTO is null) { throw new ArgumentNullException(nameof(AirportDTO)); }
            try
            {
                var searchAirport = await _unitOfWork.Airports.GetByName(AirportDTO.Name);
                if (searchAirport is null)
                {
                    var airportModel = _mapper.Map<Airport>(AirportDTO);
                    await _unitOfWork.Airports.Add(airportModel);
                    await _unitOfWork.Save();
                    return true;
                }

                return false;

            }
            catch(Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
