using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Core.DTO
{
    public class AirportListDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Airport Name")]
        public string Name { get; set; }
        [DisplayName("Airport Address")]
        public string Address { get; set; }
    }
}
