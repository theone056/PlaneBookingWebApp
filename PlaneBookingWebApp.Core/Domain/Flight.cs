using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightCode { get; set; }

        [ForeignKey(nameof(Plane))]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        [ForeignKey(nameof(Airport))]
        public int AirportId { get; set; }
        public Airport Airport { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
