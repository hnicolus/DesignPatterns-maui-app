using System;
namespace DesignPatterns.Utils
{
    public interface ITransientService{}

    public interface ISingleton { }

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
                .Where(x => typeof(ITransientService).IsAssignableFrom(x)
                && !x.IsInterface && !x.IsAbstract).ToList();

            foreach (Type service in services)
                builder.Services.AddTransient(service);
        }

  
        private static void RegisterSingletons(MauiAppBuilder builder)
        {
            var services = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISingleton).IsAssignableFrom(x)
                && !x.IsInterface && !x.IsAbstract).ToList();

            foreach (Type service in services)
                builder.Services.AddSingleton(service);
        }
    }
}

