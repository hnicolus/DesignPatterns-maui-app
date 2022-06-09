using System;
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
public partial class AboutPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "About Design Patterns";

    [ObservableProperty]
    private AuthorViewModel author;

    [RelayCommand]
    public async Task OpenLinkAsync(LinkType linkType)
    {
        var execDict = new Dictionary<LinkType, Action>();

        execDict.Add(LinkType.Github, async () => await OpenWebAsync("https://github.com/hnicolus"));
        execDict.Add(LinkType.LinkedIn, async () => await OpenWebAsync("https://www.linkedin.com/in/nicolas-maluleke-81a698191"));
        execDict.Add(LinkType.Twitter, async () => await OpenWebAsync("https://twitter.com/HNicolus"));
        execDict.Add(LinkType.Website, async () => await OpenWebAsync("https://nicksoftware.co.za"));

        await MainThread.InvokeOnMainThreadAsync(execDict[linkType]);
    }

    private async Task OpenWebAsync(string url) => Launcher.OpenAsync(url);
}

