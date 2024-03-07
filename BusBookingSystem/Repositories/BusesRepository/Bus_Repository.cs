using BusBookingSystem.Common;
using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;
using System.Data.SqlClient;
using System.Data;
using BusBookingSystem.Models.DTOs;

namespace BusBookingSystem.Repositories.BusesRepository
{
    public class Bus_Repository: IBus_Repository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public Bus_Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseResponse GetScheduleData(ReservationRequest request,string numberOfPassangers)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<BusSchedule_DTO> ListData = new List<BusSchedule_DTO>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_SearchBusSchedule]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@departureCity", request.departureCity);
                    cmd.Parameters.AddWithValue("@arrivalCity", request.arrivalCity);
                    cmd.Parameters.AddWithValue("@departureTime", request.departureTime);
                    cmd.Parameters.AddWithValue("@numberOfPassangers", numberOfPassangers);

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);
                    
                     if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                BusSchedule_DTO obj = new BusSchedule_DTO();

                                obj.BusID = Convert.ToInt32(dr["BusID"]);
                                obj.RouteID = Convert.ToInt32(dr["RouteID"]);
                                obj.Bus_Name = Convert.ToString(dr["Bus_Name"]);
                                obj.Capacity = Convert.ToString(dr["Capacity"]);
                                obj.DepartureCity = Convert.ToString(dr["DepartureCity"]);
                                obj.ArrivalCity = Convert.ToString(dr["ArrivalCity"]);
                                obj.EstimatedDuration = Convert.ToInt32(dr["EstimatedDuration"]);
                                obj.DeparterDate = Convert.ToDateTime(dr["DeparterDate"]);
                                obj.DepartureTime = Convert.ToDateTime(dr["DepartureTime"]);
                                obj.ArrivalTime = Convert.ToDateTime(dr["ArrivalTime"]);
                                ListData.Add(obj);
                            }
                        }
                     isSuccess = true;
                    con.Close();
                    //tranCode = TranCodes.Success;
                }

            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse CreateSchedule(CreateReservation request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_CreateBusSchedule]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@BusID", request.busID);
                    cmd.Parameters.AddWithValue("@RouteID", request.routeID);
                    cmd.Parameters.AddWithValue("@DepartureTime", request.departureTime);
                    cmd.Parameters.AddWithValue("@ArrivalTime", request.departureTime);
                    cmd.Parameters.AddWithValue("@AvailableSeats", request.availableSeats);

                    SqlDataReader dr = cmd.ExecuteReader();
                    isSuccess = true;
                    Message = "Inserted Successfully";
                    con.Close();
                    //tranCode = TranCodes.Success;
                }

            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

    }
}
