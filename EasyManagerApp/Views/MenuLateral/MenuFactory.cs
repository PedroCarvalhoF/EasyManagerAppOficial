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
                    Titulo = "Usuarios",
                    Icone = "usuarios.png",
                    PaginaDestino = "User.UsuariosVinculados.UsuariosVinculadosPage",
                    RolesPermitidas = new List<RolesEnum> { RolesEnum.Programador,RolesEnum.Admin}
                }
            };

            return todosMenus.Where(m => m.RolesPermitidas.Contains(role)).ToList();
        }
    }
}
