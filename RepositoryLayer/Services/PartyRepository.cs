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

  /// <summary>
  /// This is the class for party Repository.
  /// </summary>
  public class PartyRepository : IPartyRepository
  {
    private readonly IConfiguration _configuration;
    public PartyRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    PartyresponseModel partyresponse;

    /// <summary>
    /// This is the method for adding party.
    /// </summary>
    /// <param name="partydata"></param>
    /// <returns></returns>
    public PartyresponseModel AddParty(Party partydata)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_party", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@partyName", partydata.partyName);
        sqlCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@Query", 1);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          partyresponse = new PartyresponseModel();
          partyresponse.partyId = Convert.ToInt32(sdr["partyId"]);
          partyresponse.partyName = sdr["partyName"].ToString();
          partyresponse.createdDate = Convert.ToDateTime(sdr["createdDate"]);
          partyresponse.modifiedDate = Convert.ToDateTime(sdr["modifiedDate"]);
        }
        sdr.Close();
        if (partyresponse != null)
        {
          return partyresponse;

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
    /// This is the method for getting all party list.
    /// </summary>
    /// <returns></returns>
    public IList<PartyresponseModel> GetAllParty()
    {
      try
      {
        IList<PartyresponseModel> partylist = new List<PartyresponseModel>();
        {
          SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
          SqlCommand sqlCommand = new SqlCommand("sp_party", sqlConnection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@Query", 4);
          sqlConnection.Open();
          SqlDataReader sdr = sqlCommand.ExecuteReader();
          while (sdr.Read())
          {
            partyresponse = new PartyresponseModel();
            partyresponse.partyId = Convert.ToInt32(sdr["partyId"]);
            partyresponse.partyName = sdr["partyName"].ToString();
            partyresponse.createdDate = Convert.ToDateTime(sdr["createdDate"]);
            partyresponse.modifiedDate = Convert.ToDateTime(sdr["modifiedDate"]);
            partylist.Add(partyresponse);
          }
          sdr.Close();

          if (partylist != null)
          {
            return partylist;

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
    /// This is the method for delete party Record.
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns></returns>
    public string DeleteParty(int partyId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_party", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlConnection.Open();
        sqlCommand.Parameters.AddWithValue("@partyId", partyId);
        sqlCommand.Parameters.AddWithValue("@Query", 3);
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
    /// This is the method for Update Party.
    /// </summary>
    /// <param name="partyId"></param>
    /// <param name="partyRequestModel"></param>
    /// <returns></returns>
    public PartyresponseModel UpdateParty(int partyId, PartyRequestModel partyRequestModel)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_party", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@partyId", partyId);
        sqlCommand.Parameters.AddWithValue("@partyName", partyRequestModel.partyName);
        sqlCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@Query", 2);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          partyresponse = new PartyresponseModel();
          partyresponse.partyId = Convert.ToInt32(sdr["partyId"]);
          partyresponse.partyName = sdr["partyName"].ToString();
          partyresponse.createdDate = Convert.ToDateTime(sdr["createdDate"]);
          partyresponse.modifiedDate = Convert.ToDateTime(sdr["modifiedDate"]);

        }
        sdr.Close();

        if (partyresponse != null)
        {
          return partyresponse;

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
    /// This is the method for  get single record of party.
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns></returns>
    public PartyresponseModel GetPartyById(int partyId)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_party", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@partyId", partyId);
        sqlCommand.Parameters.AddWithValue("@Query", 5);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          partyresponse = new PartyresponseModel();
          partyresponse.partyId = Convert.ToInt32(sdr["partyId"]);
          partyresponse.partyName = sdr["partyName"].ToString();
          partyresponse.createdDate = Convert.ToDateTime(sdr["createdDate"]);
          partyresponse.modifiedDate = Convert.ToDateTime(sdr["modifiedDate"]);

        }
        sdr.Close();

        if (partyresponse != null)
        {
          return partyresponse;

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
  }
}

