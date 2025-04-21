using EasyManagerApp.DtosViewModel.Produto;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPageEditar : ContentPage
{
	public ProdutosPageEditar(ProdutoViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}