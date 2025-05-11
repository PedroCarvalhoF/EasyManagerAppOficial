using EasyManagerApp.Dtos.Role;
using EasyManagerApp.DtosViewModel.Compostas;

namespace EasyManagerApp.Pages.User.UsuariosVinculados;

public partial class UsuariosVinculadosPageEditarPermissoes : ContentPage
{
    private UsuarioVinculadoClienteEditarViewModel? _vm => BindingContext as UsuarioVinculadoClienteEditarViewModel;

    public UsuariosVinculadosPageEditarPermissoes(UsuarioVinculadoClienteEditarViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var resutl = await _vm.Role.SelectRolesUserAscyn(new Dtos.DtoRequestId(_vm.UsuarioVinculado.idUsuarioVinculado));
    }

    private async void btnAdiconarRole_Clicked(object sender, EventArgs e)
    {
        try
        {
            var roleSelecionada = pckPermissoes.SelectedItem as RoleDto;


            var addRole = new RoleDtoAddRoleUser
            {
                UserId = _vm.UsuarioVinculado.idUsuarioVinculado,
                RoleId = roleSelecionada.Id
            };

            await _vm.Role.AdcionarRoleUser(addRole);
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", "Erro inesperado", "Ok");
        }
    }

    private async void btnRemoverRole_Clicked(object sender, EventArgs e)
    {
        try
        {
            var roleSelecionada = pckPermissoes.SelectedItem as RoleDto;


            var addRole = new RoleDtoRemoverRoleUser
            {
                UserId = _vm.UsuarioVinculado.idUsuarioVinculado,
                RoleId = roleSelecionada.Id
            };

            await _vm.Role.RemoverRoleUser(addRole);
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", "Erro inesperado", "Ok");
        }

    }

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
