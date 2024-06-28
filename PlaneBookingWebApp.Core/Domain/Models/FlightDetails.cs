using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.Domain.Models
{
    public class FlightDetails
    {
        public int Id { get; set; }
        public string FlightCode { get; set; }
        public string AirportName { get; set; }
        public string PlaneName { get; set; }
    }
}
