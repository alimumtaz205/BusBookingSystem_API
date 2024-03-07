namespace BusBookingSystem.Models
{
    public class Credentials
    {
        public string salt { get; set; }
        public string hashedPassword { get; set; }
    }
}
