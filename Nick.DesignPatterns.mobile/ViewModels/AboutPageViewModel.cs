using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DesignPatterns.ViewModels;

public enum LinkType
{
    Github,
    LinkedIn,
    Twitter,
    Website
}

public partial class AboutPageViewModel : ObservableObject, ITransientDependency
{
    [ObservableProperty] private List<string> _description = new()
    {
        "This is a sample about page for the Design Patterns app."
    };

    [ObservableProperty] private string _title = "About Design Patterns";

    [ObservableProperty] private AuthorViewModel author = new();

    [RelayCommand]
    public async Task OpenLinkAsync(LinkType linkType)
    {
        var execDict = new Dictionary<LinkType, Action>
        {
            { LinkType.Github, async () => await OpenWebAsync("https://github.com/hnicolus") },
            {
                LinkType.LinkedIn,
                async () => await OpenWebAsync("https://www.linkedin.com/in/nicolas-maluleke-81a698191")
            },
            { LinkType.Twitter, async () => await OpenWebAsync("https://twitter.com/HNicolus") },
            { LinkType.Website, async () => await OpenWebAsync("https://nicksoftware.co.za") }
        };

        await MainThread.InvokeOnMainThreadAsync(execDict[linkType]);
    }

    private static async Task OpenWebAsync(string url)
    {
        await Launcher.OpenAsync(url);
    }
}