using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.Helper.Enum;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPageEditar : ContentPage
{
    private readonly ProdutoDto? _produtoSelecionado;
    private AcoesTeleEnum _acaoTelaSelecionada;
    public ProdutosPageEditar(ProdutoViewModel viewModel, ProdutoDto? produtoSelecionado, AcoesTeleEnum acaoTelaSelecionada)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _produtoSelecionado = produtoSelecionado;
        _acaoTelaSelecionada = acaoTelaSelecionada;

        switch (_acaoTelaSelecionada)
        {
            case AcoesTeleEnum.Cadastrar:
                break;
            case AcoesTeleEnum.Alterar:
                break;
            default:
                break;
        }
    }
}