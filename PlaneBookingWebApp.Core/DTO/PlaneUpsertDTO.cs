using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class PlaneUpsertDTO
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Code")]
        public string Code { get; set; }
        [Required]
        [DisplayName("Airline")]
        public string Airline { get; set; }
        [DisplayName("Model")]
        [Required]
        public string Model { get; set; }
    }
}
