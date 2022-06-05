
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;

namespace DesignPatterns.ViewModels
{
	public partial class PatternDetailPageViewModel : ObservableObject
	{
        private readonly IDesignPatternsService designPatternsService;
        [ObservableProperty]
		public Pattern pattern;

		public PatternDetailPageViewModel(IDesignPatternsService designPatternsService)
		{
            this.designPatternsService = designPatternsService;
        }

   

		public async Task LoadPatternAsync(int patternId)
        {
			Pattern = await designPatternsService.GetPatternAsync(patternId);
		}
	}
}

