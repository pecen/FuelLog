using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock {
  public class CarDal : ICarDal {
    public List<CarDto> Fetch() {
      var data = from r in MockDb.MockDb.Cars
                 select new CarDto {
                   Id = r.Id,
                   Make = r.Make,
                   Model = r.Model,
                   LicensePlate = r.LicensePlate,
                   Note = r.Note,
                   DistanceUnitId = r.DistanceUnit,
                   VolumeUnitId = r.VolumeUnit,
                   ConsumptionUnitId = r.ConsumptionUnit,
                   //TotalFillups = r.TotalFillups,
                   //TotalDistance = r.TotalDistance,
                   //AverageConsumption = r.AverageConsumption
                 };

      return data.ToList();
    }

    public CarDto Fetch(int id) {
      var data = (from r in MockDb.MockDb.Cars
                  where r.Id == id
                  select new CarDto {
                    Id = r.Id,
                    Make = r.Make,
                    Model = r.Model,
                    LicensePlate = r.LicensePlate,
                    Note = r.Note,
                    DistanceUnitId = r.DistanceUnit,
                    VolumeUnitId = r.VolumeUnit,
                    ConsumptionUnitId = r.ConsumptionUnit,
                    //TotalFillups = r.TotalFillups,
                    //TotalDistance = r.TotalDistance,
                    //AverageConsumption = r.AverageConsumption
                  }).FirstOrDefault();
      return data;
    }

    public CarDto Fetch(string licensePlate) {
      var data = (from r in MockDb.MockDb.Cars
                  where r.LicensePlate == licensePlate
                  select new CarDto {
                    Id = r.Id,
                    Make = r.Make,
                    Model = r.Model,
                    LicensePlate = r.LicensePlate,
                    Note = r.Note,
                    DistanceUnitId = r.DistanceUnit,
                    VolumeUnitId = r.VolumeUnit,
                    ConsumptionUnitId = r.ConsumptionUnit,
                    //TotalFillups = r.TotalFillups,
                    //TotalDistance = r.TotalDistance,
                    //AverageConsumption = r.AverageConsumption
                  }).FirstOrDefault();
      return data;
    }

    public void Insert(CarDto data) {
      var newId = MockDb.MockDb.Cars.Max(r => r.Id) + 1;
      var item = new MockDb.CarData {
        Id = newId,
        Make = data.Make,
        Model = data.Model,
        LicensePlate = data.LicensePlate,
        Note = data.Note,
        DistanceUnit = data.DistanceUnitId,
        VolumeUnit = data.VolumeUnitId,
        ConsumptionUnit = data.ConsumptionUnitId,
        //TotalFillups = data.TotalFillups,
        //TotalDistance = data.TotalDistance,
        //AverageConsumption = data.AverageConsumption
      };
      MockDb.MockDb.Cars.Add(item);
      data.Id = newId;
    }

    public void Update(CarDto data) {
      var item = MockDb.MockDb.Cars.Where(r => r.Id == data.Id).First();
      item.Make = data.Make;
      item.Model = data.Model;
      item.LicensePlate = data.LicensePlate;
      item.Note = data.Note;
      item.DistanceUnit = data.DistanceUnitId;
      item.VolumeUnit = data.VolumeUnitId;
      item.ConsumptionUnit = data.ConsumptionUnitId;
      //item.TotalFillups = data.TotalFillups;
      //item.TotalDistance = data.TotalDistance;
      //item.AverageConsumption = data.AverageConsumption;
    }

    public void Delete(int id) {
      var item = MockDb.MockDb.Cars.Where(r => r.Id == id).FirstOrDefault();
      if (item != null)
        MockDb.MockDb.Cars.Remove(item);
    }

    public bool Exists(string licensePlate) {
      int retval = (from r in MockDb.MockDb.Cars
                    where r.LicensePlate == licensePlate
                    select new CarDto {
                      Id = r.Id,
                      Make = r.Make,
                      Model = r.Model,
                      LicensePlate = r.LicensePlate,
                      Note = r.Note,
                      DistanceUnitId = r.DistanceUnit,
                      VolumeUnitId = r.VolumeUnit,
                      ConsumptionUnitId = r.ConsumptionUnit,
                      //TotalFillups = r.TotalFillups,
                      //TotalDistance = r.TotalDistance,
                      //AverageConsumption = r.AverageConsumption
                    }).Count();

      return retval > 0;
    }
  }
}
