using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Views.Produto.Estoque.Estoque;

public partial class MovimentacaoProdutoEstoqueCard : ContentView
{
    private  IEstoqueProdutoServices<EstoqueProdutoDto> _estoqueProdutoService;
    public string? Token { get; set; }
    public MovimentacaoProdutoEstoqueCard()
    {
        InitializeComponent();       
    }

    public void SetServicesTemp(IEstoqueProdutoServices<EstoqueProdutoDto> estoqueProdutoService)
    {
        _estoqueProdutoService = estoqueProdutoService;
    }

    private async void btnSaidaProduto_Clicked(object sender, EventArgs e)
    {
        try
        {
            var produto = (base.BindingContext as EstoqueProdutoDto);


            if (double.TryParse(txtQuantidade.Text, out double qtd))
            {
                var estoqueMov = new EstoqueProdutoDtoManter(produto.ProdutoId, produto.FilialId, Convert.ToDecimal(qtd), EstoqueProdutoDtoOperacao.Saida);

                var result = await _estoqueProdutoService.MovimentarEstoque(Token, estoqueMov);


            }
        }
        catch (Exception ex)
        {

            await AppShell.Current.DisplayAlert("Atenção", ex.Message, "OK");
        }
    }

    private async void btnEntradaProduto_Clicked(object sender, EventArgs e)
    {
        try
        {
            var produto = (base.BindingContext as EstoqueProdutoDto);


            if (double.TryParse(txtQuantidade.Text, out double qtd))
            {
                var estoqueMov = new EstoqueProdutoDtoManter(produto.ProdutoId, produto.FilialId, Convert.ToDecimal(qtd), EstoqueProdutoDtoOperacao.Entrada);

                var result = await _estoqueProdutoService.MovimentarEstoque(Token, estoqueMov);
            }
        }
        catch (Exception ex)
        {

            await AppShell.Current.DisplayAlert("Atenção", ex.Message, "OK");
        }
    }



}