using EasyManagerApp.Pages.User.Login;

namespace EasyManagerApp
{
    public partial class App : Application
    {
        public static IServiceProvider? Services { get; private set; }
        public App(IServiceProvider services)
        {
            InitializeComponent();

            Services = services;

            GetServicesPagesViews.SetProvider(services);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new NavigationPage(new LoginPage()));
            return window;
        }
    }
}