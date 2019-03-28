using Csla;
using FuelLog.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class VolumeList : ReadOnlyListBase<VolumeList, VolumeInfo> {
    #region Factory Methods

    public static VolumeList GetVolumeList() {
      return DataPortal.Fetch<VolumeList>();
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch() {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<IVolumeDal>();
        var data = dal.Fetch();

        foreach (var item in data) {
          Add(DataPortal.FetchChild<VolumeInfo>(item));
        }
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    #endregion
  }
}
