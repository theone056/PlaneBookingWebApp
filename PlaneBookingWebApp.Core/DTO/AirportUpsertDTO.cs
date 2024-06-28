using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class AirportUpsertDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Airport Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Airport Address")]
        [Required]
        public string Address { get; set; }
    }
}
