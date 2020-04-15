namespace CommonLayer.Model
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Text;


  public class Constituency
  {
    [Key]
    public int ConstituencyId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

  }
}

