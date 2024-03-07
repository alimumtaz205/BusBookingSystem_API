using BusBookingSystem.Models;
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
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User request)
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User request)
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
    }
}
