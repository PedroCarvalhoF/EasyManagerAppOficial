using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Services.Intefaces;
using System.Threading.Tasks;

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

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnAlterar_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro.", ex.Message, "OK");
        }
    }
}