using FuelLog.Library;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.UI.Wpf.Module.Commands
{
  public class SaveCarCommand : PubSubEvent<CarList> {
  }
}
