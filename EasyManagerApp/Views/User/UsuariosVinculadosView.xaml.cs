using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;
using EasyManagerApp.Pages.User.UsuariosVinculados;

namespace EasyManagerApp.Views.User;

public partial class UsuariosVinculadosView : ContentView
{
    private bool _isInitialized = false;
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
            lblStatus.Text = dto.AcessoPermitido ? "Acesso liberado sistema" : "Sem permissão de acesso no sistema";
            lblStatus.TextColor = dto.AcessoPermitido ? Colors.SeaGreen : Colors.Crimson;
        }
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var view_model = App.Services.GetRequiredService<UsuarioVinculadoClienteViewModel>();

        view_model.Token = await SecureStorage.GetAsync("token");
        view_model.UsuarioSelecionado = _usuarioSelecionado;

        await Navigation.PushAsync(new UsuariosVinculadosPageEditar(view_model));
    }
}