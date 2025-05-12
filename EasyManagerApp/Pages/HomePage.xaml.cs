using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.Pages.Filial;

namespace EasyManagerApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        lblBoasVindas.Text = $"{ConfiguracoesGlobalApp.GetUsuarioLogadoResponse().Nome} , Bem Vindo";
        lblFilialSelecionada.Text = $"Filial: {ConfiguracoesGlobalApp.GetFilialSelecionada().NomeFilial}";

    }
    private async void Filial_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            var vw_filila = App.Services.GetRequiredService<FilialViewModel>();

            await Navigation.PushAsync(new NavigationPage(new FilialPage(vw_filila)));
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}