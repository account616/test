using PL.Models.ViewModels;
using System.Collections.Generic;

namespace PL.Models.PageViewModels
{
    public class AuthorListPageViewModel : PageViewModelBase
    {
        public List<AuthorViewModel> AuthorViewModels { get; set; }
    }
}