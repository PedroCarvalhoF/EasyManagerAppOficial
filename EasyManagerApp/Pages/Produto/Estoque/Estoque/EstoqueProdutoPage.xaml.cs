using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.Pages.Produto.Estoque.Movimento;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.Produto.Estoque.Estoque;

public partial class EstoqueProdutoPage : ContentPage
{
    private string token;
    public EstoqueProdutoViewModel EstoqueProdutoViewModel { get; }
    private readonly ICategoriaProdutoServices _categoriaProdutoSerices;
    public EstoqueProdutoPage(EstoqueProdutoViewModel estoqueProdutoViewModel, ICategoriaProdutoServices categoriaProdutoSerices)
    {
        InitializeComponent();

        EstoqueProdutoViewModel = estoqueProdutoViewModel;
        BindingContext = EstoqueProdutoViewModel;
        _categoriaProdutoSerices = categoriaProdutoSerices;


    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        token = await SecureStorage.GetAsync("token") ?? string.Empty;
        await EstoqueProdutoViewModel.LoadEstoqueProduto(token);


        //var result = await _categoriaProdutoSerices.ConsultarCategoriasProdutos<CategoriaProdutoDto>(token, CancellationToken.None);

        //if (result != null && result.Status)
        //{
        //  //  pckCategoriaProduto.ItemsSource = result.Data.ToList();
        //}
        //else
        //{
        //    await DisplayAlert("Erro", "Erro ao carregar categorias de produtos", "OK");
        //}
    }
    private async void txtNomeCodigoProduto_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            EstoqueProdutoViewModel.FiltrarProdutoEstoque(txtNomeCodigoProduto.Text);
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }

    private void pckCategoriaProduto_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        var categoriaSelecionada = (CategoriaProdutoDto)picker.SelectedItem;

        if (categoriaSelecionada != null)
        {
            EstoqueProdutoViewModel.FiltraProdutoEstoqueByCategoriaProduto(categoriaSelecionada.Id);
        }
    }

    private async void EstoqueProdutoView_ProdutoTapped(object sender, object e)
    {
        try
        {
            var produtoEstoqueDto = (EstoqueProdutoDto)e;

            EstoqueProdutoViewModel.ProdutoEstoqueSelecionado = produtoEstoqueDto;

            // (Opcional) Preencher outras propriedades do ViewModel
            EstoqueProdutoViewModel.NomeProduto = produtoEstoqueDto.NomeProduto;
            EstoqueProdutoViewModel.Quantidade = produtoEstoqueDto.Quantidade;
            EstoqueProdutoViewModel.UnidadeMedidaProduto = produtoEstoqueDto.UnidadeMedidaProduto;
            EstoqueProdutoViewModel.NomeFilial = produtoEstoqueDto.NomeFilial;
            EstoqueProdutoViewModel.FilialId = produtoEstoqueDto.FilialId;
            EstoqueProdutoViewModel.ProdutoId = produtoEstoqueDto.ProdutoId;

            await Navigation.PushAsync(new MovimentarEstoquePage(EstoqueProdutoViewModel, token));
        }
        catch (Exception ex)
        {

            await DisplayAlert("Atenção", ex.Message, "Ok");
        }
    }

    private async void btnAtualizarEstoque_Clicked(object sender, EventArgs e)
    {
        await EstoqueProdutoViewModel.LoadEstoqueProduto(token);
    }

    private void EstoqueProdutoView_ProdutoTapped(object sender, EstoqueProdutoDto e)
    {

    }

    private async void btnHistoricoMovimentacao_Clicked(object sender, EventArgs e)
    {
        var services = App.Services.GetRequiredService<FilialViewModel>();

        await Navigation.PushAsync(new MovimentacaoEstoquePage(services, EstoqueProdutoViewModel));
    }
}