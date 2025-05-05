using EasyManagerApp.Dtos;
using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.Pages;
using EasyManagerApp.Pages.Dashboard;
using EasyManagerApp.Pages.ListaCompra;
using EasyManagerApp.Pages.Produto;
using EasyManagerApp.Pages.Produto.Estoque.Estoque;
using EasyManagerApp.Pages.Produto.Estoque.Movimento;
using EasyManagerApp.Services.Intefaces;
using EasyManagerApp.Views.MenuLateral;

namespace EasyManagerApp
{
    public partial class AppShell : Shell
    {
        private readonly FilialViewModel _filialViewModel;
        private readonly EstoqueProdutoViewModel _estoqueProdutoViewModel;

        private readonly ICategoriaProdutoServices _categoriaProdutoServices;

        public AppShell(RolesEnum role)
        {
            InitializeComponent();

            // Initialize required ViewModels
            _filialViewModel = App.Services.GetRequiredService<FilialViewModel>();
            _estoqueProdutoViewModel = App.Services.GetRequiredService<EstoqueProdutoViewModel>();

            _categoriaProdutoServices = App.Services.GetRequiredService<ICategoriaProdutoServices>();

            RegisterRoutes();
            CarregarMenus(role);
        }

        private void RegisterRoutes()
        {
            // Dashboard
            Routing.RegisterRoute("Dashboard.DashboardPage", typeof(DashboardPage));

            // Home
            Routing.RegisterRoute("HomePage", typeof(HomePage));

            // Produtos
            Routing.RegisterRoute("Produto.ProdutosPage", typeof(ProdutosPage));
            Routing.RegisterRoute("Produto.ProdutosPageEditar", typeof(ProdutosPageEditar));

            // Categoria de Produtos
            Routing.RegisterRoute("Produto.CategoriaProdutoPage", typeof(CategoriaProdutoPage));
            Routing.RegisterRoute("Produto.CategoriaProdutoEditarPage", typeof(CategoriaProdutoEditarPage));

            // Estoque
            Routing.RegisterRoute("Produto.Estoque.Estoque.EstoqueProdutoPage", typeof(EstoqueProdutoPage));
            Routing.RegisterRoute("Produto.Estoque.Movimento.MovimentacaoEstoquePage", typeof(MovimentacaoEstoquePage));

            // Lista de Compras
            Routing.RegisterRoute("ListaCompra.ListaCompraPage", typeof(ListaCompraPage));
        }

        private void CarregarMenus(RolesEnum role)
        {
            var menus = MenuFactory.ObterMenusPorRole(role);

            foreach (var menu in menus)
            {
                var shellContent = new ShellContent
                {
                    Title = menu.Titulo,
                    Icon = menu.Icone,
                    ContentTemplate = new DataTemplate(() => CreatePageInstance(menu.PaginaDestino)),
                    Route = menu.PaginaDestino
                };

                Items.Add(new FlyoutItem
                {
                    Title = menu.Titulo,
                    Items = { shellContent }
                });
            }
        }

        private Page CreatePageInstance(string pageType)
        {
            var type = Type.GetType($"EasyManagerApp.Pages.{pageType}");

            if (type == null)
                throw new Exception($"Page type not found: {pageType}");

            // Handle specific pages that require constructor parameters
            if (type == typeof(MovimentacaoEstoquePage))
            {
                return new MovimentacaoEstoquePage(_filialViewModel, _estoqueProdutoViewModel);
            }

            if (type == typeof(EstoqueProdutoPage))
            {
                return new EstoqueProdutoPage(_estoqueProdutoViewModel, _categoriaProdutoServices);
            }


            // For pages with parameterless constructors
            return (Page)Activator.CreateInstance(type);
        }
    }
}
