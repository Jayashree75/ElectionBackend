namespace CommonLayer.RequestModel
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  public class UserVotingRequest
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public int CandidateId { get; set; }
  }
}
