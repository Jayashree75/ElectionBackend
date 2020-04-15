namespace BusinessLayer.Interfaces
{
  using CommonLayer.Model;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Threading.Tasks;

  public interface IAdminBusiness
  {

    AdminResponseModel AdminRegister(Admin admin);
    AdminResponseModel Login(AdminRequestModel login);
   }
}
