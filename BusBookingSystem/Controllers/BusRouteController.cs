using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static BusBookingSystem.Models.RouteModel.Route_DTO;
using BusBookingSystem.Repositories.RouteRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;
        public BusRouteController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        [HttpGet]
        [Route("GetRouteData")]
        public async Task<IActionResult> GetRouteData()
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _routeRepository.GetRouteData();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("GetRouteByID")]
        public async Task<IActionResult> GetRouteByID([FromBody] DeleteRoute request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _routeRepository.GetRouteByID(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("AddRoute")]
        public async Task<IActionResult> AddRoute([FromBody] CreateRoute request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _routeRepository.AddRoute(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateRoute")]
        public async Task<IActionResult> UpdateRoute([FromBody] UpdateRoute request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _routeRepository.UpdateRoute(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRoute")]
        public async Task<IActionResult> DeleteRoute([FromBody] DeleteRoute request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _routeRepository.DeleteRoute(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
