namespace RepositoryLayer.Services
{
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using Microsoft.Extensions.Configuration;
  using RepositoryLayer.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SqlClient;
  using System.Text;

  /// <summary>
  /// This is the class for ConstituencyRepository.
  /// </summary>
  public class ConstituencyRepo : IConstituencyRepository
  {

    private readonly IConfiguration _configuration;
    public ConstituencyRepo(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    ConstituencyResponseModel constituency;

    /// <summary>
    /// This is the method for add constituency.
    /// </summary>
    /// <param name="constituencyRequestmodel"></param>
    /// <returns></returns>
    public ConstituencyResponseModel AddConstituency(ConstituencyRequestmodel constituencyRequestmodel)
    {
      try
      {

        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_Constituency", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@Name", constituencyRequestmodel.Name);
        sqlCommand.Parameters.AddWithValue("@City", constituencyRequestmodel.City);
        sqlCommand.Parameters.AddWithValue("@State", constituencyRequestmodel.State);
        sqlCommand.Parameters.AddWithValue("@Query", 1);
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
          constituency = new ConstituencyResponseModel();
          constituency.ConstituencyId = Convert.ToInt32(reader["ConstituencyId"]);
          constituency.Name = reader["Name"].ToString();
          constituency.City = reader["City"].ToString();
          constituency.State = reader["State"].ToString();
          constituency.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]).ToLocalTime();
          constituency.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]).ToLocalTime();
        }
        reader.Close();
        if (constituency != null)
        {
          return constituency;

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
    /// This is the method for delete constituency.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <returns></returns>
    public string DeleteConstituency(int ConstituencyId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_Constituency", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlConnection.Open();
        sqlCommand.Parameters.AddWithValue("@ConstituencyId", ConstituencyId);
        sqlCommand.Parameters.AddWithValue("@Query", 2);
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return "Deleted";

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// This is the method for Update constituency.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <param name="constituencyUpdate"></param>
    /// <returns></returns>
    public ConstituencyResponseModel UpdateConstituency(int ConstituencyId, constituencyUpdate constituencyUpdate)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_Constituency", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ConstituencyId", ConstituencyId);
        sqlCommand.Parameters.AddWithValue("@Name", constituencyUpdate.Name);
        sqlCommand.Parameters.AddWithValue("@City", constituencyUpdate.City);
        sqlCommand.Parameters.AddWithValue("@State", constituencyUpdate.State);
        sqlCommand.Parameters.AddWithValue("@Query", 3);
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
          constituency = new ConstituencyResponseModel();
          constituency.ConstituencyId = Convert.ToInt32(reader["ConstituencyId"]);
          constituency.Name = reader["Name"].ToString();
          constituency.City = reader["City"].ToString();
          constituency.State = reader["State"].ToString();
          constituency.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]).ToLocalTime();
          constituency.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]).ToLocalTime();
        }
        reader.Close();
        if (constituency != null)
        {
          return constituency;

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
    /// This is the method for getting all constituency Result.
    /// </summary>
    /// <returns></returns>
    public IList<ConstituencyResponseModel> GetAllConstituency()
    {
      try
      {
        IList<ConstituencyResponseModel> constituencylist = new List<ConstituencyResponseModel>();
        {
          SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
          SqlCommand sqlCommand = new SqlCommand("sp_Constituency", sqlConnection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@Query", 4);
          sqlConnection.Open();
          SqlDataReader reader = sqlCommand.ExecuteReader();
          while (reader.Read())
          {
            constituency = new ConstituencyResponseModel();
            constituency.ConstituencyId = Convert.ToInt32(reader["ConstituencyId"]);
            constituency.Name = reader["Name"].ToString();
            constituency.City = reader["City"].ToString();
            constituency.State = reader["State"].ToString();
            constituency.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]).ToLocalTime();
            constituency.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]).ToLocalTime();
            constituencylist.Add(constituency);
          }
          reader.Close();

          if (constituencylist != null)
          {
            return constituencylist;

          }
          else
          {
            return null;
          }
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    /// <summary>
    /// This is the method for Get single constituency Record.
    /// </summary>
    /// <param name="constituencyId"></param>
    /// <returns></returns>
    public ConstituencyResponseModel GetConstituencyById(int constituencyId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_Constituency", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ConstituencyId", constituencyId);
        sqlCommand.Parameters.AddWithValue("@Query", 5);
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
          constituency = new ConstituencyResponseModel();
          constituency.ConstituencyId = Convert.ToInt32(reader["ConstituencyId"]);
          constituency.Name = reader["Name"].ToString();
          constituency.City = reader["City"].ToString();
          constituency.State = reader["State"].ToString();
          constituency.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]).ToLocalTime();
          constituency.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]).ToLocalTime();
        }
        if (constituency != null)
        {
          return constituency;
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
