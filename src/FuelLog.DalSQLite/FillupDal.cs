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
  public class FillupDal : DalBase, IFillupDal {
    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public void DeleteFillupsForCar(int carId) {
      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName)) {
        using (var cm = ctx.Connection.CreateCommand()) {
          cm.CommandType = System.Data.CommandType.Text;
          cm.CommandText = "DELETE FROM FillUp WHERE CarId=@CarId";
          cm.Parameters.AddWithValue("@CarId", carId);
          try {
            var rowsAffected = cm.ExecuteNonQuery();

            if (rowsAffected == 0 && FetchForCar(carId).Count() > 0) {
              throw new DataNotFoundException($"Unable to delete FillUps for Car with id {carId}");
            }
          }
          catch {
            throw new DataNotFoundException("DeleteFillupsForCar failed in FillupDal");
          }
        }
      }
    }

    public FillupDto Fetch(int fillupId) {
      throw new NotImplementedException();
    }

    public List<FillupDto> FetchForCar(int carId) {
      var result = new List<FillupDto>();

      using (var ctx = ConnectionManager<SqliteConnection>.GetManager(_dbName)) {
        SqliteParameter p = new SqliteParameter("@CarId", carId);
        var cm = ctx.Connection.CreateCommand();
        cm.CommandType = System.Data.CommandType.Text;
        cm.CommandText = "Select * from FillUp where CarId = @CarId";
        cm.Parameters.Add(p);

        using (var dr = cm.ExecuteReader()) {
          while (dr.Read())
            result.Add(new FillupDto {
              Id = dr.GetInt32(0),
              CarId = dr.GetInt32(1),
              FillUpDate = dr.GetDateTime(2),
              Odometer = dr.GetInt32(3),
              Amount = dr.GetDecimal(4),
              VolumePrice = dr.GetDecimal(5),
              PartialFillUp = dr.GetBoolean(6),
              Note = dr.GetString(7)
            });
        }

        return result;
      }
    }

    public void Insert(FillupDto data) {
      throw new NotImplementedException();
    }

    public void Update(FillupDto data) {
      throw new NotImplementedException();
    }
  }
}
