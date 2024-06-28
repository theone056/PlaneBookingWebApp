using Microsoft.AspNetCore.Mvc;
using PlaneBookingWebApp.Core.DTO;
using PlaneBookingWebApp.Core.Services.PlaneService.Interface;
using System.Net;

namespace PlaneBookingWebApp.Web.Controllers.Ajax
{
    [Route("ajax/Plane")]
    public class _PlaneController(IPlaneAddService _planeAddService,
                                  IPlaneUpdateService _planeUpdateService,
                                  IPlaneReadService _planeReadService,
                                  IPlaneDeleteService _planeDeleteService,
                                  IPlaneGetByIdService _planeGetByIdService) : Controller
    {
        [Route("AddUpdatePlane")]
        public async Task<IActionResult> AddUpdatePlane(PlaneUpsertDTO planeDTO)
        {
            if (planeDTO.Id == 0)
            {
                var result = await _planeAddService.Add(planeDTO);
                if (result)
                {
                    var PlaneList = await _planeReadService.GetAll();
                    return PartialView("~/Views/Plane/_PlaneTable.cshtml", PlaneList);
                }

                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            else
            {
                await _planeUpdateService.Update(planeDTO);
                var PlaneList = await _planeReadService.GetAll();
                return PartialView("~/Views/Plane/_PlaneTable.cshtml", PlaneList);
            }
        }

        [Route("DeleteAirport")]
        public async Task<IActionResult> DeletePlane(int Id)
        {
            var result = await _planeDeleteService.Delete(Id);
            if (result)
            {
                var AirportList = await _planeReadService.GetAll();
                return PartialView("~/Views/Plane/_PlaneTable.cshtml", AirportList);
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
            var result = await _planeGetByIdService.GetById(Id);
            if (result is not null)
            {
                return PartialView("~/Views/Plane/_PlaneAddUpdateModalContent.cshtml", result);
            }

            return new JsonResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        [HttpGet]
        [Route("AddUpdateModal")]
        public IActionResult AddUpdateModal()
        {
            return PartialView("~/Views/Plane/_PlaneAddUpdateModalContent.cshtml");
        }
    }
}
