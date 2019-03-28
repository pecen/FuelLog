using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock.MockDb {
  public class MockDb {
    public static List<CarData> Cars { get; private set; }
    public static List<FillupData> Fillups { get; private set; }
    public static List<DistanceData> DistanceUnits { get; private set; }
    public static List<VolumeData> VolumeUnits { get; private set; }
    public static List<ConsumptionData> ConsumptionUnits { get; private set; }


    static MockDb() {
      Cars = new List<CarData>{
                new CarData{ Id = 0, Make = "BMW", Model = "320d", LicensePlate = "OUS318", Note = "My first BMW", DistanceUnit = "km", VolumeUnit = "l", ConsumptionUnit = "l/100km", TotalFillups = 64, TotalDistance = 55221, AverageConsumption = 6.75M },
                new CarData{ Id = 1, Make = "Volvo", Model = "XC60", LicensePlate = "MTZ418", Note = "My current car in Finland", DistanceUnit = "km", VolumeUnit = "l", ConsumptionUnit = "l/100km", TotalFillups = 48, TotalDistance = 78965, AverageConsumption = 8.45M },
                new CarData{ Id = 2, Make = "Volvo", Model = "XC70", LicensePlate = "BKX594", Note = "My rental Volvo in Gothenburg", DistanceUnit = "km", VolumeUnit = "l", ConsumptionUnit = "l/100km", TotalFillups = 64, TotalDistance = 8922, AverageConsumption = 7.75M },
            };

      Fillups = new List<FillupData>{
                new FillupData{ Id = 0, CarId = 0, FillUpDate = new DateTime(2016, 05, 01), Odometer = 52816, Amount = 66.23m, VolumePrice = 12.14m, PartialFillUp = false, Note = "First fillup for BMW" },
                new FillupData{ Id = 1, CarId = 1, FillUpDate = new DateTime(2016, 05, 16), Odometer = 53661, Amount = 64.23m, VolumePrice = 12.58m, PartialFillUp = false, Note = "First fillup for Volvo" },
                new FillupData{ Id = 2, CarId = 1, FillUpDate = new DateTime(2016, 05, 24), Odometer = 54441, Amount = 66.23m, VolumePrice = 12.54m, PartialFillUp = false, Note = "Second fillup for Volvo" },
                new FillupData{ Id = 3, CarId = 2, FillUpDate = new DateTime(2016, 05, 01), Odometer = 52816, Amount = 66.23m, VolumePrice = 12.14m, PartialFillUp = false, Note = "First fillup for BMW" },
                new FillupData{ Id = 4, CarId = 2, FillUpDate = new DateTime(2016, 05, 16), Odometer = 53661, Amount = 64.23m, VolumePrice = 12.58m, PartialFillUp = false, Note = "First fillup for Volvo" },
                new FillupData{ Id = 5, CarId = 2, FillUpDate = new DateTime(2016, 05, 24), Odometer = 54441, Amount = 66.23m, VolumePrice = 12.54m, PartialFillUp = false, Note = "Second fillup for Volvo" },
            };

      DistanceUnits = new List<DistanceData> {
        new DistanceData{ Id = 0, Name = "Dist 1" },
        new DistanceData{ Id = 1, Name = "Distance 2" }
      };

      VolumeUnits = new List<VolumeData> {
        new VolumeData{ Id = 0, Name = "Kg/m" },
        new VolumeData{ Id = 1, Name = "Km/l" }
      };

      ConsumptionUnits = new List<ConsumptionData> {
        new ConsumptionData{ Id = 0, Name = "Km" },
        new ConsumptionData{ Id = 1, Name = "Miles" }
      };
    }
  }
}
