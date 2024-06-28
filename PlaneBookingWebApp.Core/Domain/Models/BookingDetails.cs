using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlightCode { get; set; }
    }
}
