using EasyManagerApp.Pages.Filial;
using EasyManagerApp.Pages.PageAdmin;
using EasyManagerApp.Pages.Produto;
using EasyManagerApp.Pages.Produto.UnidadeMedidaProduto;
using EasyManagerApp.Pages.User;
using EasyManagerApp.Pages.UserRole;
using EasyManagerApp.Views.Produto.Estoque.Estoque;

namespace EasyManagerApp;
public static class ConfigurePages
{
    public static void ConfigurePagesApp(this MauiAppBuilder builder)
    {
        
        builder.Services.AddScoped<MovimentacaoProdutoEstoqueCard>();
        builder.Services.AddScoped<CadastrarUserPage>();
        builder.Services.AddScoped<ProdutosPageEditar>();
        builder.Services.AddScoped<UnidadeProdutoMedidaPage>();
        builder.Services.AddScoped<UserRolePage>();
        builder.Services.AddScoped<RoleUserPage>();
        builder.Services.AddScoped<FilialPage>();   
    }
}
