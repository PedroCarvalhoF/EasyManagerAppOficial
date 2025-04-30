using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Pages.Produto;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Produto;

public partial class ProdutoViewModel : ObservableObject
{
    private readonly IProdutoServices<ProdutoDto> _produtoService;

    [ObservableProperty]
    private ObservableCollection<ProdutoDto> produtosDtos = new();

    private List<ProdutoDto> _todosProdutos = new();

    [ObservableProperty]
    private ProdutoDto? produtoSelecionado;

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
    [ObservableProperty]
    private Guid unidadeMedidaProdutoId;

    [RelayCommand]
    private async Task TelaDeProdutos()
    {
        await Shell.Current.GoToAsync($"//{nameof(ProdutosPageEditar)}");
    }

    [RelayCommand]
    public async Task CarregarProdutosAsync()
    {
        try
        {
            var token = await SecureStorage.GetAsync("token");

            var resultado = await _produtoService.SelectAsync(token);

            if (resultado.Status && resultado.Data is not null)
            {
                _todosProdutos = resultado.Data.ToList(); // Armazena todos os produtos
                ProdutosDtos.Clear();

                foreach (var item in _todosProdutos)
                {
                    ProdutosDtos.Add(item);
                }
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
    public void FiltrarProdutos(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
        {
            ProdutosDtos = new ObservableCollection<ProdutoDto>(_todosProdutos);
        }
        else
        {
            var filtro = termo.ToLower();

            var filtrados = _todosProdutos
                .Where(p =>
                    (!string.IsNullOrEmpty(p.NomeProduto) && p.NomeProduto.ToLower().Contains(filtro)) ||
                    (!string.IsNullOrEmpty(p.CodigoProduto) && p.CodigoProduto.ToLower().Contains(filtro)))
                .ToList();

            ProdutosDtos = new ObservableCollection<ProdutoDto>(filtrados);
        }
    }


    [RelayCommand]
    public async Task CadastrarAsync(ProdutoDtoCreate produtoCreate)
    {
        try
        {
            var token = await SecureStorage.GetAsync("token");

            var result = await _produtoService.CreateAsync(await SecureStorage.GetAsync("token") ?? string.Empty, produtoCreate);

            if (result.Status)
            {
                await Shell.Current.DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");
                await Shell.Current.Navigation.PopAsync();

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
    public async Task AlterarAsync(ProdutoDtoUpdate produtoUpdateDto)
    {
        try
        {
            var token = await SecureStorage.GetAsync("token");

            var result = await _produtoService.UpdateAsync(await SecureStorage.GetAsync("token") ?? string.Empty, produtoUpdateDto);

            if (result.Status)
            {
                await Shell.Current.DisplayAlert("Sucesso", "Produto alterado com sucesso!", "OK");

            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", result.Mensagem ?? "Erro ao alterar produto", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Exceção", ex.Message, "OK");
        }
    }

}
