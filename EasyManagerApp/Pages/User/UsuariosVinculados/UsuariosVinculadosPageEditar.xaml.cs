using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;

namespace EasyManagerApp.Pages.User.UsuariosVinculados;

public partial class UsuariosVinculadosPageEditar : ContentPage
{
    private UsuarioVinculadoClienteViewModel _usuarioVinculadoClienteViewModel;
    public UsuariosVinculadosPageEditar(UsuarioVinculadoClienteViewModel usuarioVinculadoClienteViewModel)
    {
        InitializeComponent();
        _usuarioVinculadoClienteViewModel = usuarioVinculadoClienteViewModel;
    }
}