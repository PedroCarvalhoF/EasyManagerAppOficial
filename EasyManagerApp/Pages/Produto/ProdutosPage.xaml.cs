using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPage : ContentPage
{
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;
    private readonly IServiceProvider _service;

    public ProdutosPage(ICategoriaProdutoServices categoriaProdutoServices,
                        ProdutoViewModel produtoViewModel,
                        IServiceProvider service)
    {
        InitializeComponent();

        produtoViewModel.ProdutosDtos.Add(new ProdutoDto
        {
            NomeProduto = "Produto Direto",
            CodigoProduto = "BIND001",
            CategoriaProduto = "TesteBinding"
        });

        _categoriaProdutoServices = categoriaProdutoServices;
        _service = service;
        BindingContext = produtoViewModel;
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

        var page = _service.GetRequiredService<ProdutosPageEditar>();
        await Navigation.PushAsync(page);
    }
}
