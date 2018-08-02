using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class LanguageListPageViewModel : PageViewModelBase
    {
        public List<LanguageViewModel> LanguageViewModels { get; set; }
    }
}