using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class GenreListPageViewModel : PageViewModelBase
    {
        public List<GenreViewModel> GenreViewModels { get; set; }
    }
}