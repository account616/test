using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class BookSinglePageViewModel : PageViewModelBase
    {
        public BookViewModel BookViewModel { get; set; }
        public List<GenreViewModel> GenreViewModels { get; set; }
        public List<LanguageViewModel> LanguageViewModels { get; set; }
        public List<AuthorViewModel> AuthorViewModels { get; set; }
    }
}