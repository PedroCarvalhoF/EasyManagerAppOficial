using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
public partial class EstoqueProdutoViewModel : ObservableObject
{
    private readonly IEstoqueProdutoServices<EstoqueProdutoDto>? _estoqueProdutoService;
    private List<EstoqueProdutoDto> _todosEstoqueProdutos = new List<EstoqueProdutoDto>();
    public EstoqueProdutoViewModel(IEstoqueProdutoServices<EstoqueProdutoDto> estoqueProdutoService)
    {
        _estoqueProdutoService = estoqueProdutoService;
    }

    [ObservableProperty]
    private ObservableCollection<EstoqueProdutoDto> estoqueProdutoDtos = new();
    [ObservableProperty]
    private EstoqueProdutoDto produtoEstoqueSelecionado = new();

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
    [ObservableProperty]
    public string unidadeMedidaProduto;

    [RelayCommand]
    public async Task LoadEstoqueProduto(string token)
    {
        var result = await _estoqueProdutoService.SelectAllAsync(token);
        if (result.Status)
        {
            _todosEstoqueProdutos = new List<EstoqueProdutoDto>();


            EstoqueProdutoDtos.Clear();
            if (result.Data != null)
            {
                _todosEstoqueProdutos = result.Data.ToList();

                foreach (var item in result.Data)
                {
                    EstoqueProdutoDtos.Add(item);
                }
            }
        }

    }

    [RelayCommand]
    public void FiltrarProdutoEstoque(string nomeProduto)
    {
        if (string.IsNullOrWhiteSpace(nomeProduto))
        {
            EstoqueProdutoDtos = new ObservableCollection<EstoqueProdutoDto>();
        }
        else
        {
            var filtro = nomeProduto.ToLower();

            var filtrados = _todosEstoqueProdutos
                .Where(p =>
                    (!string.IsNullOrEmpty(p.NomeProduto) && p.NomeProduto.ToLower().Contains(filtro)))
                .ToList();

            EstoqueProdutoDtos = new ObservableCollection<EstoqueProdutoDto>(filtrados);
        }
    }

    [RelayCommand]
    public void FiltraProdutoEstoqueByCategoriaProduto(Guid categoriaId)
    {
        var filtrados = _todosEstoqueProdutos.Where(p => p.CategoriaProdutoEntityId == categoriaId).ToList();

        EstoqueProdutoDtos = new ObservableCollection<EstoqueProdutoDto>(filtrados);
    }


   
    public async Task MovimentarEstoque(string token, EstoqueProdutoDtoManter estoqueProdutoDto)
    {
        try
        {
            var result = await _estoqueProdutoService.MovimentarEstoque(token, estoqueProdutoDto);
            if (result.Status)
            {
                await LoadEstoqueProduto(token);
                await Application.Current.MainPage.DisplayAlert("Sucesso", "Estoque Atualizado", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", result.Mensagem, "OK");
            }
        }
        catch (Exception ex)
        {

            await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
