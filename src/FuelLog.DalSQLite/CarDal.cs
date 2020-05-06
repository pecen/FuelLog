using Csla.Data;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalSQLite {
  public class CarDal : DalBase, ICarDal {
    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public bool Exists(string licensePlate) {
      throw new NotImplementedException();
    }

    public List<CarDto> Fetch() {
      var result = new List<CarDto>();

      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName))  //connectionString,false))
      {
        var cm = ctx.Connection.CreateCommand();
        cm.CommandType = System.Data.CommandType.Text;
        cm.CommandText = "SELECT Car.Id, Car.Make, Car.Model, Car.LicensePlate, Car.Note, " +
            "Car.DistanceUnit, Car.VolumeUnit, Car.ConsumptionUnit, " +
            "(SELECT Count(*) From FillUp Where CarId = Car.Id) TotalFillups, " +
            "(SELECT (MAX(Odometer) - MIN(Odometer)) FROM FillUp WHERE (CarId = Car.Id)) TotalDistance, " +
            "(SELECT (SUM(Amount) - (SELECT Amount From FillUp Where CarId = Car.Id Order By " +
            "Amount Desc Limit 1 )) / (MAX(Odometer) - MIN(Odometer)) AS AverageConsumption " +
            "FROM FillUp WHERE CarId = Car.Id) AverageConsumption, CreationDate, LastModified FROM Car";

        using (var dr = new SafeDataReader(cm.ExecuteReader())) {
          while (dr.Read()) {
            var date = dr.GetString(11);
            var modified = dr.GetString(12);

            var car = new CarDto {
              Id = dr.GetInt32(0),
              Make = dr.GetString(1),
              Model = dr.GetString(2),
              LicensePlate = dr.GetString(3),
              Note = dr.GetString(4),
              DistanceUnit = dr.GetInt32(5),
              VolumeUnit = dr.GetInt32(6),
              ConsumptionUnit = dr.GetInt32(7),
              TotalFillups = dr.GetInt32(8),
              TotalDistance = dr.GetInt32(9),
              AverageConsumption = dr.GetDecimal(10)
            };

            if(DateTime.TryParse(date, out DateTime dateResult)) {
              car.CreationDate = dateResult;
            }

            if(DateTime.TryParse(modified, out DateTime modifiedResult)) {
              car.LastModified = modifiedResult;
            }

            result.Add(car);
          }
        }
      }

      return result;
    }

    public CarDto Fetch(int id) {
      throw new NotImplementedException();
    }

    public CarDto Fetch(string licenseNumber) {
      throw new NotImplementedException();
    }

    public void Insert(CarDto data) {
      throw new NotImplementedException();
    }

    public void Update(CarDto data) {
      throw new NotImplementedException();
    }
  }
}
