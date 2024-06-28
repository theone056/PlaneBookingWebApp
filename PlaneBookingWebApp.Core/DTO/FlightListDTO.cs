using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class FlightListDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Flight")]
        public string FlightCode { get; set; }
        [DisplayName("Airport Name")]
        public string AirportName { get; set; }
        [DisplayName("Plane")]
        public string PlaneName { get; set; }
    }
}
