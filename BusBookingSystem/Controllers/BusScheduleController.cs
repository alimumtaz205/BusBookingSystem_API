using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Repositories.BusesRepository;
using BusBookingSystem.Repositories.ScheduleRepository;
using BusBookingSystem.Models.RouteModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public BusScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpPost]
        [Route("GetScheduleData")]
        public async Task<IActionResult> GetScheduleData([FromBody] ReservationRequest request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _scheduleRepository.GetScheduleData(request, numberOfPassangers);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateSchedule")]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateReservation request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _scheduleRepository.CreateSchedule(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateSchedule")]
        public async Task<IActionResult> UpdateSchedule([FromBody] UpdateReservation request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _scheduleRepository.UpdateSchedule(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteSchedule")]
        public async Task<IActionResult> DeleteSchedule([FromBody] DeleteReservation request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _scheduleRepository.DeleteSchedule(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }


        [HttpPost]
        [Route("GetFare")]
        public async Task<IActionResult> GetFare([FromBody] FareModel request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _scheduleRepository.GetFare(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
