namespace CommonLayer.Model
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Text;


  public class CandidateModel
  {
    [Key]
    public int CandidateId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ConstituencyId { get; set; }
    public int partyId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
