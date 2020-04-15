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
  /// This is the candidate Repository class.
  /// </summary>
  public class CandidateRepository : ICandidateRepository
  {
    private readonly IConfiguration _configuration;
    public CandidateRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    CandidateResponseModel CandidateResponse;

    /// <summary>
    /// This is the method for add candidate.
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    public CandidateResponseModel AddCandidate(CandidateRequestModel requestModel)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_CandidateJoin", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@FirstName", requestModel.FirstName);
        sqlCommand.Parameters.AddWithValue("@LastName", requestModel.LastName);
        sqlCommand.Parameters.AddWithValue("@partyId", requestModel.partyId);
        sqlCommand.Parameters.AddWithValue("@ConstituencyId", requestModel.ConstituencyId);
        sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          CandidateResponse = new CandidateResponseModel();
          CandidateResponse.CandidateId = Convert.ToInt32(sdr["CandidateId"]);
          CandidateResponse.FirstName = sdr["FirstName"].ToString();
          CandidateResponse.LastName = sdr["LastName"].ToString();
          CandidateResponse.partyId = Convert.ToInt32(sdr["partyId"]);
          CandidateResponse.partyName = sdr["partyName"].ToString();
          CandidateResponse.ConstituencyId = Convert.ToInt32(sdr["ConstituencyId"]);
          CandidateResponse.Name = sdr["Name"].ToString();
          CandidateResponse.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
          CandidateResponse.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);
        }
        sdr.Close();
        if (CandidateResponse != null)
        {
          return CandidateResponse;
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
    /// This is the method for Update candidate.
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    public CandidateResponseModel UpdateCandidate(CandidateRequestModel requestModel,int CandidateId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_UpdateCandidate", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateId", CandidateId);
        sqlCommand.Parameters.AddWithValue("@FirstName", requestModel.FirstName);
        sqlCommand.Parameters.AddWithValue("@LastName", requestModel.LastName);
        sqlCommand.Parameters.AddWithValue("@partyId", requestModel.partyId);
        sqlCommand.Parameters.AddWithValue("@ConstituencyId", requestModel.ConstituencyId);
        sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          CandidateResponse = new CandidateResponseModel();
          CandidateResponse.CandidateId = Convert.ToInt32(sdr["CandidateId"]);
          CandidateResponse.FirstName = sdr["FirstName"].ToString();
          CandidateResponse.LastName = sdr["LastName"].ToString();
          CandidateResponse.partyId = Convert.ToInt32(sdr["partyId"]);
          CandidateResponse.partyName = sdr["partyName"].ToString();
          CandidateResponse.ConstituencyId = Convert.ToInt32(sdr["ConstituencyId"]);
          CandidateResponse.Name = sdr["Name"].ToString();
          CandidateResponse.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
          CandidateResponse.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);
         
          

        }
        sdr.Close();
        if (CandidateResponse != null)
        {
          return CandidateResponse;
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
    /// This is the method for delete the candidate.
    /// </summary>
    /// <param name="CandidateId"></param>
    /// <returns></returns>
    public string DeleteCandidate(int CandidateId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_DeleteCandidate", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlConnection.Open();
        sqlCommand.Parameters.AddWithValue("@CandidateId", CandidateId);
        sqlCommand.Parameters.AddWithValue("@Query", 1);
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
    /// This is the method for get candidate by id.
    /// </summary>
    /// <param name="CandidateId"></param>
    /// <returns></returns>
    public CandidateResponseModel GetCandidateById(int CandidateId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_DeleteCandidate", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@CandidateId", CandidateId);
        sqlCommand.Parameters.AddWithValue("@Query", 2);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          CandidateResponse = new CandidateResponseModel();
          CandidateResponse.CandidateId = Convert.ToInt32(sdr["CandidateId"]);
          CandidateResponse.FirstName = sdr["FirstName"].ToString();
          CandidateResponse.LastName = sdr["LastName"].ToString();
          CandidateResponse.partyId = Convert.ToInt32(sdr["partyId"]);
          CandidateResponse.partyName = sdr["partyName"].ToString();
          CandidateResponse.ConstituencyId = Convert.ToInt32(sdr["ConstituencyId"]);
          CandidateResponse.Name = sdr["Name"].ToString();
          CandidateResponse.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
          CandidateResponse.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);

        }
        sdr.Close();
        if (CandidateResponse != null)
        {
          return CandidateResponse;
        }
        else
        {
          return null;
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    /// <summary>
    /// This is the method for gettting the all candidate list.
    /// </summary>
    /// <returns></returns>
    public IList<CandidateResponseModel> GetAllCandidate()
    {
      try
      {
        IList<CandidateResponseModel> candidatelist = new List<CandidateResponseModel>();
        {
          SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
          SqlCommand sqlCommand = new SqlCommand("sp_DeleteCandidate", sqlConnection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@Query", 3);
          sqlConnection.Open();
          SqlDataReader sdr = sqlCommand.ExecuteReader();
          while (sdr.Read())
          {
            CandidateResponse = new CandidateResponseModel();
            CandidateResponse.CandidateId = Convert.ToInt32(sdr["CandidateId"]);
            CandidateResponse.FirstName = sdr["FirstName"].ToString();
            CandidateResponse.LastName = sdr["LastName"].ToString();
            CandidateResponse.partyId = Convert.ToInt32(sdr["partyId"]);
            CandidateResponse.ConstituencyId = Convert.ToInt32(sdr["ConstituencyId"]);
            CandidateResponse.Name = sdr["Name"].ToString();
            CandidateResponse.partyName = sdr["partyName"].ToString();
            CandidateResponse.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
            CandidateResponse.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);
            candidatelist.Add(CandidateResponse);
          }
          sdr.Close();
          if (candidatelist != null)
          {
            return candidatelist;
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
  }
}