namespace CommonLayer.Response
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  public class UserVotingResponse
  {
    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MobileNumber { get; set; }
    public int CandidateId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }


  }
  public class ConstituencyWiseResponse
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string partyName { get; set; }

    public int Votes { get; set; }
  }
}
