using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;

namespace DesignPatterns.ViewModels
{
	public partial class PatternsPageViewModel:ObservableObject
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
        public async Task ShowDetails(int patternId)
        {
            await Shell.Current.GoToAsync($"patterns/detail?patternId={patternId}");
        }
        public async Task LoadPatternsAsync(int categoryId)
        {
            Category = await designPatternsService.GetCategoryAsync(categoryId);
            Patterns = await designPatternsService.GetCategoryPatternsAsync(categoryId);
        }
    }
}

