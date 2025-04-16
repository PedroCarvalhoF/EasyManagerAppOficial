using EasyManagerApp.Dtos.Account;
using EasyManagerApp.Services.Intefaces;
using System.Threading.Tasks;

namespace EasyManagerApp.Pages.User;

public partial class CadastrarUserPage : ContentPage
{
    private readonly IAccountServices _userService;

    public CadastrarUserPage(IAccountServices userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    private async void btnCadastrarUsuario_Clicked(object sender, EventArgs e)
    {
        try
        {
            var comando = new UserCriarContaCommand(new UserDtoCriarContaRequest(txtNome.Text, txtSobreNome.Text, txtEmail.Text, txtSenha.Text, txtConfirmarSenha.Text));

            var resultado = await _userService.CadastrarUsuario<UserDto>(comando);

            if (resultado.Status)
            {
                await DisplayAlert("Cadastro", "Usuário cadastrado com sucesso.", "Retonar ao Login");
                await Navigation.PopAsync();
            }

            if (!resultado.Status)
                await DisplayAlert("Erro", resultado.Mensagem, "OK");
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}