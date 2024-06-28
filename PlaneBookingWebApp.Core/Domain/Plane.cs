using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain
{
    public class Plane 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Airline { get; set; }
        public string Model { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
