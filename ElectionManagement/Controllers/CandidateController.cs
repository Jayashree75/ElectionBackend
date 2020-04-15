namespace ElectionManagement.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using BusinessLayer.Interfaces;
  using CommonLayer.RequestModel;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Cors;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Configuration;

  /// <summary>
  /// this is the candidate controller.
  /// </summary>
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class CandidateController : ControllerBase
  {
    private readonly ICandidateBusiness candidateBL;
    private readonly IConfiguration configuration;
    public CandidateController(ICandidateBusiness candidateBusiness, IConfiguration configuration)
    {
      candidateBL = candidateBusiness;
      this.configuration = configuration;
    }

    /// <summary>
    /// This is the method for add candidate.
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddCandidate(CandidateRequestModel requestModel)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = candidateBL.AddCandidate(requestModel);
          if (result != null)
          {
            var success = true;
            var message = "Candidate ADD successfully";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "candidate add failed";
            return Ok(new { success, message, result });
          }
        }
      }
      return BadRequest("Used Invalid token");
    }

    /// <summary>
    /// This is the method for update candidate.
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPut]
    public IActionResult UpdateCandidate(CandidateRequestModel requestModel,int CandidateId)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = candidateBL.UpdateCandidate(requestModel, CandidateId);
          if (result != null)
          {
            var success = true;
            var message = "Candidate Update successfully";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "candidate Updation failed";
            return Ok(new { success, message, result });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }

    /// <summary>
    /// This is the method for delete candidate by id.
    /// </summary>
    /// <param name="CandidateId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{CandidateId}")]
    public IActionResult DeleteCandidate(int CandidateId)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = candidateBL.DeleteCandidate(CandidateId);
          if (result != null)
          {
            var success = true;
            var message = "Candidate Deleted successfully";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "candidate deletion failed";
            return Ok(new { success, message, result });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }

    /// <summary>
    /// This is the method for getting candidate by id.
    /// </summary>
    /// <param name="CandidateId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{CandidateId}")]
    public IActionResult GetCandidateById(int CandidateId)
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = candidateBL.GetCandidateById(CandidateId);
          if (result != null)
          {
            var success = true;
            var message = "Candidate detail gettingbyId successfully";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "candidate getting failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }

    /// <summary>
    /// This is the method for get all candidate details.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAllCandidate()
    {
      var user = HttpContext.User;
      if (user.HasClaim(c => c.Type == "Typetoken"))
      {
        if (user.Claims.FirstOrDefault(c => c.Type == "Typetoken").Value == "Login")
        {
          var result = candidateBL.GetAllCandidate();
          if (result != null)
          {
            var success = true;
            var message = "All CandidateList getting successfully";
            return Ok(new { success, message, result });
          }
          else
          {
            var success = false;
            var message = "candidate getting failed";
            return Ok(new { success, message });
          }
        }
      }
      return BadRequest("Used Invalid Token");
    }
  }
}

