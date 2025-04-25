using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp
{
    public partial class App : Application
    {
        public readonly IServiceProvider _servicesProvider;
        public static IServiceProvider? Services { get; private set; }
        public App(IServiceProvider services)
        {
            InitializeComponent();
            _servicesProvider = services;
            Services = services;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage(_servicesProvider)));
        }
    }
}