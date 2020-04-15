namespace ElectionManagement.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.IdentityModel.Tokens.Jwt;
  using System.Linq;
  using System.Security.Claims;
  using System.Text;
  using System.Threading.Tasks;
  using BusinessLayer.Interfaces;
  using CommonLayer.Model;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Cors;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;
  using Microsoft.IdentityModel.Tokens;


  /// <summary>
  /// This is the Admin Controller.
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class AdminController : ControllerBase
  {
    private readonly IAdminBusiness adminBL;
    private readonly IConfiguration configuration;
    public AdminController(IAdminBusiness _adminBusiness, IConfiguration configuration)
    {
      adminBL = _adminBusiness;
      this.configuration = configuration;
    }

    /// <summary>
    /// This is the method for Adding user details.
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public IActionResult AddUserDetails(Admin details)
    {
      var result = adminBL.AdminRegister(details);
      if (result != null)
      {
        var success = true;
        var message = "registration successfully done";
        return Ok(new { success, message, result });
      }
      else
      {
        var success = false;
        var message = "registration Failed";
        return BadRequest(new { success, message });
      }
    }

    /// <summary>
    /// This is the method for login.
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("AdminLogin")]
    public IActionResult Login(AdminRequestModel login)
    {
      var result = adminBL.Login(login);
      if (result != null)
      {
        var token = GenerateJSONWebToken(result, "Login");
        var success = true;
        var message = "Login successfully done";
        return Ok(new { success, message, result, token });
      }
      else
      {
        var success = false;
        var message = "Login Failed";
        return BadRequest(new { success, message });
      }
    }

    /// <summary>
    /// This is the method of generate token
    /// </summary>
    /// <param name="responseModel"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    private string GenerateJSONWebToken(AdminResponseModel responseModel, string type)
    {
      try
      {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[] {
        new Claim("AdminId",responseModel.AdminId.ToString()),
        new Claim("UserName",responseModel.UserName.ToString()),
        new Claim("Typetoken",type)
        };
        var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
          configuration["Jwt:Issuer"],
          claims,
          expires: DateTime.Now.AddDays(1),
          signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}