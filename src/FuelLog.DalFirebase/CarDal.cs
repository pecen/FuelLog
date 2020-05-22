using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalFirebase {
  public class CarDal : ICarDal {
    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public IList<int> DeleteRange(int[] ids) {
      throw new NotImplementedException();
    }

    public bool Exists(string licensePlate) {
      throw new NotImplementedException();
    }

    public List<CarDto> Fetch() {
      throw new NotImplementedException();
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
