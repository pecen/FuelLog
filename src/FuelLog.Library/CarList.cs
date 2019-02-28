using Csla;
using FuelLog.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class CarList : ReadOnlyListBase<CarList, CarInfo> {
    #region Factory Methods

    public static void GetCars(EventHandler<DataPortalResult<CarList>> callback) {
      DataPortal.BeginFetch<CarList>(callback);
    }

    public static CarList GetCars() {
      return DataPortal.Fetch<CarList>();
    }

    //public static CarInfo GetCar(int carId)
    //{
    //    return DataPortal.Fetch<CarInfo>(carId);
    //}

    #endregion

    #region Data Access

    private void DataPortal_Fetch() {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<ICarDal>();
        var data = dal.Fetch();

        foreach (var item in data) {
          Add(DataPortal.FetchChild<CarInfo>(item));
        }
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    #endregion
  }
}
