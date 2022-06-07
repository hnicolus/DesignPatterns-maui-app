
using CommunityToolkit.Mvvm.ComponentModel;
using DesignPatterns.Models;
using DesignPatterns.Services;

namespace DesignPatterns.ViewModels
{
	public partial class PatternDetailPageViewModel : ObservableObject, IQueryAttributable
	{
        private readonly IDesignPatternsService _designPatternsService;

        [ObservableProperty]
        private Pattern _pattern;

		public PatternDetailPageViewModel(IDesignPatternsService designPatternsService)
		{
            _designPatternsService = designPatternsService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Pattern = query[nameof(Pattern)] as Pattern;
        }
	}
}

