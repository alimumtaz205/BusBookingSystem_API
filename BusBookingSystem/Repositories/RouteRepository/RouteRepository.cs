using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models;
using System.Data.SqlClient;
using System.Data;
using static BusBookingSystem.Models.RouteModel.Route_DTO;
using BusBookingSystem.Models.RouteModel;

namespace BusBookingSystem.Repositories.RouteRepository
{
    public class RouteRepository: IRouteRepository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public RouteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseResponse GetRouteData()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<BusRoute> ListData = new List<BusRoute>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetBusRoute", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@routeID", "0");

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            BusRoute obj = new BusRoute();

                            obj.RouteID = Convert.ToInt32(dr["RouteID"]);
                            obj.DepartureCity = Convert.ToString(dr["DepartureCity"]);
                            obj.ArrivalCity = Convert.ToString(dr["ArrivalCity"]);
                            obj.Distance = Convert.ToDecimal(dr["Distance"]);
                            obj.EstimatedDuration = Convert.ToInt32(dr["EstimatedDuration"]);
                            obj.BaseFare = Convert.ToDecimal(dr["BaseFare"]);
                            ListData.Add(obj);
                            Message = "Success";
                        }
                    }
                    else
                    {
                        Message = "No Schedule found";
                    }
                    isSuccess = true;
                    resCode = ResCodes.Success;
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse GetRouteByID(DeleteRoute ID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<BusRoute> ListData = new List<BusRoute>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetBusRoute", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@routeID", ID.RouteID);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            BusRoute obj = new BusRoute();

                            obj.RouteID = Convert.ToInt32(dr["RouteID"]);
                            obj.DepartureCity = Convert.ToString(dr["DepartureCity"]);
                            obj.ArrivalCity = Convert.ToString(dr["ArrivalCity"]);
                            obj.Distance = Convert.ToDecimal(dr["Distance"]);
                            obj.EstimatedDuration = Convert.ToInt32(dr["EstimatedDuration"]);
                            obj.BaseFare = Convert.ToDecimal(dr["BaseFare"]);
                            ListData.Add(obj);
                            Message = "Success";
                        }
                    }
                    else
                    {
                        Message = "No Route found";
                    }
                    isSuccess = true;
                    resCode = ResCodes.Success;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse AddRoute(CreateRoute request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("[sp_CreateBusRoute]", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@DepartureCity", request.DepartureCity);
                    cmd.Parameters.AddWithValue("@ArrivalCity", request.ArrivalCity);
                    cmd.Parameters.AddWithValue("@Distance", request.Distance);
                    cmd.Parameters.AddWithValue("@EstimatedDuration", request.EstimatedDuration);

                    SqlParameter messageParameter = cmd.Parameters.Add("@ResultCode", SqlDbType.Int, 255);
                    messageParameter.Direction = ParameterDirection.Output;
                    SqlParameter messageParameter2 = cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255);
                    messageParameter2.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    Message = messageParameter2.Value.ToString();
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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

        public BaseResponse UpdateRoute(UpdateRoute request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_UpdateRoute", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters

                    cmd.Parameters.AddWithValue("@RouteID", request.RouteID);
                    cmd.Parameters.AddWithValue("@DepartureCity", request.DepartureCity);
                    cmd.Parameters.AddWithValue("@ArrivalCity", request.ArrivalCity);
                    cmd.Parameters.AddWithValue("@Distance", request.Distance);
                    cmd.Parameters.AddWithValue("@EstimatedDuration", request.EstimatedDuration);
                    cmd.Parameters.AddWithValue("@BaseFare", request.BaseFare);

                    SqlParameter messageParameter = cmd.Parameters.Add("@ResultCode", SqlDbType.Int, 255);
                    messageParameter.Direction = ParameterDirection.Output;
                    SqlParameter messageParameter2 = cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 255);
                    messageParameter2.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    Message = messageParameter2.Value.ToString();
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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

        public BaseResponse DeleteRoute(DeleteRoute request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_DeleteRoute", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@RouteID", request.RouteID);

                    SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

    }
}
