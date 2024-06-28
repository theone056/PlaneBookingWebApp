using AutoMapper;
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
    public class AirportReadService : IAirportReadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AirportReadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<AirportListDTO>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.Airports.GetAll();
                var AirportModel = _mapper.Map<List<AirportListDTO>>(result);
                return AirportModel;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AirportUpsertDTO> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.Airports.GetById(id);
                var AirportModel = _mapper.Map<AirportUpsertDTO>(result);
                return AirportModel;
            }
            catch(Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
