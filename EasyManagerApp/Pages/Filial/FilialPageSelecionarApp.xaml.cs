using EasyManagerApp.Dtos.Filial;

namespace EasyManagerApp.Pages.Filial;

public partial class FilialPageSelecionarApp : ContentPage
{
    private readonly List<FilialDto> _filiais;
    public FilialPageSelecionarApp(List<FilialDto> filiais)
    {
        InitializeComponent();
        _filiais = filiais;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        pckFiliais.ItemsSource = _filiais;
        pckFiliais.SelectedItem = _filiais.First();
    }

    private async void btnSelecionarFilial_Clicked(object sender, EventArgs e)
    {
        try
        {
            var filialSelecionada = (FilialDto)pckFiliais.SelectedItem;

            ConfiguracoesGlobalApp.AtualizarFilialSelecionada(filialSelecionada);

            App.Current.MainPage = new NavigationPage(new HomePage());
        }
        catch (Exception ex)
        {

            await DisplayAlert("Atenção", ex.Message, "Ok");
        }
    }  
}