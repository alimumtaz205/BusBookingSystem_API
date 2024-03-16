using BusBookingSystem.Models;
using Microsoft.Extensions.Configuration;
using static BusBookingSystem.Models.RouteModel.Route_DTO;
using System.Data.SqlClient;
using System.Data;

namespace BusBookingSystem.Repositories.RouteRepository
{
    public interface IRouteRepository
    {
        public BaseResponse GetRouteData();
        public BaseResponse GetRouteByID(DeleteRoute ID);
        public BaseResponse AddRoute(CreateRoute request);
        public BaseResponse UpdateRoute(UpdateRoute request);
        public BaseResponse DeleteRoute(DeleteRoute request);

    }
}