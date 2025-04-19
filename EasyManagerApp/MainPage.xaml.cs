using EasyManagerApp.Dtos.Account;
using EasyManagerApp.Pages;
using EasyManagerApp.Pages.User;
using EasyManagerApp.Services.Intefaces;

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

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultLogin = await _servicesProvider.GetRequiredService<IAccountServices>()
                .Login<UserDtoLoginResponse>(new UserLoginCommand(new UserDtoLoginRequest(txtEmail.Text, txtSenha.Text)));

            if (!resultLogin.Status)
                throw new ArgumentException(resultLogin.Mensagem);

            await SecureStorage.SetAsync("token", resultLogin.Data.AccessToken ?? string.Empty);

            App.Current.MainPage = new NavigationPage(new HomePage());
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }
}
