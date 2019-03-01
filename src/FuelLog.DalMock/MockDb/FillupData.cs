using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock.MockDb {
  public class FillupData {
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime FillUpDate { get; set; }
    public int Odometer { get; set; }
    public decimal Amount { get; set; }
    public decimal VolumePrice { get; set; }
    public bool PartialFillUp { get; set; }
    public string Note { get; set; }
  }
}
