using PlaneBookingWebApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class BookingListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlightCode { get; set; }
    }
}
