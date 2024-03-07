namespace BusBookingSystem.Models
{
    public class BaseResponse
    {
        public ResCodes resCode { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
