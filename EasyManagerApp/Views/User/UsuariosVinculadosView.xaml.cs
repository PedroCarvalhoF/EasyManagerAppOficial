using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.DtosViewModel.Compostas;
using EasyManagerApp.DtosViewModel.Role;
using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;
using EasyManagerApp.Pages.User.UsuariosVinculados;

namespace EasyManagerApp.Views.User;
public partial class UsuariosVinculadosView : ContentView
{   
    private UsuarioVinculadoClienteDto? _usuarioSelecionado;
    public UsuariosVinculadosView()
    {
        InitializeComponent();
    }
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is UsuarioVinculadoClienteDto dto)
        {
            _usuarioSelecionado = dto;
            lblStatus.Text = dto.AcessoPermitido ? "Liberado Acesso" : "Acesso Restrito";
            lblStatus.TextColor = dto.AcessoPermitido ? Colors.SeaGreen : Colors.Crimson;
        }
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var view_model = App.Services.GetRequiredService<UsuarioVinculadoClienteViewModel>();
        var view_modelRole = App.Services.GetRequiredService<UserRoleViewModel>();

        view_model.Token = await SecureStorage.GetAsync("token");
        view_model.UsuarioSelecionado = _usuarioSelecionado;

        var vm = new UsuarioVinculadoClienteEditarViewModel(view_model, view_modelRole);

        await Navigation.PushAsync(new UsuariosVinculadosPageEditar(vm));
    }
}