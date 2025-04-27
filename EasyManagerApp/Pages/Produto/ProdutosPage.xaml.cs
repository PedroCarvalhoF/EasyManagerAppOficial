using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;
using EasyManagerApp.Pages.Produto.UnidadeMedidaProduto;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPage : ContentPage
{
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;
    public UnidadeMedidaProdutoViewModel UnidadeMedidaProdutoView { get; }

    // Mudando a forma de injeção para permitir que o Maui cuide da instância
    public ProdutoViewModel ProdutoViewModel { get; }

    // Mudando o construtor para usar a injeção do Maui
    public ProdutosPage(ICategoriaProdutoServices categoriaProdutoServices, ProdutoViewModel produtoViewModel, UnidadeMedidaProdutoViewModel unidadeMedidaProdutoView)
    {
        InitializeComponent();

        _categoriaProdutoServices = categoriaProdutoServices;
        ProdutoViewModel = produtoViewModel;

        BindingContext = ProdutoViewModel; // Atribui o ViewModel da injeção   
        UnidadeMedidaProdutoView = unidadeMedidaProdutoView;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ((ProdutoViewModel)BindingContext).CarregarProdutosAsync();
    }

    private async void btnCategoriaProduto_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new CategoriaProdutoPage(_categoriaProdutoServices));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }

    private async void btnCadastrarProduto_Clicked(object sender, EventArgs e)
    {
        try
        {
            var services = App.Services.GetRequiredService<IProdutoServices<ProdutoDto>>();

            await Navigation.PushAsync(new ProdutosPageEditar(new ProdutoViewModel(services), Helper.Enum.AcoesTeleEnum.Cadastrar));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }

    private async void btnUnidadeMedida_Clicked(object sender, EventArgs e)
    {
        try
        {


            await Navigation.PushAsync(new UnidadeProdutoMedidaPage(UnidadeMedidaProdutoView));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }
}
