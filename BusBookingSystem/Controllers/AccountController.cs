using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Repositories;

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Login([FromBody] Account account)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _accountRepository.Login(account);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
