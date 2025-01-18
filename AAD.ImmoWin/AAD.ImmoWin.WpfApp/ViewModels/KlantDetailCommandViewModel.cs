using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Repositories;
using AAD.ImmoWin.WpfApp.Classes;
using AAD.ImmoWin.WpfApp.ViewModels;
using System.ComponentModel;
using System.Windows.Input;

namespace AAD.ImmoWin.WpfApp.ViewModels;

public class KlantDetailCommandViewModel : INotifyPropertyChanged
{
    private readonly KlantenLijstViewModel _klantenLijstViewModel;
    private KlantRepository _klantRepository;

    public ICommand ToevoegenCommand { get; }
    private Klant _receivedData;

    public Klant ReceivedData
    {
        get => _receivedData;
        set
        {
            if (_receivedData != value)
            {
                _receivedData = value;
                OnPropertyChanged(nameof(ReceivedData));
            }
        }
    }

    public string Voornaam { get; set; }
    public string Familienaam { get; set; }


    public KlantDetailCommandViewModel()
    {
        // Initialize necessary properties
    }

    public KlantDetailCommandViewModel(KlantenLijstViewModel klantenLijstViewModel)
    {
        _klantenLijstViewModel = klantenLijstViewModel;
        _klantenLijstViewModel.PropertyChanged += OnParentViewModelPropertyChanged;
        // Subscribe to changes within the Klant object itself
        if (_klantenLijstViewModel.SelectedCustomer != null)
        {
            ReceivedData = _klantenLijstViewModel.SelectedCustomer;
           // _klantenLijstViewModel.SelectedCustomer.PropertyChanged += OnKlantPropertyChanged;
        }

        //_klantenLijstViewModel.PropertyChanged += (sender, e) =>
        //{
        //    if (e.PropertyName == nameof(KlantenLijstViewModel.SelectedCustomer))
        //    {
        //        SelectedCustomer = _klantenLijstViewModel.SelectedCustomer;
        //    }
        //};
        //ToevoegenCommand = new RelayCommand(AddCustomer);

    }

    private void OnParentViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_klantenLijstViewModel.SelectedCustomer))
        {
            // Update the local property when data changes in ViewModelA
            ReceivedData = _klantenLijstViewModel.SelectedCustomer;
            Voornaam = ReceivedData.Voornaam;
            Familienaam= ReceivedData.Familienaam;
            //_klantenLijstViewModel.SelectedCustomer.PropertyChanged += OnKlantPropertyChanged;
        }
    }


    //private Klant _selectedCustomer;
    //public Klant SelectedCustomer
    //{
    //    get => _selectedCustomer;
    //    set
    //    {
    //        if (_selectedCustomer != value)
    //        {
    //            _selectedCustomer = value;
    //            OnPropertyChanged(nameof(SelectedCustomer));
    //            OnPropertyChanged(nameof(Voornaam));
    //            OnPropertyChanged(nameof(Familienaam));
    //        }
    //    }
    //}




    //private void AddCustomer()
    //{
    //    if (!string.IsNullOrWhiteSpace(Voornaam) && !string.IsNullOrWhiteSpace(Familienaam))
    //    {
    //        Klant nieuweKlant = new Klant
    //        {
    //            Voornaam = Voornaam,
    //            Familienaam = Familienaam
    //        };

    //        // Voeg de nieuwe klant toe aan de lijst en database
    //        _klantenLijstViewModel.Klanten.Add(nieuweKlant);
    //        _klantRepository.AddKlant(nieuweKlant);

    //        // Stel de nieuwe klant in als geselecteerde klant
    //        SelectedCustomer = nieuweKlant;
    //    }
    //    else
    //    {
    //        // Toon een foutmelding of geef feedback aan de gebruiker
    //        throw new InvalidOperationException("Voornaam en Familienaam mogen niet leeg zijn.");
    //    }
    //}



    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
