using CommonLayer.RequestModel;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
  public interface IUserVotingBusiness
  {
    UserVotingResponse AddUserVotes(UserVotingRequest userVoting);
    IList<ConstituencyWiseResponse> GetConstituencyWiseResult(int ConstituencyId);
    IList<PartyWiseResponse> PartyWiseResponses(string State);
  }
}
