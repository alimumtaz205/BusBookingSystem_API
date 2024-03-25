using BusBookingSystem.Models.BusModel;
using BusBookingSystem.Models;
using System.Data.SqlClient;
using System.Data;
using BusBookingSystem.Models.City;

namespace BusBookingSystem.Repositories.CityRepository
{
    public class CityRepository: ICityRepository
    {
        private readonly IConfiguration _configuration;
        bool isSuccess = false;
        string Message = string.Empty;
        ResCodes resCode = ResCodes.Exception;

        public CityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseResponse AddCity(CityDTO request)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_AddCity", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@City_Name", request.CityName);
                    cmd.Parameters.AddWithValue("@Country", request.Country);
                    cmd.Parameters.AddWithValue("@CreatedBy", "Admin");

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

        public BaseResponse GetCity()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<City> ListData = new List<City>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetCities", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@cityID", "0");

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            City obj = new City();

                            obj.CityID = Convert.ToInt32(dr["Id"]);
                            obj.CityName = (Convert.ToString(dr["City_Name"])).Trim();
                            obj.Country = (Convert.ToString(dr["Country"])).Trim();
                            ListData.Add(obj);
                        }
                    }
                    isSuccess = true;
                    Message = "Success";
                    con.Close();
                    
                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
                Message = "Failed";
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse GetCityID(City_ID CityID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;

            List<City> ListData = new List<City>();
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_GetCities", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@cityID", CityID.CityID);

                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    myDA.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            City obj = new City();

                            obj.CityID = Convert.ToInt32(dr["Id"]);
                            obj.Country = Convert.ToString(dr["Country"]);
                            obj.CityName = Convert.ToString(dr["City_Name"]);
                            ListData.Add(obj);
                        }
                    }
                    isSuccess = true;
                    Message = "Success";
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                }
                Message = "Failed";
            }
            return new BaseResponse { resCode = resCode, IsSuccess = isSuccess, Message = Message, Data = ListData };
        }

        public BaseResponse DeleteCity(City_ID CityID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_DeleteCity", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@cityID", CityID.CityID);

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

        public BaseResponse UpdateCity(City request)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(_configuration.GetConnectionString("CONN_STR"));

                using (SqlCommand cmd = new SqlCommand("sp_UpdateCity", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters
                    cmd.Parameters.AddWithValue("@cityID", request.CityID);
                    cmd.Parameters.AddWithValue("@cityName", request.CityName);

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
