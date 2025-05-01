using CommunityToolkit.Maui;
using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;
using EasyManagerApp.Pages.Produto;
using EasyManagerApp.Pages.Produto.UnidadeMedidaProduto;
using EasyManagerApp.Pages.User;
using EasyManagerApp.Services;
using EasyManagerApp.Services.Account;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;
using EasyManagerApp.Services.Produto;
using EasyManagerApp.Services.Produto.Estoque;
using EasyManagerApp.Services.Produto.UnidadeMedida;
using EasyManagerApp.Services.ProdutoCategoria;
using Microsoft.Extensions.Logging;

namespace EasyManagerApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit() // Já faz a configuração de injeção de dependência
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
                fonts.AddFont("Nunito-SemiBold.ttf", "NunitoSemiBold");
            });

        // Configuração dos serviços
        builder.Services.AddSingleton<IApiServices, ApiServices>();
        builder.Services.AddTransient<IAccountServices, AccountServices>();
        builder.Services.AddTransient<ICategoriaProdutoServices, CategoriaProdutoServices>();
        builder.Services.AddTransient<IProdutoServices<ProdutoDto>, ProdutoServices>();
        builder.Services.AddTransient<IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>, UnidadeMedidaProdutoServices>();
        builder.Services.AddTransient<IEstoqueProdutoServices<EstoqueProdutoDto>, EstoqueProdutoServices>();

        // Páginas
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CadastrarUserPage>();

        builder.Services.AddTransient<ProdutoViewModel>();
        builder.Services.AddTransient<ProdutosPageEditar>();

        builder.Services.AddTransient<UnidadeProdutoMedidaPage>();
        builder.Services.AddTransient<UnidadeMedidaProdutoViewModel>();

        builder.Services.AddTransient<EstoqueProdutoViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
