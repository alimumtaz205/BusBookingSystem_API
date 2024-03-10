namespace BusBookingSystem.Models.RouteModel
{
    public class FareModel
    {
        public int RouteID { get; set; }
        public int BusID { get; set; }
    }

    public class FareOut
    {
        public decimal Fare { get; set; }
    }
}
