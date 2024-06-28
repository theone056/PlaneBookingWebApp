using AutoMapper;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Services.AirportService
{
    public class AirportDeleteService : IAirportDeleteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AirportDeleteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                var result = await _unitOfWork.Airports.Delete(Id);
                if(result)
                {
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
