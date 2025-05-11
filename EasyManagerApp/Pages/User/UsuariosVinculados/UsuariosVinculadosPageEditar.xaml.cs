using EasyManagerApp.DtosViewModel.Compostas;

namespace EasyManagerApp.Pages.User.UsuariosVinculados;

public partial class UsuariosVinculadosPageEditar : ContentPage
{
    private readonly UsuarioVinculadoClienteEditarViewModel _viewModel;

    public UsuariosVinculadosPageEditar(UsuarioVinculadoClienteEditarViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;

        AtualizarTextoAcesso();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.Role.InitAsync();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        AtualizarTextoAcesso();
    }

    private void AtualizarTextoAcesso()
    {
        lblAcesso.Text = _viewModel.UsuarioVinculado.acessoPermitido
            ? "Remover Acesso"
            : "Liberar Acesso";
    }

    private async void btnEditarPermissoes_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UsuariosVinculadosPageEditarPermissoes(_viewModel));
    }
}
