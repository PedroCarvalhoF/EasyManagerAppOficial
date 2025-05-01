using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;

namespace EasyManagerApp.Pages.Produto.Estoque.Estoque;

public partial class EstoqueProdutoPage : ContentPage
{
    public EstoqueProdutoViewModel EstoqueProdutoViewModel { get; }
    public EstoqueProdutoPage(EstoqueProdutoViewModel estoqueProdutoViewModel)
    {
        InitializeComponent();
        EstoqueProdutoViewModel = estoqueProdutoViewModel;
        BindingContext = EstoqueProdutoViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await EstoqueProdutoViewModel.LoadEstoqueProduto(await SecureStorage.GetAsync("token"));
    }

}