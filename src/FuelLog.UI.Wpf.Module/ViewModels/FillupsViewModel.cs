using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.UI.Wpf.Module.ViewModels
{
    public class FillupsViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public FillupsViewModel()
        {
            Message = "Fillups view from your Prism Module";
        }
    }
}
