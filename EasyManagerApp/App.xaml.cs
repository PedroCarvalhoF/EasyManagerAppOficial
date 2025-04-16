using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp
{
    public partial class App : Application
    {
        private readonly IServiceProvider _servicesProvider;
        public App(IServiceProvider services)
        {
            InitializeComponent();
            _servicesProvider = services;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage(_servicesProvider)));
        }
    }
}