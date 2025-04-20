using CommunityToolkit.Maui;
using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Pages.User;
using EasyManagerApp.Services;
using EasyManagerApp.Services.Account;
using EasyManagerApp.Services.API;
using EasyManagerApp.Services.Intefaces;
using EasyManagerApp.Services.ProdutoCategoria;
using Microsoft.Extensions.Logging;

namespace EasyManagerApp
{
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
                    fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                    fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
                    fonts.AddFont("Nunito-SemiBold.ttf", "NunitoSemiBold");
                });

            builder.Services.AddSingleton<IApiServices, ApiServices>();
            builder.Services.AddTransient<IAccountServices, AccountServices>();
            builder.Services.AddTransient<ICategoriaProdutoServices, CategoriaProdutoServices>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CadastrarUserPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
