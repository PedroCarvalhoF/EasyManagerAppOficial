using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;

namespace EasyManagerApp.Pages.Produto.Estoque.Estoque;

public partial class MovimentarEstoquePage : ContentPage
{
    public EstoqueProdutoViewModel EstoqueProdutoViewModel { get; }
    private readonly string Token;

    private EstoqueProdutoDtoOperacao _estoqueOperacaoSelecionada;
    public MovimentarEstoquePage(EstoqueProdutoViewModel estoqueProdutoViewModel, string token)
    {
        InitializeComponent();

        EstoqueProdutoViewModel = estoqueProdutoViewModel;
        BindingContext = EstoqueProdutoViewModel;
        Token = token;
        btnConfirmarMovimentacao.IsEnabled = false;


    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        txtQuantidade.Focus();
    }

    private void btnEntradaProduto_Clicked(object sender, EventArgs e)
    {
        _estoqueOperacaoSelecionada = EstoqueProdutoDtoOperacao.Entrada;

        lblProdutoSelecionado.Text = EstoqueProdutoViewModel.ProdutoEstoqueSelecionado.NomeProduto;
        lblQuantidadeSelecionada.Text = txtQuantidade.Text;
        lblOperacao.Text = "ENTRADA";
        btnConfirmarMovimentacao.Text = "Confirmar Entrada";
        btnConfirmarMovimentacao.BackgroundColor = Color.FromArgb("#008236");
        btnConfirmarMovimentacao.IsEnabled = true;
    }

    private void btnSaidaProduto_Clicked(object sender, EventArgs e)
    {
        _estoqueOperacaoSelecionada = EstoqueProdutoDtoOperacao.Saida;

        lblProdutoSelecionado.Text = EstoqueProdutoViewModel.ProdutoEstoqueSelecionado.NomeProduto;
        lblQuantidadeSelecionada.Text = txtQuantidade.Text;
        lblOperacao.Text = "SAÍDA";
        btnConfirmarMovimentacao.Text = "Confirmar Saída";
        btnConfirmarMovimentacao.BackgroundColor = Color.FromArgb("#c10007");
        btnConfirmarMovimentacao.IsEnabled = true;
    }


    private void txtQuantidade_TextChanged(object sender, TextChangedEventArgs e)
    {
        lblQuantidadeSelecionada.Text = txtQuantidade.Text;
    }


    private async void btnConfirmarMovimentacao_Clicked(object sender, EventArgs e)
    {
        try
        {


            var prodSelecionado = EstoqueProdutoViewModel.ProdutoEstoqueSelecionado;

            if (txtQuantidade.Text == string.Empty)
                return;

            if (decimal.TryParse(txtQuantidade.Text, out decimal result))
            {
                var dto = new EstoqueProdutoDtoManter(prodSelecionado.ProdutoId, prodSelecionado.FilialId, Convert.ToDecimal(txtQuantidade.Text), _estoqueOperacaoSelecionada!);

                await EstoqueProdutoViewModel.MovimentarEstoque(Token, dto);
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Atenção", ex.Message, "Ok");
        }

    }

}