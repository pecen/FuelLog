using FuelLog.Core.Extensions;
using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class CarListViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;

    #region Properties

    public DelegateCommand DeleteCarsCommand { get; set; }
    public DelegateCommand SearchCommand { get; set; }

    private ObservableCollection<string> _columns;
    public ObservableCollection<string> Columns {
      get { return _columns; }
      set { SetProperty(ref _columns, value); }
    }

    private int _selectedColumns;
    public int SelectedColumn {
      get { return _selectedColumns; }
      set { SetProperty(ref _selectedColumns, value); }
    }

    private string _searchText;
    public string SearchText {
      get { return _searchText; }
      set { SetProperty(ref _searchText, value); }
    }

    private CarList _cars;
    public CarList Cars {
      get { return _cars; }
      set { SetProperty(ref _cars, value); }
    }

    private CarInfo _selectedItem;
    public CarInfo SelectedItem {
      get { return _selectedItem; }
      set { SetProperty(ref _selectedItem, value); }
    }

    #endregion

    public CarListViewModel(IEventAggregator eventAggregator) {
      _eventAggregator = eventAggregator;

      Title = Titles.CarList.GetDescription();

      Columns = new ObservableCollection<string>();

      Columns.GetEnumValues<FilterableColumns>();

      DeleteCarsCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => HasCheckedItem);
      SearchCommand = new DelegateCommand(GetFilteredCarList);

      _eventAggregator.GetEvent<GetCarsCommand>().Subscribe(CarListReceived);
      _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());

      _allSelected = false;
      HasCheckedItem = false;
    }

    private void CarListReceived(CarList obj) {
      foreach (var car in obj) {
        car.PropertyChanged += ComponentOnPropertyChanged;
      }

      Cars = obj;
    }

    private bool CanExecute() {
      return Cars != null
        && Cars.Any(c => c.IsChecked);
    }

    private void Execute() {
      var count = Cars.Where(c => c.IsChecked).Count();
      int successfulDeletes = 0;
      int firstErrorId = 0;

      if (MessageBox.Show($"Are you sure you want to delete {(count > 1 ? "these cars" : "this car")}?",
        "Delete Car?",
        MessageBoxButton.YesNo,
        MessageBoxImage.Warning) == MessageBoxResult.Yes) {

        try {
          foreach (var item in Cars) {
            if (item.IsChecked) {
              CarEdit.DeleteCar(item.Id);
            }
          }
        }
        catch(Exception ex) {
          string s = count == 0 || count > 1 ? "s" : string.Empty;
          string extendedInfo = "The " + (count == 1 ? string.Empty : "first ") + "faulting Car has an id of " + firstErrorId;

          string msg = $"Error when deleting Car{s}." + Environment.NewLine
            + $"{successfulDeletes} Car{s} deleted."
            + $"{(successfulDeletes == 0 ? "No Cars deleted" : Environment.NewLine + extendedInfo)}";

          MessageBox.Show(ex.Message, msg, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally {
          ClearFields();
        }


        _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());
      }
    }

    private void GetFilteredCarList() {
      throw new NotImplementedException();
    }

    private void ClearFields() {
      AllSelected = false;
      SearchText = string.Empty;
      //SelectedDistanceUnit = SelectedVolumeUnit = SelectedConsumptionUnit = -1;
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
          foreach (var component in Cars) {
            component.IsChecked = true;
          }
          HasCheckedItem = true;
        }
        else if (AllSelected == false) {
          foreach (var component in Cars) {
            component.IsChecked = false;
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
