namespace CommonLayer.Response
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  public class CandidateResponseModel
  {
    public int CandidateId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int partyId { get; set; }
    public string partyName { get; set; }
    public int ConstituencyId { get; set; }
    public string Name { get;set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
