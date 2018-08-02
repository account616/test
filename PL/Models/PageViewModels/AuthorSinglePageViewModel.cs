using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class AuthorSinglePageViewModel : PageViewModelBase
    {
        public AuthorViewModel AuthorViewModel { get; set; }
        public List<NationalityViewModel> NationalityViewModels { get; set; }
    }
}