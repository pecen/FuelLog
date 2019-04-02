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
    public decimal Amount { get; set; }
    public decimal VolumePrice { get; set; }
    public bool PartialFillUp { get; set; }
    public string Note { get; set; }
    //public int DaysSinceLast { get; set; }
    //public int DistanceSinceLast { get; set; }
    //public decimal AverageConsumption { get; set; }
  }
}
