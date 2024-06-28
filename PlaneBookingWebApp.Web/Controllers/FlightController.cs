using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using PlaneBookingWebApp.Core.Services.FlightService.Interface;
using PlaneBookingWebApp.Web.Models;

namespace PlaneBookingWebApp.Web.Controllers
{
    public class FlightController(IFlightReadService _flightReadService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new FlightIndexViewModel()
            {
                Flights = await _flightReadService.GetAllWithChildrenEntitites()
            });
        }
    }
}
