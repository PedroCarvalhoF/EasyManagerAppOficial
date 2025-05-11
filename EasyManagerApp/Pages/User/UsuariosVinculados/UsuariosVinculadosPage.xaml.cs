using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;

namespace EasyManagerApp.Pages.User.UsuariosVinculados;

public partial class UsuariosVinculadosPage : ContentPage
{
    private readonly UsuarioVinculadoClienteViewModel _viewModel;

    public UsuariosVinculadosPage(UsuarioVinculadoClienteViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Token = await SecureStorage.GetAsync("token");
        await _viewModel.CarregarUsuariosVinculados();
    }

    private async void UsuariosVinculadosView_UsuarioSelecionado(object sender, Dtos.UsuarioVinculadoCliente.UsuarioVinculadoClienteDto e)
    {
        _viewModel.UsuarioSelecionado = e;

        _viewModel.EmailUsuarioVinculado = e.EmailUsuarioVinculado;
        _viewModel.AcessoPermitido = e.AcessoPermitido;

        await _viewModel.LiberarBloquearAcesso();
    }
}