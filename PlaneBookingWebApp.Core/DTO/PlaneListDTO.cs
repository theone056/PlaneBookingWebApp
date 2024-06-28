using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class PlaneListDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }
        [DisplayName("Airline")]
        public string Airline { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
    }
}
