using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Produto;

public partial class ProdutoViewModel : ObservableObject
{
    private readonly IProdutoServices<ProdutoDto> _produtoService;

    [ObservableProperty]
    public ObservableCollection<ProdutoDto> produtosDtos = new();

    public ProdutoViewModel(IProdutoServices<ProdutoDto> produtoService)
    {
        _produtoService = produtoService;
    }

    [ObservableProperty]
    private Guid id;
    [ObservableProperty]
    private string? nomeProduto;

    [ObservableProperty]
    private string? codigoProduto;

    [ObservableProperty]
    private Guid categoriaProdutoEntityId;

    [ObservableProperty]
    private string? categoriaProduto;

    [RelayCommand]
    private async Task CadastrarAsync()
    {
        try
        {
            var produtoCreate = new ProdutoDtoCreate
            {
                NomeProduto = NomeProduto,
                CodigoProduto = CodigoProduto,
                CategoriaProdutoEntityId = categoriaProdutoEntityId
            };

            var token = await SecureStorage.GetAsync("token");

            var result = await _produtoService.CadastrarProduto<ProdutoDto>(token, produtoCreate, default);

            if (result.Status)
            {
                await Shell.Current.DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");

            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", result.Mensagem ?? "Erro ao cadastrar", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Exceção", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task CarregarProdutosAsync()
    {
        try
        {
            var token = await SecureStorage.GetAsync("token");

            var resultado = await _produtoService.ConsultarProdutos(token, default);

            if (resultado.Status && resultado.Data is not null)
            {
                produtosDtos.Clear();

                //foreach (var item in resultado.Data)
                //{
                //    produtosDtos.Add(item);
                //}

                produtosDtos.Add(new ProdutoDto
                {
                    NomeProduto = "Produto Teste",
                    CodigoProduto = "TEST123",
                    CategoriaProduto = "Categoria Teste"
                });
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", resultado.Mensagem ?? "Erro ao carregar produtos", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
        }
    }

}
