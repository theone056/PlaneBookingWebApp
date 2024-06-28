using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using PlaneBookingWebApp.Core.Services.FlightService.Interface;
using PlaneBookingWebApp.Core.Services.PlaneService;
using PlaneBookingWebApp.Core.Services.PlaneService.Interface;
using System.Net;

namespace PlaneBookingWebApp.Web.Controllers.Ajax
{
    [Route("ajax/Flight")]
    public class _FlightController(IAirportReadService _airportReadService,
                                   IPlaneReadService _planeReadService,
                                   IFlightAddService _flightAddService,
                                   IFlightUpdateService _flightUpdateService,
                                   IFlightReadService _flightReadService,
                                   IFlightDeleteService _flightDeleteService,
                                   IFlightGetByIdService _flightGetByIdService) : Controller
    {

        [HttpGet]
        [Route("AddUpdateModal")]
        public async Task<IActionResult> AddUpdateModal()
        {
            ViewBag.AirportList = new SelectList(await _airportReadService.GetAll(), "Id", "Name");
            ViewBag.PlaneList = new SelectList(await _planeReadService.GetAll(), "Id", "Code");
            return PartialView("~/Views/Flight/_FlightAddUpdateModalContent.cshtml");
        }

        [Route("DeleteFlight")]
        public async Task<IActionResult> DeleteFlight(int Id)
        {
            var result = await _flightDeleteService.Delete(Id);
            if (result)
            {
                var AirportList = await _flightReadService.GetAllWithChildrenEntitites();
                return PartialView("~/Views/Flight/_FlightTable.cshtml", AirportList);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [HttpGet]
        [Route("UpdateFlightModal")]
        public async Task<IActionResult> UpdateFlightModal(int Id)
        {
            var result = await _flightGetByIdService.GetById(Id);
            if (result is not null)
            {
                ViewBag.AirportList = new SelectList(await _airportReadService.GetAll(), "Id", "Name");
                ViewBag.PlaneList = new SelectList(await _planeReadService.GetAll(), "Id", "Code");
                return PartialView("~/Views/Flight/_FlightAddUpdateModalContent.cshtml", result);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }


        [Route("AddUpdateFlight")]
        public async Task<IActionResult> AddUpdateFlight(FlightUpsertDTO flightDTO)
        {
            if (flightDTO.Id == 0)
            {
                var result = await _flightAddService.Add(flightDTO);
                if (result)
                {
                    var PlaneList = await _flightReadService.GetAllWithChildrenEntitites();
                    return PartialView("~/Views/Flight/_FlightTable.cshtml", PlaneList);
                }

                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else
            {
                await _flightUpdateService.Update(flightDTO);
                var PlaneList = await _flightReadService.GetAllWithChildrenEntitites();
                return PartialView("~/Views/Flight/_FlightTable.cshtml", PlaneList);
            }
        }
    }

  
}
