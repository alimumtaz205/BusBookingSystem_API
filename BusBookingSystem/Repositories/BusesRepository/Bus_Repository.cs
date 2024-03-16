using BusBookingSystem.Common;
using BusBookingSystem.Models;
using BusBookingSystem.Models.UserModel;
using System.Data.SqlClient;
using System.Data;
using BusBookingSystem.Models.DTOs;
using BusBookingSystem.Models.BusModel;
using System.Runtime.InteropServices.JavaScript;

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

        public BaseResponse AddBus(BusDTO request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_AddBus", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                   cmd.Parameters.AddWithValue("@Bus_Name", request.BusName);
                   cmd.Parameters.AddWithValue("@Capacity", request.Capacity);
                   cmd.Parameters.AddWithValue("@BusNo", request.BusNo);
                   cmd.Parameters.AddWithValue("@BusType ", request.BusType);

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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = request };
        }

        public BaseResponse GetBusesData()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<Bus> ListData = new List<Bus>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetBusData", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@busID", "0");

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Bus obj = new Bus();

                            obj.BusID = Convert.ToInt32(dr["BusID"]);
                            obj.BusName = Convert.ToString(dr["Bus_Name"]);
                            obj.BusNo = Convert.ToString(dr["BusNo"]);
                            obj.Capacity = Convert.ToInt32(dr["Capacity"]);
                            obj.BusType = Convert.ToString(dr["BusType"]);
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

        public BaseResponse GetBuseByID(BusID BusID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<Bus> ListData = new List<Bus>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetBusData", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@busID", BusID.Bus_ID);

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Bus obj = new Bus();

                            obj.BusID = Convert.ToInt32(dr["BusID"]);
                            obj.BusName = Convert.ToString(dr["Bus_Name"]);
                            obj.BusNo = Convert.ToString(dr["BusNo"]);
                            obj.Capacity = Convert.ToInt32(dr["Capacity"]);
                            obj.BusType = Convert.ToString(dr["BusType"]);
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

        public BaseResponse DeleteBus(BusID BusID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_DeleteBus", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@busID", BusID.Bus_ID);

                    SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    Message = messageParameter.Value.ToString();

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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

        public BaseResponse UpdateBus(Bus request)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_UpdateBus", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                   cmd.Parameters.AddWithValue("@busID", request.BusID);
                   cmd.Parameters.AddWithValue("@newBusName", request.BusName);
                   cmd.Parameters.AddWithValue("@newBusCapacity", request.Capacity);
	               cmd.Parameters.AddWithValue("@newBusNo", request.BusNo);
                   cmd.Parameters.AddWithValue("@newBusType", request.BusType);

                    SqlParameter messageParameter = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 255);
                    messageParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Retrieve the output message
                    Message = messageParameter.Value.ToString();

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
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = "" };
        }

    }
}
