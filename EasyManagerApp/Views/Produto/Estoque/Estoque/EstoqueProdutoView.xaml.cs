using EasyManagerApp.Dtos.Produto.Estoque;

namespace EasyManagerApp.Views.Produto.Estoque.Estoque;

public partial class EstoqueProdutoView : ContentView
{
    public event EventHandler<EstoqueProdutoDto>? ProdutoTapped;
    public EstoqueProdutoView()
    {
        InitializeComponent();
    }
    private void OnProdutoTapped(object sender, TappedEventArgs e)
    {
        if (BindingContext is EstoqueProdutoDto produto)
        {
            ProdutoTapped?.Invoke(this, produto);
        }
    }
}