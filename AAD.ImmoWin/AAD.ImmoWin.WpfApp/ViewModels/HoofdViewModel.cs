using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Repositories;
using AAD.ImmoWin.WpfApp.Classes;
using AAD.ImmoWin.WpfApp.ViewModels;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels;
public class HoofdViewModel : INotifyPropertyChanged
{
    public string Titel { get; set; }
    public RelayCommand Afsluitcommand { get; set; }
    public RelayCommand ShowWoningenCommand { get; set; }
    public RelayCommand ShowKlantenCommand { get; set; }
    public RelayCommand SetLeegCommand { get; set; }
    public RelayCommand SetDemoCommand { get; set; }
    public RelayCommand SetHuidigeDataCommand { get; set; }

    private readonly EFContect _context;
    private readonly KlantRepository _klantRepository;


    public HoofdViewModel()
    {
        Titel = "ImmoWin-MVVM-View & ViewModel";
        _context = new EFContect();
        HuidigeModuleViewModel = new KlantenModuleViewModel();
        Afsluitcommand = new RelayCommand(Afsluiten);
        ShowWoningenCommand = new RelayCommand(ShowWoningen);
        ShowKlantenCommand = new RelayCommand(ShowKlanten);
        SetLeegCommand = new RelayCommand(SetLeeg);
        SetDemoCommand = new RelayCommand(SetDemo);
        SetHuidigeDataCommand = new RelayCommand(SetHuidigeData);
    }
    private object _huidigeModuleViewModel;

    public object HuidigeModuleViewModel
    {
        get => _huidigeModuleViewModel;
        set
        {
            if (_huidigeModuleViewModel != value)
            {
                _huidigeModuleViewModel = value;
                OnPropertyChanged(nameof(HuidigeModuleViewModel));
            }
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Afsluiten()
    {
        Application.Current.Shutdown();
    }

    private void ShowWoningen()
    {
        HuidigeModuleViewModel = new WoningModuleViewModel();
    }

    private void ShowKlanten()
    {
        HuidigeModuleViewModel = new KlantenModuleViewModel();
    }

    private void SetLeeg()
    {
        _context.Klanten.RemoveRange(_context.Klanten);
        _context.Woningen.RemoveRange(_context.Woningen);
        _context.Adressen.RemoveRange(_context.Adressen);
        _context.Boden.RemoveRange(_context.Boden);
        _context.SaveChanges();
    }

    private void SetDemo()
    {

        // Verwijder bestaande data
        _context.Woningen.RemoveRange(_context.Woningen);
        _context.SaveChanges();

        _context.Huizen.RemoveRange(_context.Huizen);
        _context.Appartementen.RemoveRange(_context.Appartementen);
        _context.SaveChanges();

        _context.Klanten.RemoveRange(_context.Klanten);
        _context.Adressen.RemoveRange(_context.Adressen);
        _context.SaveChanges();

        // Adressen:
        Adres adres = new Adres { Straat = "Hoofdstraat", Nummer = "123", Postnummer = 1000, Gemeente = "Brussel" };
        Adres adres2 = new Adres {  Straat = "Dorpsstraat", Nummer = "456", Postnummer = 2000, Gemeente = "Antwerpen" };
        Adres adres3 = new Adres {  Straat = "Kerkstraat", Nummer = "789", Postnummer = 3000, Gemeente = "Leuven" };
        Adres adres4 = new Adres {  Straat = "Sportsraat", Nummer = "789", Postnummer = 3000, Gemeente = "Leuven" };
        Adres adres5 = new Adres { Straat = "Sportsraat", Nummer = "789", Postnummer = 9620, Gemeente = "Zottegem" };
        // Klanten:
        Klant klant = new Klant {  Familienaam = "Janssens", Voornaam = "Jan", Adres = adres };
        Klant klant2 = new Klant {  Familienaam = "Peeters", Voornaam = "Piet", Adres = adres2 };
        Klant klant3 = new Klant {  Familienaam = "Vermeulen", Voornaam = "Mieke", Adres = adres3 };

        // Woningen:
        Woning woning = new Appartement {  Adres = adres, Waarde = 200000, Bouwdatum = new DateOnly(2025, 10, 1), Eigenaar = klant, Verdieping = 1 };
        Woning woning2 = new Huis {  Adres = adres2, Waarde = 250000, Bouwdatum = new DateOnly(2020, 5, 15), Eigenaar = klant2, Soort = Soort.Rijhuis };
        Woning woning3 = new Huis {  Adres = adres3, Waarde = 450000, Bouwdatum = new DateOnly(2015, 12, 31), Eigenaar = klant3, Soort = Soort.Driegevel };
        Woning woning4 = new Huis { Adres = adres4, Waarde = 550000, Bouwdatum = new DateOnly(2010, 8, 20), Eigenaar = klant, Soort = Soort.Alleenstaand };
        Woning woning5 =new Appartement { Adres = adres5, Waarde = 550000, Bouwdatum = new DateOnly(2010, 8, 20), Eigenaar = klant, Verdieping= 2 };

        // Voeg de demo-objecten toe aan de DbSet
        _context.Adressen.AddRange(adres, adres2, adres3, adres4);
        _context.Klanten.AddRange(klant, klant2, klant3);
        _context.Appartementen.Add((Appartement)woning);
        _context.Huizen.Add((Huis)woning2);
        _context.Huizen.Add((Huis)woning3);
        _context.Huizen.Add((Huis)woning4);
        _context.Appartementen.Add((Appartement)woning5);

        // Sla de wijzigingen op in de database
        _context.SaveChanges();
        if(HuidigeModuleViewModel is KlantenModuleViewModel) 
        {
            ShowKlanten();
        }
        else if (HuidigeModuleViewModel is WoningModuleViewModel)
        {
            ShowWoningen();
        }
    }

    private void SetHuidigeData()
    {
    }
}

