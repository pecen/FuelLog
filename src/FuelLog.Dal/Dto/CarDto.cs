using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Dal.Dto {
  public class CarDto {
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public string Note { get; set; }
    public string DistanceUnit { get; set; }
    public string VolumeUnit { get; set; }
    public string ConsumptionUnit { get; set; }
    public int TotalFillups { get; set; }
    public int TotalDistance { get; set; }
    public decimal AverageConsumption { get; set; }
    public DateTimeOffset DateAdded { get; set; }
    public DateTimeOffset LastModified { get; set; }
  }
}
