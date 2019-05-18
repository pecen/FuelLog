using Csla;
using FuelLog.Dal;
using FuelLog.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class UnitList : ReadOnlyListBase<UnitList, UnitInfo> {
    #region Factory Methods

    public static T GetUnitList<T>()
    {
      return DataPortal.Fetch<T>();
    }

    public static UnitList GetUnitList(UnitCategoriey category)
    {
      return DataPortal.Fetch<UnitList>(category);
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch(UnitCategoriey category)
    {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager())
      {
        var dal = dalManager.GetProvider<IUnitDal>();
        var data = dal.Fetch((int)category);

        foreach (var item in data)
        {
          Add(DataPortal.FetchChild<UnitInfo>(item));
        }
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    #endregion
  }
}
