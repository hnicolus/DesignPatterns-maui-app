using CommunityToolkit.Mvvm.ComponentModel;
using DesignPatterns.Utils;

namespace DesignPatterns.ViewModels
{
    public partial class AuthorViewModel : ObservableObject, ITransientService
    {
        [ObservableProperty]
        string position = "Software Developer";

        [ObservableProperty]
        string fullNames = "Nicolas Maluleke";

        [ObservableProperty]
        public  string bio =
            @"
            I am just a dude who writes a lot of code.
            I enjoy writing poetic and expressive code that speaks to both developers and domain experts of any
            level and creating simplified software to enhance user interaction and experience.
            ";
    }
}