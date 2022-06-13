using DesignPatterns.Services;
using DesignPatterns.ViewModels;
using DesignPatterns.Views;

namespace DesignPatterns;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IDesignPatternsService, DesignPatternsService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<PatternsPage>();
        builder.Services.AddSingleton<PatternDetailPage>();
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddSingleton<AboutPageViewModel>();
        builder.Services.AddSingleton<PatternDetailPageViewModel>();
        builder.Services.AddSingleton<PatternsPageViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();

        return builder.Build();
    }
}
