using AutoMapper;
using PlaneBookingWebApp.Core.Domain;
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
    public class PlaneAddService : IPlaneAddService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlaneAddService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Add(PlaneUpsertDTO PlaneDTO)
        {
            if (PlaneDTO is null) { throw new ArgumentNullException(nameof(PlaneDTO)); }
            try
            {
                var findCode = await _unitOfWork.Planes.GetByCode(PlaneDTO.Code);
                if (findCode == null)
                {
                    var PlaneModel = _mapper.Map<Plane>(PlaneDTO);
                    await _unitOfWork.Planes.Add(PlaneModel);
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
