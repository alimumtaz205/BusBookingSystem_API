namespace BusBookingSystem.Models.QRCodeModel
{
    public class QRCodeModel
    {
        public int QRCodeID { get; set; }
        public int ReservationID { get; set; }
        public string? QRCodeData { get; set; }
    }
}
