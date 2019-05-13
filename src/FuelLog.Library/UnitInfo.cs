using Csla;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class UnitInfo : ReadOnlyBase<UnitInfo> {
    #region Properties

    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    public int Id {
      get { return GetProperty(IdProperty); }
      set { LoadProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
    public string Name {
      get { return GetProperty(NameProperty); }
      set { LoadProperty(NameProperty, value); }
    }

    public static readonly PropertyInfo<string> ShortNameProperty = RegisterProperty<string>(c => c.ShortName);
    public string ShortName {
      get { return GetProperty(ShortNameProperty); }
      set { LoadProperty(ShortNameProperty, value); }
    }

    #endregion

    #region Data Access

    private void Child_Fetch(UnitDto item)
    {
      Id = item.Id;
      Name = item.Name;
      ShortName = item.ShortName;
    }

    #endregion
  }
}
