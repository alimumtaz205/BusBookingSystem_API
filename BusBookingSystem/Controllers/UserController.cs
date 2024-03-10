using BusBookingSystem.Models;
using BusBookingSystem.Models.BusModel;
using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
             _userRepository = userRepository;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userRepository.CreateUser(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUsers()
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById([FromBody] User_ID request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userRepository.GetUserByID(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userRepository.UpdateUser(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }


        [HttpDelete]
        [Route("DeletUser")]
        public async Task<IActionResult> DeletUser([FromBody] User_ID request)
        {
            string numberOfPassangers = string.Empty;
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userRepository.DeleteUser(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] User request)
        //{
        //    BaseResponse response = new BaseResponse();
        //    try
        //    {
        //        response = _userRepository.CreateUser(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message.ToString();
        //    }

        //    return Ok(response);
        //}

    }
}
