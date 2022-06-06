
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;

namespace DesignPatterns.ViewModels
{
	public partial class PatternDetailPageViewModel : ObservableObject, IQueryAttributable
	{
        private readonly IDesignPatternsService designPatternsService;

        [ObservableProperty]
		public Pattern pattern;

		public PatternDetailPageViewModel(IDesignPatternsService designPatternsService)
		{
            this.designPatternsService = designPatternsService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Pattern = query["Pattern"] as Pattern;
        }
	}
}

