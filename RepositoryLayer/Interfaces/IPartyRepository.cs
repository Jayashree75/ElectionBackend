namespace RepositoryLayer.Interfaces
{
  using CommonLayer.Model;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// This is the interface of party Repository.
  /// </summary>
  public interface IPartyRepository
  {
    PartyresponseModel AddParty(Party partydata);
    IList<PartyresponseModel> GetAllParty();
    string DeleteParty(int partyId);
    PartyresponseModel UpdateParty(int partyId, PartyRequestModel partyRequestModel);
    PartyresponseModel GetPartyById(int partyId);
  }
}
