using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class WoningDetailViewModel
    {

        private Woning _woning;

        public Woning Woning
        {
            get => _woning;
            set
            {
                if (_woning != value)
                {
                    _woning = value;
                    OnPropertyChanged(nameof(Woning));
                }
            }
        }

        private KlantenLijstViewModel _klantenLijstViewModel;

        public WoningDetailViewModel(Woning geselecteerdeWoning)
        {
            Woning = geselecteerdeWoning;
        }
        public WoningDetailViewModel()
        {
            _klantenLijstViewModel = new KlantenLijstViewModel();

        }
        public KlantenLijstViewModel KlantenLijstViewModel
        {
            get => _klantenLijstViewModel;
            set
            {
                if (_klantenLijstViewModel != value)
                {
                    _klantenLijstViewModel = value;
                    OnPropertyChanged(nameof(KlantenLijstViewModel));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
