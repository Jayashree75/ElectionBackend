namespace RepositoryLayer.Interfaces
{
  using CommonLayer.Model;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// This is the interface for admin Repository.
  /// </summary>
  public interface IAdminRepository
  {
    AdminResponseModel AdminRegister(Admin admin);
    AdminResponseModel Login(AdminRequestModel loginModel);
  }
}
