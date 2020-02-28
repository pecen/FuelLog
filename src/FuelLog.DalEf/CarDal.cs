using Csla.Data.EF6;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using FuelLog.DalEf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalEf {
  public class CarDal : ICarDal {
    private readonly string _dbName = "Server";

    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public bool Exists(string licensePlate) {
      throw new NotImplementedException();
    }

    public List<CarDto> Fetch() {
      using (var ctx = DbContextManager<FuelLogDbContext>.GetManager(_dbName)) {
        var result = from r in ctx.DbContext.Cars
                     select new CarDto {
                       Id = r.Id,
                       Make = r.Make,
                       Model = r.Model,
                       LicensePlate = r.LicensePlate,
                       Note = r.Note, 
                       CreationDate = r.CreationDate,
                       LastModified = r.LastModified
                     };
        return result.ToList();
      }
    }

    public CarDto Fetch(int id) {
      throw new NotImplementedException();
    }

    public CarDto Fetch(string licenseNumber) {
      throw new NotImplementedException();
    }

    public void Insert(CarDto data) {
      using (var ctx = DbContextManager<FuelLogDbContext>.GetManager(_dbName)) {
        var item = new Car {
          Make = data.Make,
          Model = data.Model,
          LicensePlate = data.LicensePlate,
          Note = data.Note,
          CreationDate = data.CreationDate,
          LastModified = data.LastModified
        };

        ctx.DbContext.Cars.Add(item);
        ctx.DbContext.SaveChanges();
        data.Id = item.Id;
      }
    }

    public void Update(CarDto data) {
      throw new NotImplementedException();
    }
  }
}
