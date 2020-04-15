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
  /// This is the class for User voting Repository.
  /// </summary>
  public class UserVotingRepository : IUserVotingRepository
  {
    private readonly IConfiguration _configuration;
    public UserVotingRepository(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    UserVotingResponse votingResponse;

    /// <summary>
    /// This is the method for add user votes.
    /// </summary>
    /// <param name="userVoting"></param>
    /// <returns></returns>
    public UserVotingResponse AddUserVotes(UserVotingRequest userVoting)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
        SqlCommand sqlCommand = new SqlCommand("sp_AddUserVotes", sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@FirstName", userVoting.FirstName);
        sqlCommand.Parameters.AddWithValue("@LastName", userVoting.LastName);
        sqlCommand.Parameters.AddWithValue("@MobileNumber", userVoting.MobileNumber);
        sqlCommand.Parameters.AddWithValue("@CandidateId", userVoting.CandidateId);
        sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
        sqlConnection.Open();
        SqlDataReader sdr = sqlCommand.ExecuteReader();
        while (sdr.Read())
        {
          votingResponse = new UserVotingResponse();
          votingResponse.UserId = Convert.ToInt32(sdr["UserId"]);
          votingResponse.FirstName = sdr["FirstName"].ToString();
          votingResponse.LastName = sdr["LastName"].ToString();
          votingResponse.MobileNumber = sdr["MobileNumber"].ToString();
          votingResponse.CandidateId = Convert.ToInt32(sdr["CandidateId"]);
          votingResponse.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]);
          votingResponse.ModifiedDate = Convert.ToDateTime(sdr["ModifiedDate"]);

        }
        sdr.Close();
        if (votingResponse != null)
        {
          return votingResponse;
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

    ConstituencyWiseResponse listConstituency;

    /// <summary>
    /// This is the method for getting result by Constituency wise.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <returns></returns>
    public IList<ConstituencyWiseResponse> GetConstituencyWiseResult(int ConstituencyId)
    {
      try
      {
        IList<ConstituencyWiseResponse> constituencyWiselist = new List<ConstituencyWiseResponse>();
        {
          SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
          SqlCommand sqlCommand = new SqlCommand("sp_ConstituencyWiseResult", sqlConnection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@ConstituencyId", ConstituencyId);
          sqlConnection.Open();
          SqlDataReader sdr = sqlCommand.ExecuteReader();
          while (sdr.Read())
          {
            listConstituency = new ConstituencyWiseResponse();
            listConstituency.FirstName = sdr["FirstName"].ToString();
            listConstituency.LastName = sdr["LastName"].ToString();
            listConstituency.partyName = sdr["partyName"].ToString();
            listConstituency.Votes = Convert.ToInt32(sdr["Votes"]);
            constituencyWiselist.Add(listConstituency);
          }
          sdr.Close();
          if (constituencyWiselist != null)
          {
            return constituencyWiselist;
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
    PartyWiseResponse partyWiseResponse;

    /// <summary>
    /// This is the method for showing partyWiseResponse.
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public IList<PartyWiseResponse> PartyWiseResponses(string State)
    {
      try
      {
        IList<PartyWiseResponse> partyWiseslist = new List<PartyWiseResponse>();
        {
          SqlConnection sqlConnection = new SqlConnection(_configuration["connectionstring:ElectionDb"]);
          SqlCommand sqlCommand = new SqlCommand("sp_partyWiseVotes", sqlConnection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@State", State);
          sqlConnection.Open();
          SqlDataReader sdr = sqlCommand.ExecuteReader();
          while (sdr.Read())
          {
            partyWiseResponse = new PartyWiseResponse();
            partyWiseResponse.partyName = sdr["partyName"].ToString();
            partyWiseResponse.Votes = Convert.ToInt32(sdr["Votes"]);
            partyWiseslist.Add(partyWiseResponse);
          }
          sdr.Close();
          if (partyWiseslist != null)
          {
            return partyWiseslist;
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
