using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.Helper.Enum;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPageEditar : ContentPage
{
    private readonly ProdutoViewModel _viewModel;
    private readonly ProdutoDto _produto;
    public ProdutosPageEditar(ProdutoViewModel viewModel, ProdutoDto produto, AcoesTeleEnum acao)
    {
        InitializeComponent();
        _viewModel = viewModel;  // O ViewModel é injetado aqui
        _produto = produto;      // O Produto é passado como parâmetro
        BindingContext = _viewModel;

        switch (acao)
        {
            case AcoesTeleEnum.Cadastrar:
                lblId.IsVisible = false;
                break;
            case AcoesTeleEnum.Alterar:
                lblId.IsVisible = true;
                lblId.Text = $"id: {_produto.Id}"; ;
                txtNomeProduto.Text = _produto.NomeProduto;
                txtCodigoProduto.Text = _produto.CodigoProduto;

                break;
            default:
                break;
        }
    }
}