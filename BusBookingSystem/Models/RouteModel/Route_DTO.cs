namespace BusBookingSystem.Models.RouteModel
{
    public class Route_DTO
    {
        public class RouteRequest
        {
            public int RouteID { get; set; }
            public string? DepartureCity { get; set; }
            public string? ArrivalCity { get; set; }
            public decimal Distance { get; set; }
            public int EstimatedDuration { get; set; }
            public decimal BaseFare { get; set; }
        }

        public class CreateRoute
        {
            public string? DepartureCity { get; set; }
            public string? ArrivalCity { get; set; }
            public decimal Distance { get; set; }
            public int EstimatedDuration { get; set; }
            public decimal BaseFare { get; set; }
        }

        public class UpdateRoute
        {
            public int RouteID { get; set; }
            public string? DepartureCity { get; set; }
            public string? ArrivalCity { get; set; }
            public decimal Distance { get; set; }
            public int EstimatedDuration { get; set; }
            public decimal BaseFare { get; set; }
        }

        public class DeleteRoute
        {
            public int RouteID { get; set; }
        }
    }
}
