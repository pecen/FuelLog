using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock {
  public class VolumeDal : IVolumeDal {
    public List<VolumeDto> Fetch() {
      var data = from r in MockDb.MockDb.VolumeUnits
                 select new VolumeDto {
                   Id = r.Id,
                   Name = r.Name
                 };

      return data.ToList();
    }
  }
}
