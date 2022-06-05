using DesignPatterns.Views;

namespace DesignPatterns;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("patterns", typeof(PatternsPage));
        Routing.RegisterRoute("patterns/detail", typeof(PatternDetailPage));
    }
}

