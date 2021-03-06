﻿using Csla;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class FillupList : ReadOnlyListBase<FillupList, FillupInfo> {
    #region Factory Methods

    public static FillupList GetFillups(int carId) {
      return DataPortal.Fetch<FillupList>(carId);
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch(int carId) {
      var rlce = RaiseListChangedEvents;
      RaiseListChangedEvents = false;
      IsReadOnly = false;

      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<IFillupDal>();
        var data = dal.FetchForCar(carId);

        CalcSummaries(data);

        foreach (var item in data) {
          Add(DataPortal.FetchChild<FillupInfo>(item)); 
        }
      }

      RaiseListChangedEvents = true;
      IsReadOnly = true;
    }

    private void CalcSummaries(List<FillupDto> data) {
      for(int i = 1; i < data.Count(); i++) {
        var daysSinceLast = (data[i].FillUpDate - data[i - 1].FillUpDate).Days;
        var distanceSinceLast = data[i].Odometer - data[i - 1].Odometer;
        var consumption = data[i].Amount / distanceSinceLast * 100;

        data[i].DaysSinceLast = daysSinceLast;
        data[i].DistanceSinceLast = distanceSinceLast;
        data[i].AverageConsumption = consumption;
      }
    }

    #endregion
  }
}
