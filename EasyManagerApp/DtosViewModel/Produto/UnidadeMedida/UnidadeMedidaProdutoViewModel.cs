using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;

public partial class UnidadeMedidaProdutoViewModel : ObservableObject
{
    private readonly IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>? _services;

    [ObservableProperty]
    private ObservableCollection<UnidadeMedidaProdutoDto> unidadesMedidasProdutos = new();

    public UnidadeMedidaProdutoViewModel(IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>? services)
    {
        _services = services;
    }

    [ObservableProperty]
    public Guid id;
    [ObservableProperty]
    public string? nome;
    [ObservableProperty]
    public string? sigla;
    [ObservableProperty]
    public string? descricao;


    [RelayCommand]
    public async Task SelectAsync()
    {
        try
        {
            var result = await _services?.SelectAsync();
            if (result != null && result.Status)
            {
                UnidadesMedidasProdutos = new ObservableCollection<UnidadeMedidaProdutoDto>(result.Data);
            
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", result?.Mensagem ?? "Erro ao buscar unidades de medida", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
