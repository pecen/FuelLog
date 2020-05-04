using Csla.Data.EF6;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalEf {
  public class FillupDal : DalBase, IFillupDal {
    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public void DeleteAllForCar(int carId) {
      throw new NotImplementedException();
    }

    public FillupDto Fetch(int fillupId) {
      using (var ctx = DbContextManager<FuelLogDbContext>.GetManager(_dbName)) {
        var result = (from r in ctx.DbContext.Fillups
                      where r.Id == fillupId
                      select new FillupDto {
                        Id = r.Id,
                        CarId = r.CarId,
                        FillUpDate = r.Date,
                        Odometer = r.Odometer,
                        Amount = r.Amount,
                        VolumePrice = r.VolumePrice,
                        Note = r.Note,
                      }).FirstOrDefault();
        return result;
      }
    }

    public List<FillupDto> FetchForCar(int carId) {
      using (var ctx = DbContextManager<FuelLogDbContext>.GetManager(_dbName)) {
        var result = (from r in ctx.DbContext.Fillups
                      where r.CarId == carId
                      select new FillupDto {
                        Id = r.Id,
                        CarId = r.CarId,
                        FillUpDate = r.Date,
                        Odometer = r.Odometer,
                        Amount = r.Amount,
                        VolumePrice = r.VolumePrice,
                        Note = r.Note,
                      });
        return result.ToList();
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
