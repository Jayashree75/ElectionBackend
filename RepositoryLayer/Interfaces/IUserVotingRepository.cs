namespace RepositoryLayer.Interfaces
{
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// This is the interface of user voting Repository.
  /// </summary>
  public interface IUserVotingRepository
  {
    UserVotingResponse AddUserVotes(UserVotingRequest userVoting);
    IList<ConstituencyWiseResponse> GetConstituencyWiseResult(int ConstituencyId);
    IList<PartyWiseResponse> PartyWiseResponses(string State);
  }
}
