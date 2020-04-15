namespace ElectionManagement.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
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

  /// <summary>
  /// This is the party controller class.
  /// </summary>
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class PartyController : ControllerBase
  {
    private readonly IPartyBusiness partyBL;
    private readonly IConfiguration configuration;
    public PartyController(IPartyBusiness _partyBusiness, IConfiguration configuration)
    {
      partyBL = _partyBusiness;
      this.configuration = configuration;
    }

    /// <summary>
    /// This is the Add party Details method.
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public IActionResult AddPartyDetails(Party details)
    {
      var user = HttpContext.User;
      PartyresponseModel response = new PartyresponseModel();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {

          response = partyBL.AddParty(details);
          if (response != null)
          {
            var success = true;
            var message = "party add successfully done";
            return Ok(new { success, message, response });
          }
          else
          {
            var success = false;
            var message = "party add Failed";
            return BadRequest(new { success, message });
          }
        }

      }
      return BadRequest("used invalid token");
    }

    /// <summary>
    /// This is the method for getting all party details.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAllParty()
    {
      var user = HttpContext.User;
      IList<PartyresponseModel> partylist = new List<PartyresponseModel>();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          partylist = partyBL.GetAllParty();
          if (partylist != null)
          {
            var success = true;
            var message = "All party Details";
            return Ok(new { success, message, partylist });

          }
          else
          {
            var success = false;
            var message = "Failed getting detail";
            return BadRequest(new { success, message });
          }
        }
      }
      return BadRequest("used invalid token");
    }

    /// <summary>
    /// This is the method for delete party.
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{partyId}")]
    public IActionResult DeleteParty(int partyId)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = partyBL.DeleteParty(partyId);
          if (result != null)
          {
            var success = true;
            var message = "party Deleted";
            return Ok(new { success, message });
          }
          else
          {
            var success = false;
            var message = "Failed deletion";
            return BadRequest(new { success, message });
          }
        }
      }
      return BadRequest("used invalid token");
    }

    /// <summary>
    /// This is method for updating party.
    /// </summary>
    /// <param name="partyId"></param>
    /// <param name="partyRequestModel"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{partyId}")]
    public IActionResult UpdateParty(int partyId, PartyRequestModel partyRequestModel)
    {
      var user = HttpContext.User;
      PartyresponseModel result = new PartyresponseModel();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          result = partyBL.UpdateParty(partyId, partyRequestModel);
          if (result != null)
          {
            var success = true;
            var message = "party Updated";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "Failed Updation";
            return BadRequest(new { success, message });
          }
        }
      }
      return BadRequest("used invalid token");

    }

    /// <summary>
    /// This is the method for getpartybyid.
    /// </summary>
    /// <param name="partyId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{partyId}")]
    public IActionResult GetPartyById(int partyId)
    {
      var user = HttpContext.User;
      PartyresponseModel result = new PartyresponseModel();
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          result = partyBL.GetPartyById(partyId);
          if (result != null)
          {
            var success = true;
            var message = "party Details";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "party Details getting failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("used invalid token");
    }
  }
}