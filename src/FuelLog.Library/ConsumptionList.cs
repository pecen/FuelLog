using Csla;
using FuelLog.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class ConsumptionList : ReadOnlyListBase<ConsumptionList, ConsumptionInfo> {
    #region Factory Methods

    public static ConsumptionList GetConsumptionList() {
      return DataPortal.Fetch<ConsumptionList>();
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch() {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<IConsumptionDal>();
        var data = dal.Fetch();

        foreach (var item in data) {
          Add(DataPortal.FetchChild<ConsumptionInfo>(item));
        }
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    #endregion
  }
}
