namespace AAD.ImmoWin.WpfApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using AAD.ImmoWin.Business.Classes;
    using AAD.ImmoWin.Business.Repositories;
    using AAD.ImmoWin.WpfApp.Classes;
    using AAD.ImmoWin.WpfApp.Views;
    using Microsoft.EntityFrameworkCore;

    public class KlantenLijstViewModel : INotifyPropertyChanged
    {
        private KlantRepository _klantRepository;
        private string _searchText;
        private ObservableCollection<Klant> _filteredKlanten;

        public ObservableCollection<Klant> Klanten { get; set; }
        public ObservableCollection<Klant> FilteredKlanten
        {
            get => _filteredKlanten;
            set
            {
                _filteredKlanten = value;
                OnPropertyChanged(nameof(FilteredKlanten));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterKlanten(); // Filter de lijst telkens wanneer SearchText verandert
            }
        }

        public KlantDetailCommandViewModel _klantDetailCommandViewModel { get; }

        public ICommand AddCustomerCommand { get; }
        public ICommand RemoveCustomerCommand { get; }

        public ICommand SendDataCommand { get; }

        private Klant _selectedCustomer;
        public Klant SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged(nameof(SelectedCustomer));
                    //OnCustomerSelected(value);
                }
            }
        }

        public event EventHandler<Klant> CustomerSelected;

        public KlantenLijstViewModel() : this(new KlantRepository(new EFContect())) { }

        public KlantenLijstViewModel(KlantRepository klantRepository)
        {
            _klantDetailCommandViewModel = new KlantDetailCommandViewModel(this);
            SendDataCommand = new RelayCommand(SendData);
            _klantRepository = klantRepository;
            LoadKlanten();
            RemoveCustomerCommand = new RelayCommand(RemoveCustomer, CanRemoveCustomer);

        }

        private void SendData()
        {
            SelectedCustomer = _selectedCustomer;
            SelectedCustomer.Voornaam = _selectedCustomer.Voornaam;
            SelectedCustomer.Familienaam = _selectedCustomer.Familienaam;
        }

        private void LoadKlanten()
        {
            var klantenList = _klantRepository.GetAllKlanten() as List<Klant>;
            Klanten = new ObservableCollection<Klant>(klantenList);
            FilteredKlanten = new ObservableCollection<Klant>(Klanten);
        }

        private void FilterKlanten()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredKlanten = new ObservableCollection<Klant>(Klanten);
            }
            else
            {
                var lowerCaseSearchText = SearchText.ToLower();
                var filtered = Klanten.Where(k =>
                    k.Voornaam.ToLower().Contains(lowerCaseSearchText) ||
                    k.Familienaam.ToLower().Contains(lowerCaseSearchText)).ToList();
                FilteredKlanten = new ObservableCollection<Klant>(filtered);
            }
        }

        private void RemoveCustomer()
        {
            if (SelectedCustomer != null)
            {
                _klantRepository.DeleteKlant(SelectedCustomer.Id);
                Klanten.Remove(SelectedCustomer);
                FilterKlanten(); // Update de gefilterde lijst
                SelectedCustomer = null;
            }
        }

        private bool CanRemoveCustomer()
        {
            return SelectedCustomer != null;
        }

        private void OnCustomerSelected(Klant selectedCustomer)
        {
            CustomerSelected?.Invoke(this, selectedCustomer);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
