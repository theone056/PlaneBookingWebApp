using Microsoft.EntityFrameworkCore;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Core.Domain.Interface;
using PlaneBookingWebApp.Infrastructure.Context;
using PlaneBookingWebApp.Infrastructure.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Infrastructure.Repositories
{
    public class PlaneRepository : GenericRepository<Plane>, IPlaneRepository
    {
        private readonly PlaneBookingDbContext _context;

        public PlaneRepository(PlaneBookingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Plane> GetByCode(string code)
        {
            try
            {
                var result = await _context.Planes.FirstOrDefaultAsync(x => x.Code == code);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
