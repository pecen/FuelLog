using FuelLog.Core.Extensions;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class CarListViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;

    #region Properties

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

    #endregion

    public CarListViewModel(IEventAggregator eventAggregator) {
      _eventAggregator = eventAggregator;

      Title = Titles.CarList.GetDescription();

      Columns = new ObservableCollection<string>();

      Columns.GetEnumValues<FilterableColumns>();

      SearchCommand = new DelegateCommand(GetFilteredCarList);
    }

    private void GetFilteredCarList() {
      throw new NotImplementedException();
    }
  }
}
