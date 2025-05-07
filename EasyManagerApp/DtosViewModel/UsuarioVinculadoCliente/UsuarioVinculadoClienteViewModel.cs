using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;
public partial class UsuarioVinculadoClienteViewModel : ObservableObject
{
    private readonly IUsuarioClienteVinculoServices<UsuarioVinculadoClienteDto> _usuarioVinculadoClienteServices;
    private ObservableCollection<UsuarioVinculadoClienteDto> _todosUsuarios = new();

    public UsuarioVinculadoClienteViewModel(IUsuarioClienteVinculoServices<UsuarioVinculadoClienteDto> usuarioVinculadoClienteServices)
    {
        _usuarioVinculadoClienteServices = usuarioVinculadoClienteServices;
    }

    [ObservableProperty]
    private ObservableCollection<UsuarioVinculadoClienteDto> usuarios = new();
    [ObservableProperty]
    private UsuarioVinculadoClienteDto usuarioSelecionado = new();

    [ObservableProperty]
    public Guid clienteId;
    [ObservableProperty]
    public string? clienteNome;
    [ObservableProperty]
    public Guid idUsuarioVinculado;
    [ObservableProperty]
    public string? nomeUsuarioVinculado;
    [ObservableProperty]
    public string? emailUsuarioVinculado;
    [ObservableProperty]
    public bool acessoPermitido;

    [ObservableProperty]
    private string token;

    [ObservableProperty]
    private string searchText;

    partial void OnSearchTextChanged(string value)
    {
        FiltrarUsuarios(value);
    }

    private void FiltrarUsuarios(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            Usuarios = new ObservableCollection<UsuarioVinculadoClienteDto>(_todosUsuarios);
            return;
        }

        var filtered = _todosUsuarios.Where(u => 
            u.NomeUsuarioVinculado?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
            u.EmailUsuarioVinculado?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true);

        Usuarios = new ObservableCollection<UsuarioVinculadoClienteDto>(filtered);
    }

    public async Task CarregarUsuariosVinculados()
    {
        var result = await _usuarioVinculadoClienteServices.SelectUsuariosVinculadosByClienteAsync(Token);
        if (result.Status)
        {
            _todosUsuarios.Clear();
            foreach (var usuario in result.Data)
            {
                _todosUsuarios.Add(usuario);
            }
            FiltrarUsuarios(SearchText);
        }
    }

    [RelayCommand]
    private async Task CarregarUsuariosVinculadosCommand()
    {
        await CarregarUsuariosVinculados();
    }

    [RelayCommand]
    private async Task VincularUsuario()
    {
        var dtoRegistrarVinculo = new UsuarioVinculadoClienteDtoRegistrarVinculo
        {
            EmailUsuarioParaVincular = EmailUsuarioVinculado
        };

        var result = await _usuarioVinculadoClienteServices.VincularUsuarioAoClienteAsync(dtoRegistrarVinculo, Token);
        if (result.Status)
        {
            await CarregarUsuariosVinculados();
        }
    }

    [RelayCommand]
    private async Task LiberarBloquearAcesso()
    {
        var liberarRemoverAcesso = new UsuarioVinculadoClienteDtoLiberarRemoverAcesso
        {
            EmailUsuarioVinculado = EmailUsuarioVinculado,
            LiberarAcesso = AcessoPermitido
        };

        var result = await _usuarioVinculadoClienteServices.LiberarBloquearAcessoUsuarioVinculadoAsync(liberarRemoverAcesso, Token);
        if (result.Status)
        {
            await CarregarUsuariosVinculados();
        }
    }
}
