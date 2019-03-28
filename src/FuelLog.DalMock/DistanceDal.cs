using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock {
  public class DistanceDal : IDistanceDal {
    public List<DistanceDto> Fetch() {
      var data = from r in MockDb.MockDb.DistanceUnits
                 select new DistanceDto {
                   Id = r.Id,
                   Name = r.Name
                 };

      return data.ToList();
    }
  }
}
