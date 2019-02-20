using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Dal {
  public interface ICarDal {
    List<CarDto> Fetch();
    CarDto Fetch(int id);
    CarDto Fetch(string licenseNumber);
    //CarSettingsDto FetchCarSettings(int carId);
    //CarStatisticsDto FetchStatistics(int carId);
    bool Exists(string licensePlate);
    void Insert(CarDto data);
    void Update(CarDto data);
    void Delete(int id);
  }
}
