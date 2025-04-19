using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.Produto;

public partial class CategoriaProdutoEditarPage : ContentPage
{
    public CategoriaProdutoDto CategoriaProdutoDtoSelecionada;
    private readonly ICategoriaProdutoServices ICategoriaProdutoServices;

    public CategoriaProdutoEditarPage(CategoriaProdutoDto categoriaProdutoDtoSelecionada, ICategoriaProdutoServices iCategoriaProdutoServices)
    {
        InitializeComponent();
        CategoriaProdutoDtoSelecionada = categoriaProdutoDtoSelecionada;
        ICategoriaProdutoServices = iCategoriaProdutoServices;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}