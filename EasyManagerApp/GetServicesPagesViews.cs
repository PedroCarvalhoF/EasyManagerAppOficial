namespace EasyManagerApp;
public static class GetServicesPagesViews
{
    static IServiceProvider? _servicesProvider { get; set; }
    public static void SetProvider(IServiceProvider servicesProvider)
    => _servicesProvider = servicesProvider;
    public static IServiceProvider GetProvider()
        => _servicesProvider ?? throw new ArgumentNullException(nameof(_servicesProvider), "Service provider not set.");

}
