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
  /// This is the class for constituency Business.
  /// </summary>
  public class ConstituencyBusiness : IConstituencyBusiness
  {
    private readonly IConstituencyRepository constituencyRL;
    public ConstituencyBusiness(IConstituencyRepository constituencyRepository)
    {
      constituencyRL = constituencyRepository;
    }

    /// <summary>
    /// This is the method for add constituency.
    /// </summary>
    /// <param name="constituencyRequestmodel"></param>
    /// <returns></returns>
    public ConstituencyResponseModel AddConstituency(ConstituencyRequestmodel constituencyRequestmodel)
    {
      try
      {
        if (constituencyRequestmodel != null)
        {
          return constituencyRL.AddConstituency(constituencyRequestmodel);
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
    /// This is the method for delete constituency.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <returns></returns>
    public string DeleteConstituency(int ConstituencyId)
    {
      try
      {
        if (ConstituencyId != 0)
        {
          return constituencyRL.DeleteConstituency(ConstituencyId);
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
    /// This is the method for update constituency.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <param name="constituencyUpdate"></param>
    /// <returns></returns>
    public ConstituencyResponseModel UpdateConstituency(int ConstituencyId, constituencyUpdate constituencyUpdate)
    {
      try
      {
        if (ConstituencyId != 0)
        {
          return constituencyRL.UpdateConstituency(ConstituencyId, constituencyUpdate);
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
    /// this is the method for get all constituency.
    /// </summary>
    /// <returns></returns>
    public IList<ConstituencyResponseModel> GetAllConstituency()
    {
      try
      {
        return constituencyRL.GetAllConstituency();
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// This is the get Constituencyby id.
    /// </summary>
    /// <param name="constituencyId"></param>
    /// <returns></returns>
    public ConstituencyResponseModel GetConstituencyById(int constituencyId)
    {
      try
      {
        if (constituencyId != 0)
        {
          return constituencyRL.GetConstituencyById(constituencyId);
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
