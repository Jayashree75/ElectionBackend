namespace RepositoryLayer.Interfaces
{
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// This is the interface of candidate Repository.
  /// </summary>
  public interface ICandidateRepository
  {
    CandidateResponseModel AddCandidate(CandidateRequestModel requestModel);
    CandidateResponseModel UpdateCandidate(CandidateRequestModel requestModel, int CandidateId);
    string DeleteCandidate(int CandidateId);
    CandidateResponseModel GetCandidateById(int CandidateId);
    IList<CandidateResponseModel> GetAllCandidate();
  }
}
