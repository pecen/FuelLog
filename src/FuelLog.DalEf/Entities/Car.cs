using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalEf.Entities {
  public class Car {
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public string Note { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset LastModified { get; set; }
  }
}
