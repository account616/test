using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class BookListPageViewModel : PageViewModelBase
    {
        public List<BookViewModel> BookViewModels { get; set; }
        public List<GenreViewModel> GenreViewModels { get; set; }
        public int? GenreFilterId { get; set; }
        public List<LanguageViewModel> LanguageViewModels { get; set; }
        public int? LanguageFilterId { get; set; }
        public List<AuthorViewModel> AuthorViewModels { get; set; }
        public int? AuthorFilterId { get; set; }
    }
}