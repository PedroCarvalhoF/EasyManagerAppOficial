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
}