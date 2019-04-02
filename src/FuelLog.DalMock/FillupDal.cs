using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock {
  public class FillupDal : IFillupDal {
    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public void DeleteAllForCar(int carId) {
      throw new NotImplementedException();
    }

    public FillupDto Fetch(int fillupId) {
      throw new NotImplementedException();
    }

    public List<FillupDto> FetchForCar(int carId) {
      var data = from r in MockDb.MockDb.Fillups
                  where r.CarId == carId
                  orderby r.FillUpDate
                  select new FillupDto {
                    Id = r.Id,
                    CarId = r.CarId,
                    FillUpDate = r.FillUpDate,
                    Odometer = r.Odometer,
                    Amount = r.Amount,
                    VolumePrice = r.VolumePrice,
                    PartialFillUp = r.PartialFillUp,
                    Note = r.Note,
                  };
      return data.ToList();
    }

    public void Insert(FillupDto data) {
      throw new NotImplementedException();
    }

    public void Update(FillupDto data) {
      throw new NotImplementedException();
    }
  }
}
