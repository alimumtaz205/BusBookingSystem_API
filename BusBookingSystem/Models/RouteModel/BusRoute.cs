namespace BusBookingSystem.Models.RouteModel
{
    public class BusRoute
    {
        public int RouteID { get; set; }
        public string? DepartureStation { get; set; }
        public string? ArrivalStation { get; set; }
        public decimal Distance { get; set; }
        public int EstimatedDuration { get; set; }
    }
}
