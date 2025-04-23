using EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;

namespace EasyManagerApp.Pages.Produto.UnidadeMedidaProduto;

public partial class UnidadeProdutoMedidaPage : ContentPage
{
    public UnidadeProdutoMedidaPage(UnidadeMedidaProdutoViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is UnidadeMedidaProdutoViewModel vm)
        {
            await vm.SelectAsync();
        }
    }
}