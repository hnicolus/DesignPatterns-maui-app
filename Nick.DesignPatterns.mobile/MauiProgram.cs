using DesignPatterns.Services;
using DesignPatterns.Utils;
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
        builder.Services.AddBlazorWebView();
        builder.ConfigureServices();
        return builder.Build();
    }
}
