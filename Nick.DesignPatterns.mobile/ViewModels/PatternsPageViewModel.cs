using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;
using DesignPatterns.Views;

namespace DesignPatterns.ViewModels
{
    public partial class PatternsPageViewModel : ObservableObject
    {
        private readonly IDesignPatternsService designPatternsService;

        [ObservableProperty]
        public List<Pattern> patterns;

        [ObservableProperty]
        public Category category;
        public PatternsPageViewModel(IDesignPatternsService patternsService)
        {
            designPatternsService = patternsService;
        }

        [ICommand]
        public async Task ShowDetails(Pattern pattern)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Pattern", pattern }
            };
            await Shell.Current.GoToAsync($"{nameof(PatternDetailPage)}",navigationParameter);
        }
        public async Task LoadPatternsAsync(int categoryId)
        {
            Category = await designPatternsService.GetCategoryAsync(categoryId);
            Patterns = await designPatternsService.GetCategoryPatternsAsync(categoryId);
        }
    }
}

