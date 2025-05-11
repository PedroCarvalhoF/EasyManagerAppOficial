using EasyManagerApp.Dtos.Account;
using EasyManagerApp.DtosViewModel.Role;
using EasyManagerApp.Pages.PageAdmin;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.User.Login;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    private async void cadastrarNovoUsuario_Click(object sender, TappedEventArgs e)
    {
        var page = GetServicesPagesViews.GetProvider().GetRequiredService<CadastrarUserPage>();

        await Navigation.PushAsync(page);
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            var services = GetServicesPagesViews.GetProvider().GetRequiredService<IAccountServices>();

            var resultLogin = await services
                .Login<UserDtoLoginResponse>(new UserLoginCommand(new UserDtoLoginRequest(txtEmail.Text, txtSenha.Text)));

            if (!resultLogin.Status)
                throw new ArgumentException(resultLogin.Mensagem);

            await SecureStorage.SetAsync("token", resultLogin.Data.AccessToken ?? string.Empty);



            var model = GetServicesPagesViews.GetProvider().GetRequiredService<UserRoleViewModel>();

            App.Current.MainPage = new HomePage();

            await DisplayAlert("Acesso", "Login realizado com sucesso.", "Acesso permitido");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }

    }

    private async void btnCadastrarUsuario_Clicked(object sender, EventArgs e)
    {
        var page = GetServicesPagesViews.GetProvider().GetRequiredService<CadastrarUserPage>();
        await Navigation.PushAsync(page);
    }
}