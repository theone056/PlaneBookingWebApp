using AutoMapper;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.Services.PlaneService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.PlaneService
{
    public class PlaneDeleteService : IPlaneDeleteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlaneDeleteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                var result = await _unitOfWork.Planes.Delete(Id);
                if (result)
                {
                    await _unitOfWork.Save();
                    _unitOfWork.Dispose();
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
