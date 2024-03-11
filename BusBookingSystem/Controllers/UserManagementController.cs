using BusBookingSystem.Models.BusModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories;
using BusBookingSystem.Repositories.UserManagementRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Models.UserRoles;
using BusBookingSystem.Models.UserModel;

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserMgtRepository _userMgtRepository;

        public UserManagementController(IUserMgtRepository userMgtRepository)
        {
            _userMgtRepository = userMgtRepository;
        }

        [HttpPost]
        [Route("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] UserRole request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userMgtRepository.AssignRole(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody] User_ID request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _userMgtRepository.DeleteRole(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
