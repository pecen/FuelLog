using Csla.Data;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using FuelLog.Dal.Exceptions;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalSQLite {
  public class CarDal : DalBase, ICarDal {
    public void Delete(int id) {
      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName)) {
        using (var cm = ctx.Connection.CreateCommand()) {
          FillupDal dal = new FillupDal();
          dal.DeleteFillupsForCar(id);

          cm.Parameters.AddWithValue("@Id", id);
          cm.CommandText = "Delete From Car Where Id = @Id";
          var rowsAffected = cm.ExecuteNonQuery();

          if (rowsAffected == 0)
            throw new DataNotFoundException("Delete of Car failed");
        }
      }
    }

    /// <summary>
    /// Deletes a range of cars defined with their respective car id
    /// </summary>
    /// <param name="ids">The array of car id's</param>
    /// <returns>A list of failed deletions defined by the car id's</returns>
    public IList<int> DeleteRange(int[] ids) {
      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName)) {
        List<int> failedIds = new List<int>();
        FillupDal dal = new FillupDal();

        foreach (var id in ids) {
          using (var cm = ctx.Connection.CreateCommand()) {
            dal.DeleteFillupsForCar(id);

            cm.Parameters.AddWithValue("@Id", id);
            cm.CommandText = "Delete From Car Where Id = @Id";
            var rowsAffected = cm.ExecuteNonQuery();

            if (rowsAffected == 0)
              failedIds.Add(id);
              //throw new DataNotFoundException("Delete of Car failed");
          }
        }

        return failedIds;
      }
    }

    public bool Exists(string licensePlate) {
      throw new NotImplementedException();
    }

    public List<CarDto> Fetch() {
      var result = new List<CarDto>();

      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName)) 
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

            if (DateTime.TryParse(date, out DateTime dateResult)) {
              car.CreationDate = dateResult;
            }

            if (DateTime.TryParse(modified, out DateTime modifiedResult)) {
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
      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName)) {
        using (var cm = ctx.Connection.CreateCommand()) {
          cm.CommandType = System.Data.CommandType.Text;
          cm.CommandText = "Insert Into Car (Make, Model, LicensePlate, Note, DistanceUnit, VolumeUnit, ConsumptionUnit, " +
            "CreationDate, LastModified) " +
              "Values (@Make, @Model, @LicensePlate, @Note, @Distance, @Volume, @Consumption, @CreationDate, @LastModified)";
          cm.Parameters.AddWithValue("@Make", data.Make);
          cm.Parameters.AddWithValue("@Model", data.Model);
          cm.Parameters.AddWithValue("@LicensePlate", data.LicensePlate);
          cm.Parameters.AddWithValue("@Note", data.Note);
          cm.Parameters.AddWithValue("@Distance", data.DistanceUnit);
          cm.Parameters.AddWithValue("@Volume", data.VolumeUnit);
          cm.Parameters.AddWithValue("@Consumption", data.ConsumptionUnit);
          cm.Parameters.AddWithValue("@CreationDate", data.CreationDate);
          cm.Parameters.AddWithValue("@LastModified", data.LastModified);
          cm.ExecuteNonQuery();
          cm.Parameters.Clear();
          cm.CommandText = "Select last_insert_rowid() from Car";
          var r = cm.ExecuteScalar();
          var newId = int.Parse(r.ToString());
          data.Id = newId;
        }
      }
    }

    public void Update(CarDto data) {
      throw new NotImplementedException();
    }
  }
}
