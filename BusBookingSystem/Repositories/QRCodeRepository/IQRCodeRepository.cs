using BusBookingSystem.Models.QRCodeModel;
using BusBookingSystem.Models;

namespace BusBookingSystem.Repositories.QRCodeRepository
{
    public interface IQRCodeRepository
    {
        public BaseResponse GenerateQRCode(QRCodeModel qRCode);
    }
}