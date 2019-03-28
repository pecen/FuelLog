using Csla;
using FuelLog.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class DistanceList : ReadOnlyListBase<DistanceList, DistanceInfo> {
    #region Factory Methods

    public static DistanceList GetDistanceList() {
      return DataPortal.Fetch<DistanceList>();
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch() {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<IDistanceDal>();
        var data = dal.Fetch();

        foreach (var item in data) {
          Add(DataPortal.FetchChild<DistanceInfo>(item));
        }
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    #endregion
  }
}
