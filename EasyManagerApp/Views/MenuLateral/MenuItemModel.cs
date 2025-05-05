using EasyManagerApp.Dtos;

namespace EasyManagerApp.Views.MenuLateral;

public class MenuItemModel
{
    public string Titulo { get; set; }
    public string Icone { get; set; }
    public string PaginaDestino { get; set; }
    public List<RolesEnum> RolesPermitidas { get; set; }
}
