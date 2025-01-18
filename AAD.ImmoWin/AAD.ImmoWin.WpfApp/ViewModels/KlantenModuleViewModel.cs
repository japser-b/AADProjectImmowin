using AAD.ImmoWin.WpfApp.ViewModels;
using System.ComponentModel;
namespace AAD.ImmoWin.WpfApp.ViewModels;
public class KlantenModuleViewModel
{
    public KlantenLijstViewModel HuidigeKlantenLijstViewModel { get; }
    public KlantDetailCommandViewModel HuidigeKlantDetailViewModel { get; }

    public KlantenModuleViewModel()
    {
        // Create the list view model
        HuidigeKlantenLijstViewModel = new KlantenLijstViewModel();

        // Pass the list view model to the detail view model constructor
        HuidigeKlantDetailViewModel = new KlantDetailCommandViewModel(HuidigeKlantenLijstViewModel);
        HuidigeKlantDetailViewModel.ReceivedData = HuidigeKlantenLijstViewModel.SelectedCustomer;


        // Subscribe to changes in the SelectedCustomer property
        HuidigeKlantenLijstViewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(KlantenLijstViewModel.SelectedCustomer))
            {
                HuidigeKlantDetailViewModel.ReceivedData = HuidigeKlantenLijstViewModel.SelectedCustomer;
            }
        };
    }
}

