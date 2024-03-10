using BusBookingSystem.Models;
using BusBookingSystem.Models.BusModel;
using System.Data.SqlClient;
using System.Data;
using BusBookingSystem.Models.UserModel;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;
using System;
using BusBookingSystem.Models.ReservationModel;
using BusBookingSystem.Models.RouteModel;

namespace BusBookingSystem.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public ReservationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseResponse AddReservation(ReservationDTO request)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand command = new SqlCommand("sp_CreateReservation", con))
                {
                    con.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@UserID", request.UserID);
                    command.Parameters.AddWithValue("@ScheduleID", request.ScheduleID);
                    command.Parameters.AddWithValue("@BookingDateTime", request.BookingDateTime);
                    command.Parameters.AddWithValue("@Bus_Id", request.Bus_Id);
                    command.Parameters.AddWithValue("@Charges", request.Charges);
                    command.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                    command.Parameters.AddWithValue("@No_of_seats", request.No_of_seats);
                    command.Parameters.AddWithValue("@Seat_No", request.Seat_No);
                    command.Parameters.AddWithValue("@Additional_luggage", request.Additional_luggage);
                    command.Parameters.AddWithValue("@Additional_luggage_details", request.Additional_luggage_details);

                    SqlDataReader dr = command.ExecuteReader();
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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = request };
        }

        public BaseResponse GetReservation(Reservation_ID request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            List<Reservation> ListData = new List<Reservation>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetReservations", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@reservation_ID", request.ReservationID);
                    cmd.Parameters.AddWithValue("@userID", request.UserID);

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Reservation obj = new Reservation();

                            obj.ReservationID = Convert.ToInt32(dr["ReservationID"]);
                            obj.UserID = Convert.ToInt32(dr["UserID"]);
                            obj.ScheduleID = Convert.ToInt32(dr["ScheduleID"]);
                            obj.BookingDateTime = Convert.ToDateTime(dr["BookingDateTime"]);
                            obj.Bus_Id = Convert.ToInt32(dr["Bus_Id"]);
                            obj.Charges = Convert.ToInt32(dr["Charges"]);
                            obj.IsCancelled = Convert.ToBoolean(dr["IsCancelled"]);
                            obj.No_of_seats = Convert.ToInt32(dr["No_of_seats"]);
                            obj.Seat_No = Convert.ToString(dr["Seat_No"]);
                            obj.Additional_luggage = Convert.ToString(dr["Additional_luggage"]);
                            obj.Additional_luggage_details = Convert.ToString(dr["Additional_luggage_details"]);
                            ListData.Add(obj);
                        }
                    }

                    isSuccess = true;
                    con.Close();
                    resCode = ResCodes.Success;
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


        public BaseResponse CancelReservation(Reservation_ID request)
       {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand command = new SqlCommand("sp_CancelReservation", con))
                {
                    con.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@userID", request.UserID);
                    command.Parameters.AddWithValue("@reservation_ID", request.ReservationID);

                    SqlParameter messageParameter = command.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    // Retrieve the output message
                    Message = messageParameter.Value.ToString();

                    isSuccess = true;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = request };
        }

        public BaseResponse UpdateReservation(Reservation request)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand command = new SqlCommand("sp_UpdateReservation", con))
                {
                    con.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    command.Parameters.AddWithValue("@reservation_ID", request.ReservationID);
                    command.Parameters.AddWithValue("@userID", request.UserID);
	                command.Parameters.AddWithValue("@ScheduleID", request.ScheduleID);
                    command.Parameters.AddWithValue("@BookingDateTime", request.BookingDateTime);
	                command.Parameters.AddWithValue("@Bus_Id", request.Bus_Id);
                    command.Parameters.AddWithValue("@Charges", request.Charges);
                    command.Parameters.AddWithValue("@No_of_seats", request.No_of_seats);
                    command.Parameters.AddWithValue("@Seat_No", request.Seat_No);
	                command.Parameters.AddWithValue("@Additional_luggage", request.Additional_luggage);
                    command.Parameters.AddWithValue("@Additional_luggage_details", request.Additional_luggage_details);

                    SqlParameter messageParameter = command.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    // Retrieve the output message
                    Message = messageParameter.Value.ToString();

                    isSuccess = true;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = request };
        }


    }
}
