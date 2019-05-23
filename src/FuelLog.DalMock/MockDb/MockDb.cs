using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock.MockDb {
  public class MockDb {
    public static List<CarData> Cars { get; private set; }
    public static List<FillupData> Fillups { get; private set; }
    public static List<UnitData> Units { get; private set; }


    static MockDb()
    {
      Cars = new List<CarData> {
        new CarData{ Id = 0, Make = "BMW", Model = "320d", LicensePlate = "OUS318", Note = "My first BMW", DistanceUnit = 0, VolumeUnit = 0, ConsumptionUnit = 0 }, // , TotalFillups = 64, TotalDistance = 55221AverageConsumption = 6.75M },
        new CarData{ Id = 1, Make = "Volvo", Model = "XC60", LicensePlate = "MTZ418", Note = "My current car in Finland", DistanceUnit = 1, VolumeUnit = 2, ConsumptionUnit = 3 }, // , TotalFillups = 48, TotalDistance = 78965AverageConsumption = 8.45M },
        new CarData{ Id = 2, Make = "Volvo", Model = "XC90", LicensePlate = "BKX594", Note = "My rental Volvo in Gothenburg", DistanceUnit = 0, VolumeUnit = 0, ConsumptionUnit = 3 }, // , TotalFillups = 64, TotalDistance = 8922AverageConsumption = 7.75M },
      };

      Fillups = new List<FillupData> {
        new FillupData{ Id = 0, CarId = 0, FillUpDate = new DateTime(2016, 05, 01), Odometer = 52816, Amount = 66.23m, VolumePrice = 12.14m, PartialFillUp = false, Note = "First fillup for BMW" },
        new FillupData{ Id = 1, CarId = 1, FillUpDate = new DateTime(2016, 05, 16), Odometer = 53661, Amount = 64.23m, VolumePrice = 12.58m, PartialFillUp = false, Note = "First fillup for Volvo" },
        new FillupData{ Id = 2, CarId = 1, FillUpDate = new DateTime(2016, 05, 24), Odometer = 54441, Amount = 66.23m, VolumePrice = 12.54m, PartialFillUp = false, Note = "Second fillup for Volvo" },
        new FillupData{ Id = 3, CarId = 2, FillUpDate = new DateTime(2018, 04, 02), Odometer = 18, Amount = 65.00m, VolumePrice = 14.50m, PartialFillUp = false, Note = "First fillup for Volvo" },
        new FillupData{ Id = 4, CarId = 2, FillUpDate = new DateTime(2018, 04, 07), Odometer = 768, Amount = 64.36m, VolumePrice = 14.32m, PartialFillUp = false, Note = "Second fillup for Volvo" },
        new FillupData{ Id = 5, CarId = 2, FillUpDate = new DateTime(2018, 04, 13), Odometer = 1456, Amount = 63.39m, VolumePrice = 14.50m, PartialFillUp = false, Note = "Third fillup for Volvo" },
      };

      Units = new List<UnitData> {
        new UnitData{ Id = 0, Name = "Kilometers (Km)", ShortName = "Km", Category = 0 },
        new UnitData{ Id = 1, Name = "Miles (mi)", ShortName = "Mi", Category = 0 },
        new UnitData{ Id = 2, Name = "Hours (h)", ShortName = "H", Category = 0 },
        new UnitData{ Id = 0, Name = "Litres (l)", ShortName = "l", Category = 1 },
        new UnitData{ Id = 1, Name = "Gallons US (gal)", ShortName = "gal", Category = 1 },
        new UnitData{ Id = 2, Name = "Gallons Imp (gal)", ShortName = "gal", Category = 1 },
        new UnitData{ Id = 3, Name = "Electric (kWh)", ShortName = "kWh", Category = 1 },
        new UnitData{ Id = 4, Name = "CNG (kg)", ShortName = "kg", Category = 1 },
        new UnitData{ Id = 5, Name = "CNG (gge)", ShortName = "gge", Category = 1 },
        new UnitData{ Id = 0, Name = "l/100km", Category = 2 },
        new UnitData{ Id = 1, Name = "mpg (us)", Category = 2 },
        new UnitData{ Id = 2, Name = "mpg (uk)", Category = 2 },
        new UnitData{ Id = 3, Name = "km/l", Category = 2 },
        new UnitData{ Id = 4, Name = "l/km", Category = 2 },
        new UnitData{ Id = 5, Name = "l/mi", Category = 2 },
        new UnitData{ Id = 6, Name = "l/100mi", Category = 2 },
        new UnitData{ Id = 7, Name = "mi/l", Category = 2 },
        new UnitData{ Id = 8, Name = "gal(us)/km", Category = 2 },
        new UnitData{ Id = 9, Name = "gal(us)/100km", Category = 2 },
        new UnitData{ Id = 10, Name = "gal(us)/mi", Category = 2 },
        new UnitData{ Id = 11, Name = "gal(us)/100mi", Category = 2 },
        new UnitData{ Id = 12, Name = "km/gal(us)", Category = 2 },
        new UnitData{ Id = 13, Name = "gal(uk/km)", Category = 2 },
        new UnitData{ Id = 14, Name = "gal(uk)/100km", Category = 2 },
        new UnitData{ Id = 15, Name = "gal(uk)/mi", Category = 2 },
        new UnitData{ Id = 16, Name = "gal(uk)/100mi", Category = 2 },
        new UnitData{ Id = 17, Name = "km/gal(uk)", Category = 2 },
        new UnitData{ Id = 18, Name = "kWh/km", Category = 2 },
        new UnitData{ Id = 19, Name = "kWh/100km", Category = 2 },
        new UnitData{ Id = 20, Name = "kWh/mi", Category = 2 },
        new UnitData{ Id = 21, Name = "kWh/100mi", Category = 2 },
        new UnitData{ Id = 22, Name = "km/kWh", Category = 2 },
        new UnitData{ Id = 23, Name = "mi/kWh", Category = 2 },
        new UnitData{ Id = 24, Name = "kg/km", Category = 2 },
        new UnitData{ Id = 25, Name = "kg/100km", Category = 2 },
        new UnitData{ Id = 26, Name = "kg/mi", Category = 2 },
        new UnitData{ Id = 27, Name = "kg/100mi", Category = 2 },
        new UnitData{ Id = 28, Name = "km/kg", Category = 2 },
        new UnitData{ Id = 29, Name = "mi/kg", Category = 2 },
        new UnitData{ Id = 30, Name = "gge/km", Category = 2 },
        new UnitData{ Id = 31, Name = "gge/100km", Category = 2 },
        new UnitData{ Id = 32, Name = "gge/mi", Category = 2 },
        new UnitData{ Id = 33, Name = "gge/100mi", Category = 2 },
        new UnitData{ Id = 34, Name = "km/gge", Category = 2 },
        new UnitData{ Id = 35, Name = "mi/gge", Category = 2 },
        new UnitData{ Id = 36, Name = "l/h", Category = 2 },
        new UnitData{ Id = 37, Name = "h/l", Category = 2 },
        new UnitData{ Id = 38, Name = "gal(us)/h", Category = 2 },
        new UnitData{ Id = 39, Name = "h/gal(us)", Category = 2 },
        new UnitData{ Id = 40, Name = "gal(uk)/h", Category = 2 },
        new UnitData{ Id = 41, Name = "h/gal(uk)", Category = 2 },
        new UnitData{ Id = 42, Name = "kWh/h", Category = 2 },
        new UnitData{ Id = 43, Name = "h/kWh", Category = 2 },
        new UnitData{ Id = 44, Name = "kg/h", Category = 2 },
        new UnitData{ Id = 45, Name = "h/kg", Category = 2 },
        new UnitData{ Id = 46, Name = "gge/h", Category = 2 },
        new UnitData{ Id = 47, Name = "h/gge", Category = 2 }
      };
    }
  }
}
