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
    public class PlaneGetByIdService : IPlaneGetByIdService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlaneGetByIdService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PlaneUpsertDTO> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.Planes.GetById(id);
                var PlaneModel = _mapper.Map<PlaneUpsertDTO>(result);
                return PlaneModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
