
namespace CommonLayer.RequestModel
{
  using System;
  using System.Collections.Generic;
  using System.Text;


  public class PartyRequestModel
  {
    public string partyName { get; set; }
    public DateTime modifiedDate { get;set; }
  }
  public class ParyWiseRequest
  {
    public string State { get; set; }
  }
}
