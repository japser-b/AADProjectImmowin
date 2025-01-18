using AAD.ImmoWin.Business.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class WoningDetailCommandViewModel : INotifyPropertyChanged
    {

        public WoningDetailCommandViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
