using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class FillupListViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;

    #region Properties

    public DelegateCommand GetFillupsCommand { get; set; }
    public DelegateCommand DeleteFillupsCommand { get; set; }

    private FillupList _fillups;
    public FillupList Fillups {
      get { return _fillups; }
      set { SetProperty(ref _fillups, value); }
    }

    //public CarList Cars { get; set; }

    private CarList _cars;
    public CarList Cars {
      get { return _cars; }
      set { SetProperty(ref _cars, value); }
    }

    private int _selectedCar;
    public int SelectedCar {
      get { return _selectedCar; }
      set { SetProperty(ref _selectedCar, value); }
    }

    #endregion

    public FillupListViewModel(IEventAggregator eventaggregator) {
      _eventAggregator = eventaggregator;

      Title = Titles.Fillups.ToString();

      GetFillupsCommand = new DelegateCommand(GetFillups);
      DeleteFillupsCommand = new DelegateCommand(Execute, () => {
        return Fillups != null
            && Fillups.Any(f => f.IsChecked);
      }).ObservesProperty(() => HasCheckedItem);

      _eventAggregator.GetEvent<GetFillupsCommand>().Subscribe(FillupListReceived);
      _eventAggregator.GetEvent<GetCarsCommand>().Subscribe(CarListReceived);
      _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());

      SelectedCar = 0;
      GetFillupsCommand.Execute();
    }

    private void GetFillups() {
      _eventAggregator.GetEvent<GetFillupsCommand>().Publish(FillupList.GetFillups(Cars[SelectedCar].Id));
    }

    private void CarListReceived(CarList obj) {
      Cars = obj;
    }

    private void FillupListReceived(FillupList obj) {
      Fillups = obj;
    }

    private void Execute() {
      throw new NotImplementedException();
    }

    #region SelectAll Functionality

    private bool? _allSelected;
    public bool? AllSelected {
      get => _allSelected;
      set {
        SetProperty(ref _allSelected, value);

        // Set all other CheckBoxes
        AllSelectedChanged();
      }
    }

    private bool _hasCheckedItem;
    private bool HasCheckedItem {
      get => _hasCheckedItem;
      set { SetProperty(ref _hasCheckedItem, value); }
    }

    private void ComponentOnPropertyChanged(object sender, PropertyChangedEventArgs args) {
      // Only re-check if the IsChecked property changed
      if (args.PropertyName == nameof(CarInfo.IsChecked)) {
        RecheckAllSelected();
      }
    }

    private void RecheckAllSelected() {
      // Has this change been caused by some other change?
      // return so we don't mess things up
      if (_allSelectedChanging) return;

      try {
        _allSelectedChanging = true;

        if (Cars.All(e => e.IsChecked)) {
          AllSelected = true;
          HasCheckedItem = true;
        }
        else if (Cars.All(e => !e.IsChecked)) {
          AllSelected = false;
          HasCheckedItem = false;
        }
        else {
          AllSelected = null;
          HasCheckedItem = true;
        }
      }
      finally {
        _allSelectedChanging = false;
      }
    }

    private bool _allSelectedChanging;
    private void AllSelectedChanged() {
      // Has this change been caused by some other change?
      // return so we don't mess things up
      if (_allSelectedChanging) return;

      try {
        _allSelectedChanging = true;

        // this can of course be simplified
        if (AllSelected == true) {
          foreach (var fillup in Fillups) {
            fillup.IsChecked = true;
          }
          HasCheckedItem = true;
        }
        else if (AllSelected == false) {
          foreach (var fillup in Fillups) {
            fillup.IsChecked = false;
          }
          HasCheckedItem = false;
        }
      }
      finally {
        _allSelectedChanging = false;
      }
    }

    #endregion
  }
}
