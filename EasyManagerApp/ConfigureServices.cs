#region Usings
using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Dtos.Produto.Estoque.Movimento;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;
using EasyManagerApp.Dtos.Role;
using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.Services;
using EasyManagerApp.Services.Account;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Filial;
using EasyManagerApp.Services.Intefaces;
using EasyManagerApp.Services.Produto;
using EasyManagerApp.Services.Produto.Estoque;
using EasyManagerApp.Services.Produto.UnidadeMedida;
using EasyManagerApp.Services.ProdutoCategoria;
using EasyManagerApp.Services.Role;
using EasyManagerApp.Services.UsuarioClienteVinculo;
#endregion


namespace EasyManagerApp;
public static class ConfigureServices
{
    public static void ConfigureServicesApp(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IApiServices, ApiServices>();
        builder.Services.AddSingleton<IAccountServices, AccountServices>();
        builder.Services.AddSingleton<IUserRoleServices<RoleDto>, UserRoleServices>();
        builder.Services.AddSingleton<IFilialServices<FilialDto>, FilialServices>();




















        builder.Services.AddSingleton<ICategoriaProdutoServices, CategoriaProdutoServices>();
        builder.Services.AddSingleton<IProdutoServices<ProdutoDto>, ProdutoServices>();
        builder.Services.AddSingleton<IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>, UnidadeMedidaProdutoServices>();
        builder.Services.AddSingleton<IEstoqueProdutoServices<EstoqueProdutoDto>, EstoqueProdutoServices>();

        builder.Services.AddSingleton<IMovimentoEstoqueServices<MovimentoEstoqueDto>, MovimentoEstoqueServices>();
        builder.Services.AddSingleton<IUsuarioClienteVinculoServices<UsuarioVinculadoClienteDto>, UsuarioClienteVinculoServices>();

    }
}
