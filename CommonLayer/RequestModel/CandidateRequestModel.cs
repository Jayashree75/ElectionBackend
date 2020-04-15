namespace CommonLayer.RequestModel
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  public class CandidateRequestModel
  {

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int partyId { get; set; }
    public int ConstituencyId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

  }
}
