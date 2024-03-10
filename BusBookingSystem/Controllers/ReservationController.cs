using BusBookingSystem.Models.BusModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories.BusesRepository;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Repositories.ReservationRepository;
using BusBookingSystem.Models.ReservationModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpPost]
        [Route("AddReservation")]
        public async Task<IActionResult> AddReservation([FromBody] ReservationDTO request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _reservationRepository.AddReservation(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("GetReservation")]
        public async Task<IActionResult> GetReservation([FromBody] Reservation_ID request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _reservationRepository.GetReservation(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("CancelReservation")]
        public async Task<IActionResult> CancelReservation([FromBody] Reservation_ID request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _reservationRepository.CancelReservation(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }


        [HttpPut]
        [Route("UpdateReservation")]
        public async Task<IActionResult> UpdateReservation([FromBody] Reservation request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _reservationRepository.UpdateReservation(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
