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
  /// This is the class for candidate Business.
  /// </summary>
  public class CandidateBusiness : ICandidateBusiness
  {
    private readonly ICandidateRepository candidateRL;
    public CandidateBusiness(ICandidateRepository candidateRepository)
    {
      candidateRL = candidateRepository;
    }

    /// <summary>
    /// This is the method for Add Candidate.
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    public CandidateResponseModel AddCandidate(CandidateRequestModel requestModel)
    {
      try
      {
        if (requestModel != null)
        {
          return candidateRL.AddCandidate(requestModel);
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
        if (requestModel != null)
        {
          return candidateRL.UpdateCandidate(requestModel, CandidateId);
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
    /// This is the method for delete candidate.
    /// </summary>
    /// <param name="CandidateId"></param>
    /// <returns></returns>
    public string DeleteCandidate(int CandidateId)
    {
      try
      {
        if (CandidateId != 0)
        {
          return candidateRL.DeleteCandidate(CandidateId);
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
    /// This is the method for get candidate by id.
    /// </summary>
    /// <param name="CandidateId"></param>
    /// <returns></returns>
    public CandidateResponseModel GetCandidateById(int CandidateId)
    {
      try
      {
        if (CandidateId != 0)
        {
          return candidateRL.GetCandidateById(CandidateId);
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
    /// This is the method for get all candidate.
    /// </summary>
    /// <returns></returns>
    public IList<CandidateResponseModel> GetAllCandidate()
    {
      try
      {
        return candidateRL.GetAllCandidate();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
