namespace BusinessLayer.Services
{
  using BusinessLayer.Interfaces;
  using CommonLayer.Model;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using RepositoryLayer.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// This is the class of PartyBusiness.
  /// </summary>
  public class PartyBusiness : IPartyBusiness
  {
    private readonly IPartyRepository partyRL;
    public PartyBusiness(IPartyRepository partyRepository)
    {
      partyRL = partyRepository;
    }

    /// <summary>
    /// This is the class for Add party.
    /// </summary>
    /// <param name="partydata"></param>
    /// <returns></returns>
    public PartyresponseModel AddParty(Party partydata)
    {
      try
      {
        if (partydata != null)
        {
          return partyRL.AddParty(partydata);
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
    /// This is the method for get All party.
    /// </summary>
    /// <returns></returns>
    public IList<PartyresponseModel> GetAllParty()
    {
      try
      {
        return partyRL.GetAllParty();
      }
      catch (Exception)
      {
        throw;
      }
    }
    
    /// <summary>
    /// This is the method for delete party.
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns></returns>
    public string DeleteParty(int partyId)
    {
      try
      {
        if (partyId != 0)
        {
          return partyRL.DeleteParty(partyId);
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
    /// This is the method for update party.
    /// </summary>
    /// <param name="partyId"></param>
    /// <param name="partyRequestModel"></param>
    /// <returns></returns>
    public PartyresponseModel UpdateParty(int partyId, PartyRequestModel partyRequestModel)
    {
      try
      {
        if (partyId != 0)
        {
          return partyRL.UpdateParty(partyId, partyRequestModel);
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
    /// This the method for get party detail by id.
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns></returns>
    public PartyresponseModel GetPartyById(int partyId)
    {
      try
      {
        if (partyId != 0)
        {
          return partyRL.GetPartyById(partyId);
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
