using CommunityToolkit.Maui;
using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Dtos.Produto.Estoque;
using EasyManagerApp.Dtos.Produto.Estoque.Movimento;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;
using EasyManagerApp.Dtos.UsuarioVinculadoCliente;
using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Movimento;
using EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;
using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;
using EasyManagerApp.Pages.Produto;
using EasyManagerApp.Pages.Produto.UnidadeMedidaProduto;
using EasyManagerApp.Pages.User;
using EasyManagerApp.Services;
using EasyManagerApp.Services.Account;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Filial;
using EasyManagerApp.Services.Intefaces;
using EasyManagerApp.Services.Produto;
using EasyManagerApp.Services.Produto.Estoque;
using EasyManagerApp.Services.Produto.UnidadeMedida;
using EasyManagerApp.Services.ProdutoCategoria;
using EasyManagerApp.Services.UsuarioClienteVinculo;
using EasyManagerApp.Views.Produto.Estoque.Estoque;
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
            });

        // Configuração dos serviços
        builder.Services.AddSingleton<IApiServices, ApiServices>();
        builder.Services.AddTransient<IAccountServices, AccountServices>();
        builder.Services.AddTransient<ICategoriaProdutoServices, CategoriaProdutoServices>();
        builder.Services.AddTransient<IProdutoServices<ProdutoDto>, ProdutoServices>();
        builder.Services.AddTransient<IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>, UnidadeMedidaProdutoServices>();
        builder.Services.AddTransient<IEstoqueProdutoServices<EstoqueProdutoDto>, EstoqueProdutoServices>();
        builder.Services.AddTransient<IFilialServices<FilialDto>, FilialServices>();
        builder.Services.AddTransient<IMovimentoEstoqueServices<MovimentoEstoqueDto>, MovimentoEstoqueServices>();
        builder.Services.AddTransient<IUsuarioClienteVinculoServices<UsuarioVinculadoClienteDto>, UsuarioClienteVinculoServices>();

        //views
        builder.Services.AddTransient<MovimentacaoProdutoEstoqueCard>();

        builder.Services.AddTransient<UsuarioVinculadoClienteViewModel>();


        // Páginas
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CadastrarUserPage>();

        builder.Services.AddTransient<ProdutoViewModel>();
        builder.Services.AddTransient<ProdutosPageEditar>();

        //Filial
        builder.Services.AddTransient<FilialViewModel>();

        //Unidade Medida do Produto
        builder.Services.AddTransient<UnidadeProdutoMedidaPage>();
        builder.Services.AddTransient<UnidadeMedidaProdutoViewModel>();

        //estoque
        builder.Services.AddTransient<EstoqueProdutoViewModel>();

        //Movimento Estoque
        builder.Services.AddTransient<MovimentoEstoqueViewModel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
