using CommunityToolkit.Mvvm.ComponentModel;

namespace DesignPatterns.ViewModels
{
    public partial class AuthorViewModel : ObservableObject
    {
        [ObservableProperty]
        public string position = "Software Developer";

        [ObservableProperty]
        public string fullNames = "Nicolas Maluleke";

        [ObservableProperty]
        public static string bio =
            @"
            I am a highly result-driven developer, aspiring software architect, and a computer science student.
            I am focused on expanding my knowledge and my abilities in programming and quality assurance.
            I enjoy writing poetic and expressive code that speaks to both developers and domain experts of any
            level and creating simplified software to enhance user interaction and experience.
            ";
    }
}

