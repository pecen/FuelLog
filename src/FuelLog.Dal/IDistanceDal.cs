using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Dal {
  public interface IDistanceDal {
    List<DistanceDto> Fetch();
  }
}
