using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.WpfApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class WoningModuleViewModel : INotifyPropertyChanged
    {
        public WoningLijstViewModel HuidigeWoningLijstViewModel { get; }

        public WoningDetailCommandViewModel HuidigeWoningDetailViewModel { get; }


        public WoningModuleViewModel()
        {
            HuidigeWoningLijstViewModel = new WoningLijstViewModel();
            HuidigeWoningDetailViewModel = new WoningDetailCommandViewModel();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
