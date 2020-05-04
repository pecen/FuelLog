using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalEf.Entities {
  public class Fillup {
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public int Odometer { get; set; }
    public int Amount { get; set; }
    public decimal VolumePrice { get; set; }
    public string Note { get; set; }
  }
}
