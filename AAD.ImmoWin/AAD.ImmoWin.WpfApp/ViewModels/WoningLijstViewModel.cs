using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Repositories;
using AAD.ImmoWin.WpfApp.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class WoningLijstViewModel : INotifyPropertyChanged
    {
        private readonly WoningRepository _woningRepository;
        public ICommand RemoveWoningCommand { get; }
        public ICommand AddWoningCommand { get; }
        public ICommand SorteerOpAdresCommand { get; }
        public ICommand ToonHuizenCommand { get; }
        public ICommand ToonAppartementenCommand { get; }
        private ObservableCollection<Woning> _origineleWoningen;

        private ObservableCollection<Woning> _woningen;

        private string _actieveFilter;

        public string ActieveFilter
        {
            get => _actieveFilter;
            set
            {
                if (_actieveFilter != value)
                {
                    _actieveFilter = value;
                    OnPropertyChanged(nameof(ActieveFilter));
                }
            }
        }

        private Woning _selectedWoning;

        public Woning SelectedWoning
        {
            get => _selectedWoning;
            set
            {
                if (_selectedWoning != value)
                {
                    _selectedWoning = value;
                    OnPropertyChanged(nameof(SelectedWoning));
                }
            }
        }
        public event EventHandler<Woning> WoningSelected; 

        // Public parameterless constructor
        public WoningLijstViewModel() : this(new WoningRepository(new EFContect())) { }



        public WoningLijstViewModel(WoningRepository woningRepository)
        {
            _woningRepository = woningRepository;
            LoadWoningen();
            AddWoningCommand = new RelayCommand(AddWoning);
            RemoveWoningCommand = new RelayCommand(RemoveWoning, CanRemoveWoning);
            SorteerOpAdresCommand = new RelayCommand(SorteerOpAdres);
            ToonHuizenCommand = new RelayCommand(ToonHuizen);
            ToonAppartementenCommand = new RelayCommand(ToonAppartementen);
        }

        private void LoadWoningen()
        {
            IEnumerable<Woning> woningen = _woningRepository.GetAllWoningen();
            _origineleWoningen = new ObservableCollection<Woning>(woningen);
            Woningen = new ObservableCollection<Woning>(woningen);
        }



        public void UpdateWoning(Woning woning)
        {
            _woningRepository.UpdateWoning(woning);
            LoadWoningen();
        }

        private void RemoveWoning()
        {
            if (SelectedWoning != null)
            {
                // Verwijderen uit de database
                _woningRepository.DeleteWoning(SelectedWoning.Id);

                // Verwijderen uit de UI-collectie
                Woningen.Remove(SelectedWoning);
                SelectedWoning = null;
            }
        }
        private bool CanRemoveWoning()
        {
            return SelectedWoning != null;
        }
        private void AddWoning()
        {
            Woning woning = new Woning();
            Woningen.Add(woning);
            _woningRepository.AddWoning(woning);
            SelectedWoning = woning;
        }



        private void OnWoningSelected(Woning selectedWoning)
        {
            WoningSelected?.Invoke(this, selectedWoning);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void SorteerOpAdres()
        {
            if (ActieveFilter == "SorteerOpAdres")
            {
                ActieveFilter = null;
                ToonVolledigeLijst();
            }
            else
            {
                ActieveFilter = "SorteerOpAdres";
                List<Woning> gesorteerdeWoningen = _origineleWoningen.OrderBy(w => w.AdresString).ToList();
                Woningen = new ObservableCollection<Woning>(gesorteerdeWoningen);
            }
        }

        private void ToonHuizen()
        {
            if (ActieveFilter == "Huizen")
            {
                ActieveFilter = null;
                ToonVolledigeLijst();
            }
            else
            {
                ActieveFilter = "Huizen";
                List<Woning> gefilterdeWoningen = _origineleWoningen.Where(w => w is Huis).ToList();
                Woningen = new ObservableCollection<Woning>(gefilterdeWoningen);
            }
        }

        private void ToonAppartementen()
        {
            if (ActieveFilter == "Appartementen")
            {
                ActieveFilter = null;
                ToonVolledigeLijst();
            }
            else
            {
                ActieveFilter = "Appartementen";
                List<Woning> gefilterdeWoningen = _origineleWoningen.Where(w => w is Appartement).ToList();
                Woningen = new ObservableCollection<Woning>(gefilterdeWoningen);
            }
        }

        private void ToonVolledigeLijst()
        {
            // Oorspronkelijke lijst tonen
            Woningen = new ObservableCollection<Woning>(_origineleWoningen);
        }
        public ObservableCollection<Woning> Woningen
        {
            get => _woningen;
            set
            {
                if (_woningen != value)
                {
                    _woningen = value;
                    OnPropertyChanged(nameof(Woningen));
                }
            }
        }

    }
}
