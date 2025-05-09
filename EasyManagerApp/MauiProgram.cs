using CommunityToolkit.Maui;
using EasyManagerApp.DtosViewModel.Filial;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Estoque;
using EasyManagerApp.DtosViewModel.Produto.Estoque.Movimento;
using EasyManagerApp.DtosViewModel.Produto.UnidadeMedida;
using EasyManagerApp.DtosViewModel.UsuarioVinculadoCliente;
using EasyManagerApp.Pages.Produto;
using EasyManagerApp.Pages.Produto.UnidadeMedidaProduto;
using EasyManagerApp.Pages.User;
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
            .UseMauiCommunityToolkit() 
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        builder.ConfigureServicesApp();
        builder.ConfigureViewModelsApp();
        builder.ConfigurePagesApp();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
