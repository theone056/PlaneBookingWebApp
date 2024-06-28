using Microsoft.AspNetCore.Mvc;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.AirportService.Interface;
using System.Net;

namespace PlaneBookingWebApp.Web.Controllers.Ajax
{
    [Route("ajax/Airport")]
    public class _AirportController(IAirportAddService _airportAddService,
                                    IAirportReadService _airportReadService,
                                    IAirportUpdateService _airportUpdateService,
                                    IAirportGetByIdService _airportGetByIdService,
                                    IAirportDeleteService _airportDeleteService) : Controller
    {
        [Route("AddUpdateAirport")]
        public async Task<IActionResult> AddUpdateAirport(AirportUpsertDTO airportDTO)
        {
            if (airportDTO.Id == 0)
            {
                var result = await _airportAddService.Add(airportDTO);
                if (result)
                {
                    var AirportList = await _airportReadService.GetAll();
                    return PartialView("~/Views/Airport/_AirportTable.cshtml", AirportList);
                }

                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else
            {
                await _airportUpdateService.Update(airportDTO);
                var AirportList = await _airportReadService.GetAll();
                return PartialView("~/Views/Airport/_AirportTable.cshtml", AirportList);
            }
        }

        [Route("DeleteAirport")]
        public async Task<IActionResult> DeleteAirport(int Id)
        {
            var result = await _airportDeleteService.Delete(Id);
            if (result)
            {
                var AirportList = await _airportReadService.GetAll();
                return PartialView("~/Views/Airport/_AirportTable.cshtml", AirportList);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [HttpGet]
        [Route("UpdateAirportModal")]
        public async Task<IActionResult> UpdateAirportModal(int Id)
        {
            var result = await _airportGetByIdService.GetById(Id);
            if (result is not null)
            {
                return PartialView("~/Views/Airport/_AirportAddUpdateModalContent.cshtml", result);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [HttpGet]
        [Route("AddAirportModal")]
        public IActionResult AddAirportModal()
        {

           return PartialView("~/Views/Airport/_AirportAddUpdateModalContent.cshtml");
        }
    }
}
