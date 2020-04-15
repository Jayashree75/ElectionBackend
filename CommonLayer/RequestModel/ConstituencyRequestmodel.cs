namespace CommonLayer.RequestModel
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Text;


  public class ConstituencyRequestmodel
  {
    public int ConstituencyId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
  public class constituencyUpdate
  {
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
  }
}
