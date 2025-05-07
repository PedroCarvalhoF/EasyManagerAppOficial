using CommunityToolkit.Mvvm.ComponentModel;
using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;
public partial class UsuarioVinculadoClienteViewModel : ObservableObject
{
    private readonly IUsuarioClienteVinculoServices<UsuarioVinculadoClienteDto> _usuarioVinculadoClienteServices;

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
   
}
