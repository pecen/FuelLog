using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock {
  public class UnitDal : IUnitDal {
    public List<UnitDto> Fetch(int unitCategory)
    {
      var data = from r in MockDb.MockDb.Units
                 where r.Category == unitCategory
                 select new UnitDto
                 {
                   Id = r.Id,
                   Name = r.Name,
                   ShortName = r.ShortName
                 };

      return data.ToList();
    }
  }
}
