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
    //CarStatisticsDto FetchStatistics(int carId);
    bool Exists(string licensePlate);
    void Insert(CarDto data);
    void Update(CarDto data);
    void Delete(int id);
    /// <summary>
    /// Deletes a range of cars defined with their respective car id
    /// </summary>
    /// <param name="ids">The array of car id's</param>
    /// <returns>A list of failed deletions defined by the car id's</returns>
    IList<int> DeleteRange(int[] ids);
  }
}
