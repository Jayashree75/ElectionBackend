namespace BusinessLayer.Interfaces
{
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;


  public interface IConstituencyBusiness
  {
    ConstituencyResponseModel AddConstituency(ConstituencyRequestmodel constituencyRequestmodel);
    string DeleteConstituency(int ConstituencyId);
    ConstituencyResponseModel UpdateConstituency(int ConstituencyId, constituencyUpdate constituencyUpdate);
    IList<ConstituencyResponseModel> GetAllConstituency();
    ConstituencyResponseModel GetConstituencyById(int constituencyId);
  }
}
