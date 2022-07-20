using DesignPatterns.ViewModels;

namespace DesignPatterns.Views;

public partial class AboutPage : ContentPage, ITransientDependency
{
    public AboutPage(AboutPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}