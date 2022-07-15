using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Utils;

namespace DesignPatterns.ViewModels
{
    public enum LinkType
    {
        Github ,
        LinkedIn,
        Twitter,
        Website
    }

    public partial class AboutPageViewModel : ObservableObject, ITransientService
    {
        [ObservableProperty]
        string _title = "About Design Patterns";
        
        [ObservableProperty]
        List<string> _description = new List<string>()
        {
            "This is a sample about page for the Design Patterns app."
        };

        [ObservableProperty]
        AuthorViewModel author = new ();

        [RelayCommand]
        public async Task OpenLinkAsync(LinkType linkType)
        {
            Dictionary<LinkType, Action> execDict = new Dictionary<LinkType, Action>
        {
            { LinkType.Github, async () => await OpenWebAsync("https://github.com/hnicolus") },
            { LinkType.LinkedIn, async () => await OpenWebAsync("https://www.linkedin.com/in/nicolas-maluleke-81a698191") },
            { LinkType.Twitter, async () => await OpenWebAsync("https://twitter.com/HNicolus") },
            { LinkType.Website, async () => await OpenWebAsync("https://nicksoftware.co.za") }
        };

            await MainThread.InvokeOnMainThreadAsync(execDict[linkType]);
        }

        static async Task OpenWebAsync(string url) => await Launcher.OpenAsync(url);
    }
}