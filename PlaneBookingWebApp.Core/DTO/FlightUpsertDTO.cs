using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class FlightUpsertDTO
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Flight")]
        public string FlightCode { get; set; }
        [Required]
        [DisplayName("Plane")]
        public int PlaneId { get; set; }
        [Required]
        [DisplayName("Airport Name")]
        public int AirportId { get; set; } = 1;
    }
}
