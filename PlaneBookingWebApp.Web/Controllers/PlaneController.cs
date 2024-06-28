using Microsoft.AspNetCore.Mvc;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.PlaneService.Interface;
using PlaneBookingWebApp.Web.Models;

namespace PlaneBookingWebApp.Web.Controllers
{
    public class PlaneController(IPlaneReadService _planeReadService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new PlaneIndexViewModel()
            {
                Planes = await _planeReadService.GetAll()
            });
        }
    }
}
