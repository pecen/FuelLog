using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class CarList : ReadOnlyListBase<CarList, CarInfo> {
  }
}
