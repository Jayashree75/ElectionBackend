namespace CommonLayer.Response
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Text;


  public class AdminResponseModel
  {
    [Key]
    public int AdminId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
