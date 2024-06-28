using Microsoft.AspNetCore.Mvc;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.AirportService;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using PlaneBookingWebApp.Web.Models;

namespace PlaneBookingWebApp.Web.Controllers
{
    public class AirportController(IAirportReadService _airportReadService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new AirportIndexViewModel()
            {
                Airports = await _airportReadService.GetAll()
            });
        }
    }
}
