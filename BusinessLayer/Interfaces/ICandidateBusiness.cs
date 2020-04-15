namespace BusinessLayer.Interfaces
{
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;


  public interface ICandidateBusiness
  {
    CandidateResponseModel AddCandidate(CandidateRequestModel requestModel);
    CandidateResponseModel UpdateCandidate(CandidateRequestModel requestModel,int CandidateId);
    string DeleteCandidate(int CandidateId);
    CandidateResponseModel GetCandidateById(int CandidateId);
    IList<CandidateResponseModel> GetAllCandidate();
  }
}
