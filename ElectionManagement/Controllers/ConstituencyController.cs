namespace ElectionManagement.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using BusinessLayer.Interfaces;
  using CommonLayer.RequestModel;
  using CommonLayer.Response;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;

  /// <summary>
  /// this is the constituency controller.
  /// </summary>
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ConstituencyController : ControllerBase
  {
    private readonly IConstituencyBusiness constituencyBL;
    private readonly IConfiguration configuration;
    public ConstituencyController(IConstituencyBusiness _constituencyBusiness, IConfiguration configuration)
    {
      constituencyBL = _constituencyBusiness;
      this.configuration = configuration;
    }

    /// <summary>
    /// This is the method for add constituency.
    /// </summary>
    /// <param name="constituencyRequestmodel"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddConstituency(ConstituencyRequestmodel constituencyRequestmodel)
    {
      var user = HttpContext.User;
      ConstituencyResponseModel result = new ConstituencyResponseModel();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          result = constituencyBL.AddConstituency(constituencyRequestmodel);
          if (result != null)
          {
            var success = true;
            var message = "Constituency added";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "Constituency added failed";
            return Ok(new { success, message });
          }
        }

      }
      return BadRequest("Use Invalid Token");
    }

    /// <summary>
    /// This is the method for delete constituency.
    /// </summary>
    /// <param name="constituencyId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{constituencyId}")]
    public IActionResult DeleteConstituency(int constituencyId)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = constituencyBL.DeleteConstituency(constituencyId);
          if (result != null)
          {
            var success = true;
            var message = "Constituency Deleted";
            return Ok(new { success, message });
          }
          else
          {
            var success = false;
            var message = "Constituency deletion failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }

    /// <summary>
    /// This is the method for updating Constituency.
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <param name="constituencyUpdate"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{ConstituencyId}")]
    public IActionResult UpdateConstituency(int ConstituencyId, constituencyUpdate constituencyUpdate)
    {
      var user = HttpContext.User;
      ConstituencyResponseModel result = new ConstituencyResponseModel();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          result = constituencyBL.UpdateConstituency(ConstituencyId, constituencyUpdate);
          if (result != null)
          {
            var success = true;
            var message = "Constituency Updated";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "Constituency Updation failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }

    /// <summary>
    /// this is the method for getting all details of constituency.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAllConstituency()
    {
      var user = HttpContext.User;
      IList<ConstituencyResponseModel> result = new List<ConstituencyResponseModel>();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          result = constituencyBL.GetAllConstituency();
          if (result != null)
          {
            var success = true;
            var message = "All Constituency Detail";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "Constituency Detail getting failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }

    /// <summary>
    /// This is the method for get constituency by id.
    /// </summary>
    /// <param name="constituencyId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{constituencyId}")]
    public IActionResult GetConstituencyById(int constituencyId)
    {
      var user = HttpContext.User;
      ConstituencyResponseModel result = new ConstituencyResponseModel();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          result = constituencyBL.GetConstituencyById(constituencyId);
          if (result != null)
          {
            var success = true;
            var message = "Getting single record By Id successful";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "Getting single record By Id failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }
  }
}
