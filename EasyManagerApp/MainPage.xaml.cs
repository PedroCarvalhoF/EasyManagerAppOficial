using EasyManagerApp.Pages.User;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManagerApp;

public partial class MainPage : ContentPage
{
    private readonly IServiceProvider _servicesProvider;
    public MainPage(IServiceProvider servicesProvider)
    {
        InitializeComponent();
        _servicesProvider = servicesProvider;
    }

    private async void btnCadastrarUsuario_Clicked(object sender, EventArgs e)
    {
        //// Certifique-se de que o método GetRequiredService está disponível ao usar o namespace correto
        var page = _servicesProvider.GetRequiredService<CadastrarUserPage>();
        await Navigation.PushAsync(page);
    }
}
