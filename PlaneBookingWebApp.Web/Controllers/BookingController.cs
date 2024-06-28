using Microsoft.AspNetCore.Mvc;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.BookingService.Interface;
using PlaneBookingWebApp.Web.Models;

namespace PlaneBookingWebApp.Web.Controllers
{
    public class BookingController(IBookingReadService _bookingReadService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new BookingIndexViewModel()
            {
                Bookings = await _bookingReadService.GetAllWithChildrenEntitites()
            });
        }
    }
}
