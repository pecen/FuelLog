using Csla;
using FuelLog.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class FillupList : ReadOnlyListBase<FillupList, FillupInfo> {
    #region Factory Methods

    public static FillupList GetFillups(int carId) {
      return DataPortal.Fetch<FillupList>(carId);
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch(int carId) {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<IFillupDal>();
        var data = dal.FetchForCar(carId);

        foreach (var item in data)
          Add(DataPortal.FetchChild<FillupInfo>(item));
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    #endregion
  }
}
