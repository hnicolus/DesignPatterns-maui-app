using CommunityToolkit.Mvvm.ComponentModel;

namespace DesignPatterns.ViewModels;

public partial class AuthorViewModel : ObservableObject, ITransientDependency
{
    [ObservableProperty] private string bio =
        @"
            I am just a dude who writes a lot of code.
            I enjoy writing poetic and expressive code that speaks to both developers and domain experts of any
            level and creating simplified software to enhance user interaction and experience.
            ";

    [ObservableProperty] private string fullNames = "Nicolas Maluleke";
    [ObservableProperty] private string position = "Software Developer";
}