using EasyManagerApp.DtosViewModel.Compostas;
using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Movimento;
using EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;
using EasyManagerApp.DtosViewModel.Role;
using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;

namespace EasyManagerApp;
public static class ConfigureViewModels
{
    public static void ConfigureViewModelsApp(this MauiAppBuilder builder)
    {
        builder.Services.AddScoped<UserRoleViewModel>();
        builder.Services.AddScoped<UsuarioVinculadoClienteEditarViewModel>();

        builder.Services.AddScoped<UsuarioVinculadoClienteViewModel>();
        builder.Services.AddScoped<ProdutoViewModel>();
        builder.Services.AddScoped<FilialViewModel>();
        builder.Services.AddScoped<UnidadeMedidaProdutoViewModel>();
        builder.Services.AddScoped<EstoqueProdutoViewModel>();
        builder.Services.AddScoped<MovimentoEstoqueViewModel>();
    }
}
