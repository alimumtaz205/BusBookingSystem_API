using BusBookingSystem.Models.BusModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories.BusesRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Repositories.CityRepository;
using BusBookingSystem.Models.City;

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpPost]
        [Route("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] CityDTO request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _cityRepository.AddCity(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _cityRepository.GetCity();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("GetCityID")]
        public async Task<IActionResult> GetCityID([FromBody] City_ID Id)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _cityRepository.GetCityID(Id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCity")]
        public async Task<IActionResult> DeleteCity([FromBody] City_ID Id)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _cityRepository.DeleteCity(Id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromBody] City request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _cityRepository.UpdateCity(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }
    }
}
