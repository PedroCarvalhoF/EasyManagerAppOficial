using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Dtos.Produto.Estoque.Movimento;
using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Movimento;
using System.Threading.Tasks;

namespace EasyManagerApp.Pages.Produto.Estoque.Movimento;

public partial class MovimentacaoEstoquePage : ContentPage
{
    public FilialViewModel FilialViewModel { get; }
    public EstoqueProdutoViewModel EstoqueProdutoViewModel { get; }

    public MovimentoEstoqueViewModel MovimentoEstoqueViewModel { get; }
    public MovimentacaoEstoquePage(FilialViewModel filialViewModel, EstoqueProdutoViewModel estoqueProdutoView)
    {
        InitializeComponent();
        FilialViewModel = filialViewModel;
        EstoqueProdutoViewModel = estoqueProdutoView;
        MovimentoEstoqueViewModel = App.Services.GetRequiredService<MovimentoEstoqueViewModel>();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        //if (EstoqueProdutoViewModel.EstoqueProdutoDtos == null || EstoqueProdutoViewModel.EstoqueProdutoDtos.Count == 0)
        await EstoqueProdutoViewModel.LoadEstoqueProduto(await SecureStorage.GetAsync("token") ?? string.Empty);
        pckProduto.ItemsSource = EstoqueProdutoViewModel.EstoqueProdutoDtos;

        await FilialViewModel.GetAllFiliais();
        pckFilial.ItemsSource = FilialViewModel.FiliaisDtos;


        if (FilialViewModel.FiliaisDtos.Count == 1)
            pckFilial.SelectedIndex = 0;
    }
    private async void btnConsultar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var dtoFiltro = MovimentoEstoqueDtoFiltro.Fitrar_FILIAL_PRODUTO(
                pckFilial.SelectedItem is FilialDto filial ? filial.Id : Guid.Empty,
                pckProduto.SelectedItem is EstoqueProdutoDto produto ? produto.ProdutoId : Guid.Empty
            );

            await MovimentoEstoqueViewModel.SelectMovimentoFiltro(dtoFiltro);

            cvMovimentacaoEstoque.ItemsSource = MovimentoEstoqueViewModel.MovimentoEstoqueDtos;
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }
}