using EasyManagerApp.Services.Intefaces;
using System.Threading.Tasks;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPage : ContentPage
{
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;
    public ProdutosPage(ICategoriaProdutoServices categoriaProdutoServices)
    {
        InitializeComponent();
        _categoriaProdutoServices = categoriaProdutoServices;
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
}