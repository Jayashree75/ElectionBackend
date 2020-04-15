namespace ElectionManagement.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using BusinessLayer.Interfaces;
  using CommonLayer.RequestModel;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;

  /// <summary>
  /// This is userVoting Controller.
  /// </summary>
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UserVotingController : ControllerBase
  {
    private readonly IUserVotingBusiness userVotingBL;
    private readonly IConfiguration configuration;
    public UserVotingController(IUserVotingBusiness userVotingBusiness, IConfiguration configuration)
    {
      userVotingBL = userVotingBusiness;
      this.configuration = configuration;
    }
    /// <summary>
    /// This is the add user method.
    /// </summary>
    /// <param name="userVoting"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddUserVotes(UserVotingRequest userVoting)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = userVotingBL.AddUserVotes(userVoting);
          if (result != null)
          {
            var success = true;
            var message = "User vote successfully added";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "User vote added failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invakid token");
    }

    /// <summary>
    /// This is method to show the list by constituency wise
    /// </summary>
    /// <param name="ConstituencyId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{ConstituencyId}")]
    public IActionResult GetConstituencyWiseResult(int ConstituencyId)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = userVotingBL.GetConstituencyWiseResult(ConstituencyId);
          if (result != null)
          {
            var success = "true";
            var message = "Constituency wise result getting successfully done";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = "false";
            var message = "Constituency wise result getting failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Use invalid token");
    }

    /// <summary>
    /// This is the method to show the result by party wise
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult partyWiseRequest(string State)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = userVotingBL.PartyWiseResponses(State);
          if (result != null)
          {
            var success = "true";
            var message = "party wise result getting successfully done";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = "false";
            var message = "party wise result getting failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Use Invalid Token");
    }
  }
}