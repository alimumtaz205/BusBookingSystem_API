using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Repositories.BusesRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBus_Repository _busRepository;

        public BusController(IBus_Repository busRepository)
        {
            _busRepository = busRepository;
        }

        [HttpPost]
        [Route("GetScheduleData")]
        public async Task<IActionResult> GetScheduleData([FromBody] ReservationRequest request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _busRepository.GetScheduleData(request, numberOfPassangers);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateSchedule")]
        public async Task<IActionResult> CreateSchedule([FromBody] ReservationRequest request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                //response = _busRepository.CreateSchedule(request, numberOfPassangers);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
