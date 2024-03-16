namespace BusBookingSystem.Models.RouteModel
{
    public class BusRoute
    {
        public int RouteID { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public decimal Distance { get; set; }
        public int EstimatedDuration { get; set; }
        public decimal BaseFare { get; set; }
    }
}
