using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;

namespace EasyManagerApp.Pages.User.UsuariosVinculados;

public partial class UsuariosVinculadosPageEditar : ContentPage
{
    private UsuarioVinculadoClienteViewModel _usuarioVinculadoClienteViewModel;
    public UsuariosVinculadosPageEditar(UsuarioVinculadoClienteViewModel usuarioVinculadoClienteViewModel)
    {
        InitializeComponent();
        _usuarioVinculadoClienteViewModel = usuarioVinculadoClienteViewModel;
        BindingContext = _usuarioVinculadoClienteViewModel;

        if (_usuarioVinculadoClienteViewModel.acessoPermitido)
            lblAcesso.Text = "Remover Acesso";
        else
            lblAcesso.Text = "Liberar Acesso";



    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (_usuarioVinculadoClienteViewModel.acessoPermitido)
            lblAcesso.Text = "Remover Acesso";
        else
            lblAcesso.Text = "Liberar Acesso";
    }
}