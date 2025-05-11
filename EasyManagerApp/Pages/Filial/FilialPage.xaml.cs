using EasyManagerApp.DtosViewModel.Filial;
using System.Threading.Tasks;

namespace EasyManagerApp.Pages.Filial;

public partial class FilialPage : ContentPage
{
    private FilialViewModel _vm => (BindingContext as FilialViewModel)!;
    public FilialPage(FilialViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _vm.InitializeAsync();
    }
}