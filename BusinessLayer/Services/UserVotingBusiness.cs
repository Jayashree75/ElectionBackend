namespace BusinessLayer.Services
{
  using BusinessLayer.Interfaces;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using RepositoryLayer.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// This is the class for UserVotingBusiness.
  /// </summary>
  public class UserVotingBusiness : IUserVotingBusiness
  {
    private readonly IUserVotingRepository userVotingRL;
    public UserVotingBusiness(IUserVotingRepository userVotingRepository)
    {
      userVotingRL = userVotingRepository;
    }

    /// <summary>
    /// this is the method for add user votes.
    /// </summary>
    /// <param name="userVoting"></param>
    /// <returns></returns>
    public UserVotingResponse AddUserVotes(UserVotingRequest userVoting)
    {
      try
      {
        if (userVoting != null)
        {
          return userVotingRL.AddUserVotes(userVoting);
        }
        else
        {
          return null;
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// This is the method for getting Constituency wise result.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <returns></returns>
    public IList<ConstituencyWiseResponse> GetConstituencyWiseResult(int ConstituencyId)
    {
      try
      {
        if (ConstituencyId != 0)
        {
          return userVotingRL.GetConstituencyWiseResult(ConstituencyId);
        }
        else
        {
          return null;
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// This is the method for getting result by partyWise.
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public IList<PartyWiseResponse> PartyWiseResponses(string State)
    {
      try
      {
        if (State != null)
        {
          return userVotingRL.PartyWiseResponses(State);
        }
        else
        {
          return null;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
