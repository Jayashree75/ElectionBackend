namespace RepositoryLayer.Interfaces
{
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// This is the interface of constituency REpository.
  /// </summary>
  public interface IConstituencyRepository
  {
    ConstituencyResponseModel AddConstituency(ConstituencyRequestmodel constituencyRequestmodel);
    string DeleteConstituency(int ConstituencyId);
    ConstituencyResponseModel UpdateConstituency(int ConstituencyId, constituencyUpdate constituencyUpdate);
    IList<ConstituencyResponseModel> GetAllConstituency();
    ConstituencyResponseModel GetConstituencyById(int constituencyId);
  }
}
