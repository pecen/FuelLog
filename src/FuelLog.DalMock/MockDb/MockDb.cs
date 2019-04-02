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
                new CarData{ Id = 0, Make = "BMW", Model = "320d", LicensePlate = "OUS318", Note = "My first BMW", DistanceUnit = 0, VolumeUnit = 0, ConsumptionUnit = 0 }, // , TotalFillups = 64, TotalDistance = 55221AverageConsumption = 6.75M },
                new CarData{ Id = 1, Make = "Volvo", Model = "XC60", LicensePlate = "MTZ418", Note = "My current car in Finland", DistanceUnit = 1, VolumeUnit = 2, ConsumptionUnit = 3 }, // , TotalFillups = 48, TotalDistance = 78965AverageConsumption = 8.45M },
                new CarData{ Id = 2, Make = "Volvo", Model = "XC70", LicensePlate = "BKX594", Note = "My rental Volvo in Gothenburg", DistanceUnit = 0, VolumeUnit = 0, ConsumptionUnit = 10 }, // , TotalFillups = 64, TotalDistance = 8922AverageConsumption = 7.75M },
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
        new DistanceData{ Id = 0, Name = "Kilometers (Km)", ShortName = "Km" },
        new DistanceData{ Id = 1, Name = "Miles (mi)", ShortName = "Mi" },
        new DistanceData{ Id = 2, Name = "Hours (h)", ShortName = "H" }
      };

      VolumeUnits = new List<VolumeData> {
        new VolumeData{ Id = 0, Name = "Litres (l)", ShortName = "l" },
        new VolumeData{ Id = 1, Name = "Gallons US (gal)", ShortName = "gal" },
        new VolumeData{ Id = 2, Name = "Gallons Imp (gal)", ShortName = "gal" },
        new VolumeData{ Id = 3, Name = "Electric (kWh)", ShortName = "kWh" },
        new VolumeData{ Id = 4, Name = "CNG (kg)", ShortName = "kg" },
        new VolumeData{ Id = 5, Name = "CNG (gge)", ShortName = "gge" }
      };

      ConsumptionUnits = new List<ConsumptionData> {
        new ConsumptionData{ Id = 0, Name = "l/100km" },
        new ConsumptionData{ Id = 1, Name = "mpg (us)" },
        new ConsumptionData{ Id = 2, Name = "mpg (uk)" },
        new ConsumptionData{ Id = 3, Name = "km/l" },
        new ConsumptionData{ Id = 4, Name = "l/km" },
        new ConsumptionData{ Id = 5, Name = "l/mi" },
        new ConsumptionData{ Id = 6, Name = "l/100mi" },
        new ConsumptionData{ Id = 7, Name = "mi/l" },
        new ConsumptionData{ Id = 8, Name = "gal(us)/km" },
        new ConsumptionData{ Id = 9, Name = "gal(us)/100km" },
        new ConsumptionData{ Id = 10, Name = "gal(us)/mi" },
        new ConsumptionData{ Id = 11, Name = "gal(us)/100mi" },
        new ConsumptionData{ Id = 12, Name = "km/gal(us)" },
        new ConsumptionData{ Id = 13, Name = "gal(uk/km)" },
        new ConsumptionData{ Id = 14, Name = "gal(uk)/100km" },
        new ConsumptionData{ Id = 15, Name = "gal(uk)/mi" },
        new ConsumptionData{ Id = 16, Name = "gal(uk)/100mi" },
        new ConsumptionData{ Id = 17, Name = "km/gal(uk)" },
        new ConsumptionData{ Id = 18, Name = "kWh/km" },
        new ConsumptionData{ Id = 19, Name = "kWh/100km" },
        new ConsumptionData{ Id = 20, Name = "kWh/mi" },
        new ConsumptionData{ Id = 21, Name = "kWh/100mi" },
        new ConsumptionData{ Id = 22, Name = "km/kWh" },
        new ConsumptionData{ Id = 23, Name = "mi/kWh" },
        new ConsumptionData{ Id = 24, Name = "kg/km" },
        new ConsumptionData{ Id = 25, Name = "kg/100km" },
        new ConsumptionData{ Id = 26, Name = "kg/mi" },
        new ConsumptionData{ Id = 27, Name = "kg/100mi" },
        new ConsumptionData{ Id = 28, Name = "km/kg" },
        new ConsumptionData{ Id = 29, Name = "mi/kg" },
        new ConsumptionData{ Id = 30, Name = "gge/km" },
        new ConsumptionData{ Id = 31, Name = "gge/100km" },
        new ConsumptionData{ Id = 32, Name = "gge/mi" },
        new ConsumptionData{ Id = 33, Name = "gge/100mi" },
        new ConsumptionData{ Id = 34, Name = "km/gge" },
        new ConsumptionData{ Id = 35, Name = "mi/gge" },
        new ConsumptionData{ Id = 36, Name = "l/h" },
        new ConsumptionData{ Id = 37, Name = "h/l" },
        new ConsumptionData{ Id = 38, Name = "gal(us)/h" },
        new ConsumptionData{ Id = 39, Name = "h/gal(us)" },
        new ConsumptionData{ Id = 40, Name = "gal(uk)/h" },
        new ConsumptionData{ Id = 41, Name = "h/gal(uk)" },
        new ConsumptionData{ Id = 42, Name = "kWh/h" },
        new ConsumptionData{ Id = 43, Name = "h/kWh" },
        new ConsumptionData{ Id = 44, Name = "kg/h" },
        new ConsumptionData{ Id = 45, Name = "h/kg" },
        new ConsumptionData{ Id = 46, Name = "gge/h" },
        new ConsumptionData{ Id = 47, Name = "h/gge" }
      };
    }
  }
}
