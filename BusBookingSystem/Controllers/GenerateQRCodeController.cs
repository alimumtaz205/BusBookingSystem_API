using BusBookingSystem.Models.UserModel;
using BusBookingSystem.Models;
using BusBookingSystem.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Repositories.QRCodeRepository;
using BusBookingSystem.Models.QRCodeModel;
using QRCoder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateQRCodeController : ControllerBase
    {
        private readonly IQRCodeRepository _qrCodeRepository;

        public GenerateQRCodeController(IQRCodeRepository qRCodeRepository)
        {
                _qrCodeRepository = qRCodeRepository;
        }

        [HttpPost]
        [Route("GenerateQRCode")]
        public async Task<IActionResult> GenerateQRCode([FromBody] QRCodeModel request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                response = _qrCodeRepository.GenerateQRCode(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return Ok(response);
        }

    }
}
