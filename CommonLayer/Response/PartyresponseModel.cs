namespace CommonLayer.Response
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  public class PartyresponseModel
  {
    public int partyId { get; set; }
    public string partyName { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime modifiedDate { get; set; }
  }
}
