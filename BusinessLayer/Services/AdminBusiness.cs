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
  using System.Threading.Tasks;

  /// <summary>
  /// This is the class for AdminBusiness.
  /// </summary>
  public class AdminBusiness : IAdminBusiness
  {
    private readonly IAdminRepository adminRL;
    public AdminBusiness(IAdminRepository adminRepository)
    {
      adminRL = adminRepository;
    }

    /// <summary>
    /// This is the method for Admin register.
    /// </summary>
    /// <param name="admin"></param>
    /// <returns></returns>
    public AdminResponseModel AdminRegister(Admin admin)
    {
      try
      {
        if (admin != null)
        {
          return adminRL.AdminRegister(admin);
        }
        else
        {
          throw new Exception("Admin is empty");
        }
      }
      catch (Exception exception)
      {
        throw exception;
      }
    }

    /// <summary>
    /// This is the method foe login Admin.
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public AdminResponseModel Login(AdminRequestModel login)
    {
      try
      {
        if (login != null)
        {
          return adminRL.Login(login);
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
  }
}
