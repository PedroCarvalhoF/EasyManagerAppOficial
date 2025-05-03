using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Produto.Estoque.Movimento;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Produto.Estoque.Movimento;
public partial class MovimentoEstoqueViewModel : ObservableObject
{
    private readonly IMovimentoEstoqueServices<MovimentoEstoqueDto> _movimentoEstoqueServices;

    public MovimentoEstoqueViewModel(IMovimentoEstoqueServices<MovimentoEstoqueDto> movimentoEstoqueServices)
    {
        _movimentoEstoqueServices = movimentoEstoqueServices;
    }

    [ObservableProperty]
    private ObservableCollection<MovimentoEstoqueDto> movimentoEstoqueDtos = new();
    [ObservableProperty]
    private MovimentoEstoqueDto movimentoEstoqueDtoSelecionado = new();

    [ObservableProperty]
    public Guid produtoId;

    [ObservableProperty]
    public string? nomeProduto;

    [ObservableProperty]
    public Guid filialId;

    [ObservableProperty]
    public string? nomeFilial;

    [ObservableProperty]
    public decimal quantidade;

    [ObservableProperty]
    public string? tipo;

    [ObservableProperty]
    public string? observacao;

    [ObservableProperty]
    public DateTime dataMovimentacao;

    [ObservableProperty]
    public Guid usuarioRegistroId;

    [ObservableProperty]
    public string? nomeUsuarioRegistro;

    [RelayCommand]
    public async Task SelectMovimentoFiltro(MovimentoEstoqueDtoFiltro fitroMovimentacaoEstoque)
    {
        var token = await SecureStorage.GetAsync("token");

        var result = await _movimentoEstoqueServices.SelectMovimentoFiltro(token, fitroMovimentacaoEstoque);
        if (result.Status)
        {
            MovimentoEstoqueDtos = new ObservableCollection<MovimentoEstoqueDto>(result.Data);
        }
    }
}
