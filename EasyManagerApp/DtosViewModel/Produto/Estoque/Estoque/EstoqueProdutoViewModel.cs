using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
public partial class EstoqueProdutoViewModel : ObservableObject
{
    private readonly IEstoqueProdutoServices<EstoqueProdutoDto> _estoqueProdutoService;
    public EstoqueProdutoViewModel(IEstoqueProdutoServices<EstoqueProdutoDto> estoqueProdutoService)
    {
        _estoqueProdutoService = estoqueProdutoService;
    }

    [ObservableProperty]
    private ObservableCollection<EstoqueProdutoDto> estoqueProdutoDtos = new();

    [ObservableProperty]
    public Guid produtoId;

    [ObservableProperty]
    public string nomeProduto;

    [ObservableProperty]
    public Guid filialId;

    [ObservableProperty]
    public string nomeFilial;

    [ObservableProperty]
    public decimal quantidade;

    [RelayCommand]
    public async Task LoadEstoqueProduto(string token)
    {
        var result = await _estoqueProdutoService.SelectAllAsync(token);
        if (result.Status)
        {
            EstoqueProdutoDtos.Clear();
            if (result.Data != null)
            {
                foreach (var item in result.Data)
                {
                    EstoqueProdutoDtos.Add(item);
                }
            }
        }
    }
}
