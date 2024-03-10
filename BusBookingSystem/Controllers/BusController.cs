using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Repositories.BusesRepository;
using BusBookingSystem.Models.BusModel;

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
        [Route("AddBus")]
        public async Task<IActionResult> AddBus([FromBody] BusDTO request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _busRepository.AddBus(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllBuses")]
        public async Task<IActionResult> GetAllBuses()
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _busRepository.GetBusesData();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("GetBusByID")]
        public async Task<IActionResult> GetBusByID([FromBody]BusID BusID)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _busRepository.GetBuseByID(BusID);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeletBus")]
        public async Task<IActionResult> DeletBus([FromBody] BusID BusID)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _busRepository.DeleteBus(BusID);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateBus")]
        public async Task<IActionResult> UpdateBus([FromBody] Bus request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _busRepository.UpdateBus(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }

    }
}
