using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.BookingService.Interface;
using PlaneBookingWebApp.Core.Services.FlightService.Interface;
using System.Net;

namespace PlaneBookingWebApp.Web.Controllers.Ajax
{
    [Route("ajax/Booking")]
    public class _BookingController(IFlightReadService _flightReadService,
                                    IBookingDeleteService _bookingDeleteService,
                                    IBookingReadService _bookingReadService,
                                    IBookingGetByIdService _bookingGetByIdService,
                                    IBookingAddService _bookingAddService,
                                    IBookingUpdateService _bookingUpdateService) : Controller
    {
        [HttpGet]
        [Route("AddUpdateModal")]
        public async Task<IActionResult> AddUpdateModal()
        {
            ViewBag.FlightList = new SelectList(await _flightReadService.GetAll(), "Id", "FlightCode");
            return PartialView("~/Views/Booking/_BookingAddUpdateModalContent.cshtml");
        }

        [Route("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(int Id)
        {
            var result = await _bookingDeleteService.Delete(Id);
            if (result)
            {
                var BookingList = await _bookingReadService.GetAllWithChildrenEntitites();
                return PartialView("~/Views/Booking/_BookingTable.cshtml", BookingList);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [HttpGet]
        [Route("UpdateBookingModal")]
        public async Task<IActionResult> UpdateBookingModal(int Id)
        {
            var result = await _bookingGetByIdService.GetById(Id);
            if (result is not null)
            {
                ViewBag.FlightList = new SelectList(await _flightReadService.GetAll(), "Id", "FlightCode");
                return PartialView("~/Views/Booking/_BookingAddUpdateModalContent.cshtml", result);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }


        [Route("AddUpdateBooking")]
        public async Task<IActionResult> AddUpdateBooking(BookingUpsertDTO bookingDTO)
        {
            if (bookingDTO.Id == 0)
            {
                var result = await _bookingAddService.Add(bookingDTO);
                if (result)
                {
                    var BookingList = await _bookingReadService.GetAllWithChildrenEntitites();
                    return PartialView("~/Views/Booking/_BookingTable.cshtml", BookingList);
                }

                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else
            {
                await _bookingUpdateService.Update(bookingDTO);
                var BookingList = await _bookingReadService.GetAllWithChildrenEntitites();
                return PartialView("~/Views/Booking/_BookingTable.cshtml", BookingList);
            }
        }
    }
}
