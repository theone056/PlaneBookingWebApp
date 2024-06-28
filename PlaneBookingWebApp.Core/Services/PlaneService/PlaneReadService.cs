using AutoMapper;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.PlaneService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.PlaneService
{
    public class PlaneReadService : IPlaneReadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlaneReadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<PlaneListDTO>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.Planes.GetAll();
                var Planes = _mapper.Map<List<PlaneListDTO>>(result);
                return Planes;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
