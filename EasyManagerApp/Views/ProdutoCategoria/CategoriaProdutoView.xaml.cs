using EasyManagerApp.Dtos.ProdutoCategoria;

namespace EasyManagerApp.Views.ProdutoCategoria;

public partial class CategoriaProdutoView : ContentView
{
    public event EventHandler<CategoriaProdutoDto>? EditarClicked;
    public CategoriaProdutoView()
    {
        InitializeComponent();
    }

    private void btnEditarCategoria_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is CategoriaProdutoDto categoria)
        {
            EditarClicked?.Invoke(this, categoria);
        }
    }
}