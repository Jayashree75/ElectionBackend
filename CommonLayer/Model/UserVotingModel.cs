namespace CommonLayer.Model
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Text;


  public class UserVotingModel
  {

    [Key]
    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MobileNumber { get; set; }
    public int CandidateId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
  }

}
