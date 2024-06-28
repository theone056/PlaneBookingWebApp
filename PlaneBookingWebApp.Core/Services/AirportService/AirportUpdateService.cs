using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.AirportService
{
    public class AirportUpdateService : IAirportUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AirportUpdateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Update(AirportUpsertDTO AirportDTO)
        {
            if(AirportDTO is null) throw new ArgumentNullException(nameof(AirportDTO));
            try
            {
                var AirportModel = _mapper.Map<Airport>(AirportDTO);
                _unitOfWork.Airports.Update(AirportModel);
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
