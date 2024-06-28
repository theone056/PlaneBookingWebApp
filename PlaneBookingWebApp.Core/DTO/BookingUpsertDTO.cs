using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class BookingUpsertDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Flight")]
        [Required]
        public int FlightId { get; set; }
    }
}
