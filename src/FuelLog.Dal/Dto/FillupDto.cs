using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Dal.Dto {
  public class FillupDto {
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime FillUpDate { get; set; }
    public int Odometer { get; set; }
    public double Amount { get; set; }
    public double VolumePrice { get; set; }
    public bool PartialFillUp { get; set; }
    public string Note { get; set; }
  }
}
