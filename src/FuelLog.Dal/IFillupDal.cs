using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Dal {
  public interface IFillupDal {
    FillupDto Fetch(int fillupId);
    List<FillupDto> FetchForCar(int carId);
    void Insert(FillupDto data);
    void Update(FillupDto data);
    void Delete(int id);
    void DeleteAllForCar(int carId);
  }
}
