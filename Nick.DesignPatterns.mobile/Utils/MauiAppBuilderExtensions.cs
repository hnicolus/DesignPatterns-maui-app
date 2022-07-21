namespace DesignPatterns.Utils;

public static class MauiAppBuilderExtensions
{
    public static void ConfigureServices(this MauiAppBuilder builder)
    {
        RegisterSingletons(builder);
        RegisterTransients(builder);
    }

    private static void RegisterTransients(MauiAppBuilder builder)
    {
        var services = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ITransientDependency).IsAssignableFrom(x)
                        && !x.IsInterface && !x.IsAbstract).ToList();

        foreach (var service in services)
            builder.Services.AddTransient(service);
    }


    private static void RegisterSingletons(MauiAppBuilder builder)
    {
        var services = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ISingletonDependency).IsAssignableFrom(x)
                        && !x.IsInterface && !x.IsAbstract).ToList();

        foreach (var service in services)
            builder.Services.AddSingleton(service);
    }
}