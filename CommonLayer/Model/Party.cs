namespace CommonLayer.Model
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Text;


  public class Party
  {
    public int partyId { get; set; }
    public string partyName { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime modifiedDate { get; set; }
  }
}
