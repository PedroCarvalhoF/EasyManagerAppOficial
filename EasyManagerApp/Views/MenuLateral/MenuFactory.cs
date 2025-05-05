using EasyManagerApp.Dtos;

namespace EasyManagerApp.Views.MenuLateral
{
    public static class MenuFactory
    {
        public static List<MenuItemModel> ObterMenusPorRole(RolesEnum role)
        {
            var todosMenus = new List<MenuItemModel>
            {
                new MenuItemModel
                {
                    Titulo = "Dashboard",
                    Icone = "dashboard.png",
                    PaginaDestino = "Dashboard.DashboardPage",
                    RolesPermitidas = new List<RolesEnum> { RolesEnum.Programador}
                },
                new MenuItemModel
                {
                    Titulo = "Produtos",
                    Icone = "produtos.png",
                    PaginaDestino = "Produto.ProdutosPage",
                    RolesPermitidas = new List<RolesEnum> {  { RolesEnum.Programador} }
                },
                new MenuItemModel
                {
                    Titulo = "Categorias",
                    Icone = "categorias.png",
                    PaginaDestino = "Produto.CategoriaProdutoPage",
                    RolesPermitidas = new List<RolesEnum> {  { RolesEnum.Programador} }
                },
                new MenuItemModel
                {
                    Titulo = "Estoque",
                    Icone = "estoque.png",
                    PaginaDestino = "Produto.Estoque.Estoque.EstoqueProdutoPage",
                    RolesPermitidas = new List<RolesEnum> { { RolesEnum.Programador } }
                },
                new MenuItemModel
                {
                    Titulo = "Movimentação",
                    Icone = "movimentacao.png",
                    PaginaDestino = "Produto.Estoque.Movimento.MovimentacaoEstoquePage",
                    RolesPermitidas = new List<RolesEnum> {  RolesEnum.Programador }
                },
                new MenuItemModel
                {
                    Titulo = "Lista de Compras",
                    Icone = "lista_compra.png",
                    PaginaDestino = "ListaCompra.ListaCompraPage",
                    RolesPermitidas = new List<RolesEnum> {  RolesEnum.Programador }
                }
            };

            return todosMenus.Where(m => m.RolesPermitidas.Contains(role)).ToList();
        }
    }
}
