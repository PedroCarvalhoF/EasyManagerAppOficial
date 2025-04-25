using EasyManagerApp.Pages;
using EasyManagerApp.Pages.Produto;

namespace EasyManagerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Home
            Routing.RegisterRoute("//HomePage", typeof(HomePage));

            //Produtos
            Routing.RegisterRoute("//ProdutosPage", typeof(ProdutosPage));
            Routing.RegisterRoute("//ProdutosPageEditar", typeof(ProdutosPageEditar));

            //Categoria de Prdoutos
            Routing.RegisterRoute("//CategoriaProdutoPage", typeof(CategoriaProdutoPage));
        }
    }
}
