using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.DalMock {
  public class ConsumptionDal : IConsumptionDal {
    public List<ConsumptionDto> Fetch() {
      var data = from r in MockDb.MockDb.ConsumptionUnits
                 select new ConsumptionDto {
                   Id = r.Id,
                   Name = r.Name
                 };

      return data.ToList();
    }
  }
}
