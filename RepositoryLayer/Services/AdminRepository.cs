namespace RepositoryLayer.Services
{
  using CommonLayer.Model;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using Microsoft.Extensions.Configuration;
  using RepositoryLayer.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SqlClient;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// This is the class for Admin Repository.
  /// </summary>
  public class AdminRepository : IAdminRepository
  {
    private readonly IConfiguration _configuration;
    public AdminRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    AdminResponseModel responseModel;

    /// <summary>
    /// This is the Method for register admin.
    /// </summary>
    /// <param name="admin"></param>
    /// <returns></returns>
    public AdminResponseModel AdminRegister(Admin admin)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_Admin", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@FirstName", admin.FirstName);
        sqlCommand.Parameters.AddWithValue("@LastName", admin.LastName);
        sqlCommand.Parameters.AddWithValue("@MobileNumber", admin.MobileNumber);
        sqlCommand.Parameters.AddWithValue("@UserName", admin.UserName);
        sqlCommand.Parameters.AddWithValue("@Password", admin.Password);
        sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@Query", 1);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          responseModel = new AdminResponseModel();
          responseModel.AdminId = Convert.ToInt32(sdr["AdminId"]);
          responseModel.FirstName = sdr["FirstName"].ToString();
          responseModel.LastName = sdr["LastName"].ToString();
          responseModel.MobileNumber = sdr["MobileNumber"].ToString();
          responseModel.UserName = sdr["UserName"].ToString();
          responseModel.Password = sdr["Password"].ToString();
          responseModel.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
          responseModel.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);
        }
        sdr.Close();
        if (responseModel != null)
        {
          return responseModel;

        }
        else
        {
          return null;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// This is the method for Login.
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns></returns>
    public AdminResponseModel Login(AdminRequestModel loginModel)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_Admin", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@UserName", loginModel.UserName);
        sqlCommand.Parameters.AddWithValue("@Password", loginModel.Password);
        sqlCommand.Parameters.AddWithValue("@Query", 2);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          responseModel = new AdminResponseModel();
          responseModel.AdminId = Convert.ToInt32(sdr["AdminId"]);
          responseModel.FirstName = sdr["FirstName"].ToString();
          responseModel.LastName = sdr["LastName"].ToString();
          responseModel.MobileNumber = sdr["MobileNumber"].ToString();
          responseModel.UserName = sdr["UserName"].ToString();
          responseModel.Password = sdr["Password"].ToString();
          responseModel.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
          responseModel.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);

        }

        sdr.Close();
        if (responseModel != null)
        {
          return responseModel;

        }
        else
        {
          return null;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}