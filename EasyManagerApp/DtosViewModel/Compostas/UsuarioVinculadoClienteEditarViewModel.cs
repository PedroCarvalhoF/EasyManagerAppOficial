using CommunityToolkit.Mvvm.ComponentModel;
using EasyManagerApp.DtosViewModel.Role;
using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;

namespace EasyManagerApp.DtosViewModel.Compostas;
public partial class UsuarioVinculadoClienteEditarViewModel : ObservableObject
{
    public UsuarioVinculadoClienteViewModel UsuarioVinculado { get; set; }
    public UserRoleViewModel Role { get; set; }

    public UsuarioVinculadoClienteEditarViewModel(UsuarioVinculadoClienteViewModel usuarioVinculado, UserRoleViewModel role)
    {
        UsuarioVinculado = usuarioVinculado;
        Role = role;
    }
}
